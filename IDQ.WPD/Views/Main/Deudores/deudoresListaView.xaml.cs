using IDQ.Domain.Models;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Views.Main.Deudores
{
    /// <summary>
    /// Interaction logic for deudoresListaView.xaml
    /// </summary>
    public partial class deudoresListaView : UserControl
    {
        #region Initialize
        public deudoresListaView() { InitializeComponent(); }
        #endregion // Initialize


        #region Filters
        void CollectionViewSourceListDeuda_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as ventaProductoModel).CantidadFaltante > 0;
        }
        #endregion // Filters
    }
}
