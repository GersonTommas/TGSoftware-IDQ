using IDQ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.EntityFramework.Updates
{
    class Update016000
    {
        public static void xDoUpdate()
        {
            ObservableCollection<ventaModel> ventas = context.globalDb.ventas.Local.ToObservableCollection();
            if (ventas.All(x => x.PrecioTotal == 0))
            {
                foreach (ventaModel venta in ventas)
                {
                    venta.PrecioTotal = Math.Round(venta.VentaProductosPerVenta.Sum(x => x.PrecioTotal), 2);
                }
            }
        }
    }
}
