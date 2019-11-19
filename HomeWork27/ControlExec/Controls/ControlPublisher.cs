using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDriver;
using ControlExec.Model;

namespace ControlExec.Controls
{
    internal class ControlPublisher: IControl<PublisherModel>
    {
        private readonly IRepository<Publishers> _repository;
        public int MaxNameSize { get; set; }
        List<string> message;

        public ControlPublisher(int maxNameSize)
        {
            _repository = new PublicherRepository();
            MaxNameSize = maxNameSize;
            message = new List<string>();
        }

        public ExeResult Create(PublisherModel model)
        {
            message.Clear();
            if (model.Name.Length > MaxNameSize) message.Add($"Long name >{MaxNameSize}.");

            Publishers publisherTemp = _repository.GetByName(model.Name);
            if(publisherTemp!=null)
            {
                if(publisherTemp.Name==model.Name) message.Add("This Name already exists.");
            }

            if (message.Count != 0) return new ExeResult(message);

            var publisher= ControlTools.MapTo<PublisherModel, Publishers>(model);
            model.Id = _repository.Create(publisher);
            if (model.Id == 0) return new ExeResult(new List<string>() { "Publisher not create" });

            return new ExeResult(new List<string>()); ;
        }

        public ExeResult Delete(PublisherModel model)
        {
            if (_repository.GetById(model.Id) == null) return new ExeResult(new List<string>() { "This publisher is unknown." });

            var publisher = ControlTools.MapTo<PublisherModel, Publishers>(model);
            var result = ControlTools.DbExec(_repository.Delete, publisher, "Genre not delete");
            return result;
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            List<PublisherModel> publishersModel = new List<PublisherModel>();
            var result = _repository.GetAll();
            ParallelLoopResult res = Parallel.ForEach(result, item =>
            {
                publishersModel.Add(ControlTools.MapTo<Publishers, PublisherModel>(item));
            });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return publishersModel;
        }

        public ExeResult GetById(int id, out PublisherModel model)
        {
            model = ControlTools.MapTo<Publishers, PublisherModel>(_repository.GetById(id));
            if (model == null) return new ExeResult(new List<string>() { "Unknown id" });
            if (model.Name.Length > MaxNameSize)
            {
                return new ExeResult(new List<string>() { $"Long name >{MaxNameSize}." });
            }

            return new ExeResult( null);
        }

        public ExeResult GetByName(string name, out PublisherModel model)
        {
            model = ControlTools.MapTo<Publishers, PublisherModel>(_repository.GetByName(name));
            if (model == null) return new ExeResult(new List<string>() { "Unknown name" });
            if (model.Name.Length > MaxNameSize) return new ExeResult( new List<string>() { $"Long name >{MaxNameSize}." });

            return new ExeResult(new List<string>());
        }

        public ExeResult Update(PublisherModel model)
        {
            message.Clear();
            if (model.Name.Length > MaxNameSize) message.Add($"Long name >{MaxNameSize}.");

            var publish = ControlTools.MapTo<PublisherModel, Publishers>(model);
            var result = ControlTools.DbExec(_repository.Update, publish, "Publisher not update");
            return result;
        }
    }
}
