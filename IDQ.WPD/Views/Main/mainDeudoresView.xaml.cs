using IDQ.Domain.Models;
using IDQ.WPF.ViewModels.Main;
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
        mainDeudoresViewModel dt;

        public mainDeudoresView()
        {
            InitializeComponent();
            dt = DataContext as mainDeudoresViewModel;
        }
        #endregion // Initialize


        #region Filters
        void CollectionViewSourceListDeuda_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as ventaProductoModel).CantidadFaltante > 0;
        }
        #endregion // Filters
    }
}
