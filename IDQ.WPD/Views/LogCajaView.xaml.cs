using IDQ.Domain.Models;
using System.Windows.Controls;

namespace IDQ.WPF.Views
{
    /// <summary>
    /// Interaction logic for LogCajaView.xaml
    /// </summary>
    public partial class LogCajaView : UserControl
    {
        public LogCajaView()
        {
            InitializeComponent();
        }


        #region Filtros
        void collectionViewSourceUsuarios_Filter(object sender, System.Windows.Data.FilterEventArgs e)
        {
            e.Accepted = (e.Item as usuarioModel).Activo;
        }
        #endregion // Filtros
    }
}
