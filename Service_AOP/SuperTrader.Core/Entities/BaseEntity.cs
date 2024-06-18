using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTrader.Core.Entities
{
    
    public  class BaseEntity<T>: IEntity 
    {
        public BaseEntity()
        {

            if (!(typeof(T).IsPrimitive && typeof(T) != typeof(bool) && typeof(T) != typeof(char)))
                throw new Exception("T Have to be number");


        }
        public T Id { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public bool  IsDeleted { get; set; }
    }
}
