using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.Domain.Models
{
    public class medidaSelectorModel : Base.ModelBase
    {
        #region Properties
        public string Tipo { get; set; }
        #endregion // Properties


        #region Navigation
        public virtual ICollection<medidaModel> medidasPerMedidaSelector { get; private set; } = new ObservableCollection<medidaModel>();
        #endregion // Navigation
    }
}
