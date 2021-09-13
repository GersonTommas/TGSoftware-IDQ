using IDQ.Domain.Models;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Views.Helpers
{
    /// <summary>
    /// Interaction logic for productoNewEditView.xaml
    /// </summary>
    public partial class productoNewEditView : UserControl
    {
        #region Initialize
        public productoNewEditView() { InitializeComponent(); }
        #endregion // Initialize


        #region Filters
        void CollectionViewSourceTags_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is tagModel item)
            {
                e.Accepted = item.Activo;
            }
        }

        void CollectionViewSourceMedidas_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is medidaModel item)
            {
                e.Accepted = item.Activo;
            }
        }
        #endregion // Filters
    }
}
