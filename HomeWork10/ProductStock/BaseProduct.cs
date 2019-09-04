using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStock
{
    public class BaseProduct
    {
        public DateTime _DateReception { get; }
        public int _ValidDay { get; }
        public BaseProduct(int validDay,DateTime? dt=null)
        {
            _ValidDay = validDay;
            _DateReception = dt ?? DateTime.Now;
        }
        public DateTime ExpiredDate()
        {
            return _DateReception.AddDays(_ValidDay);
        }
        public bool IsExpired(DateTime currentDate)
        {
            return currentDate > _DateReception.AddDays(_ValidDay);
        }
    }
}
