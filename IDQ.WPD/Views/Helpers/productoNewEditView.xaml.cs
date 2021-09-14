using IDQ.Domain.Models;
using IDQ.WPF.ViewModels.Helpers;
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
        static productoNewEditView thisWindow;

        public productoNewEditView() { InitializeComponent(); thisWindow = this; }

        public static async void updateProductoSlider(Base.ViewModelBase sentViewModel) { (thisWindow.DataContext as productoNewEditViewModel).updateEditorSlider(sentViewModel); }
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
