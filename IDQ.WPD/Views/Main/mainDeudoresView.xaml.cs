using IDQ.Domain.Models;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for mainDeudoresView.xaml
    /// </summary>
    public partial class mainDeudoresView : UserControl
    {
        #region Initialize
        public mainDeudoresView()
        {
            InitializeComponent();
        }
        #endregion // Initialize


        #region Filters
        void CollectionViewSourceListDeuda_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as deudaProductoModel).CantidadFaltante > 0;
        }
        #endregion // Filters
    }
}
