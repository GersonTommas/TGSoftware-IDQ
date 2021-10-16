using IDQ.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.Shared
{
    public class Navigators
    {
        #region Navigators
        public static INavigator ContentTopNavigator { get; } = new Navigator();

        public static INavigator ProductoTagMedidaNavigator { get; } = new Navigator();
        //public static void UpdateProductoSlider(Base.ViewModelBase sentViewModel) { Views.Helpers.productoNewEditView.updateProductoSlider(sentViewModel); }

        public static INavigator VentaDeudorNavigator { get; } = new Navigator();
        //public static void UpdateVentaDeudorSlider(Base.ViewModelBase sentViewModel) { Views.Helpers.pagarVentaView.updateVentaDeudorSlider(sentViewModel); }
        #endregion // Navigators
    }
}
