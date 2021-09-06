using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.Domain.Base
{
    public class ModelBase : PropertyChangedBase
    {
        public int Id { get; set; }

        public virtual void updateModel() { }
    }
}
