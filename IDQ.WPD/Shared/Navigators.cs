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

        public static INavigator VentaDeudorNavigator { get; } = new Navigator();

        public static INavigator RetiroMotivoNavigator { get; } = new Navigator();
        #endregion // Navigators
    }
}
