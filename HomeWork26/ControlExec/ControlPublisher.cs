using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDriver;
using DataBaseDriver.Model;
using ControlExec.Model;
namespace ControlExec
{
    public class ControlPublisher: IControl<PublisherModel>
    {
        private readonly IRepository<Publisher> _repository;
        public int MaxNameSize { get; set; }
        List<string> message;

        public ControlPublisher(string connectionBaseStr,int maxNameSize)
        {
            _repository = new PublicherRepository(connectionBaseStr);
            MaxNameSize = maxNameSize;
            message = new List<string>();
        }

        public ExeResult Create(PublisherModel model)
        {
            message.Clear();
            if (model.Name.Length > MaxNameSize) message.Add($"Long name >{MaxNameSize}.");

            Publisher publisherTemp = _repository.GetByName(model.Name);
            if(publisherTemp!=null)
            {
                if(publisherTemp.Name==model.Name) message.Add("This Name already exists.");
            }

            if (message.Count != 0) return new ExeResult(true, message);

            var publisher= ControlTools.MapTo<PublisherModel, Publisher>(model);
            var result = ControlTools.DbExec(_repository.Create, publisher, "Publisher not create");
            return result;
        }

        public ExeResult Delete(PublisherModel model)
        {
            var publisher = ControlTools.MapTo<PublisherModel, Publisher>(model);
            var result = ControlTools.DbExec(_repository.Delete, publisher, "Genre not delete");
            return result;
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            List<PublisherModel> publishersModel = new List<PublisherModel>();
            var result = _repository.GetAll();
            ParallelLoopResult res = Parallel.ForEach(result.Where(i=>i.Name.Length <= MaxNameSize), item =>
            {
                publishersModel.Add(ControlTools.MapTo<Publisher, PublisherModel>(item));
            });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return publishersModel;
        }

        public ExeResult GetById(int id, out PublisherModel model)
        {
            model = ControlTools.MapTo<Publisher, PublisherModel>(_repository.GetById(id));
            if (model == null) return new ExeResult(true, new List<string>() { "Unknown id" });
            return new ExeResult(false, null);
        }

        public ExeResult GetByName(string name, out PublisherModel model)
        {
            model = ControlTools.MapTo<Publisher, PublisherModel>(_repository.GetByName(name));
            if (model == null) return new ExeResult(true, new List<string>() { "Unknown name" });
            return new ExeResult(false, null);
        }

        public ExeResult Update(PublisherModel model)
        {
            throw new NotImplementedException();
        }
    }
}
