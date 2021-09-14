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
        public static INavigator ContentTopNavigator { get; } = new Navigator();
        public static void UpdateEditorSlider(Base.ViewModelBase sentObject) { ContentWindow.updateEditorSlider(sentObject); }

        public static INavigator ProductoTagMedidaNavigator { get; } = new Navigator();
        public static void UpdateProductoSlider(Base.ViewModelBase sentViewModel) { Views.Helpers.productoNewEditView.updateProductoSlider(sentViewModel); }
    }
}
