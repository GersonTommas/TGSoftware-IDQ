using IDQ.Domain.Models;
using IDQ.WPF.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IDQ.WPF.Views.Helpers
{
    /// <summary>
    /// Interaction logic for productoNewEditView.xaml
    /// </summary>
    public partial class productoNewEditView : UserControl
    {
        public productoNewEditView()
        {
            InitializeComponent();
        }

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
    }
}
