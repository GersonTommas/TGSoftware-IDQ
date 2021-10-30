using IDQ.Domain.Models;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Views.Helpers
{
    /// <summary>
    /// Interaction logic for retiroNewView.xaml
    /// </summary>
    public partial class retiroNewView : UserControl
    {
        #region Initialize
        public retiroNewView() { InitializeComponent(); }
        #endregion // Initialize


        #region Filters
        void CollectionViewSourceAutoriza_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is usuarioModel item)
            {
                e.Accepted = item.Nivel < 3;
            }
        }
        #endregion // Filters
    }
}
