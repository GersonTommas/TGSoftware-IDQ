using IDQ.Domain.Models;
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

namespace IDQ.WPF.Views.Main.Deudores
{
    /// <summary>
    /// Interaction logic for deudoresFechaView.xaml
    /// </summary>
    public partial class deudoresFechaView : UserControl
    {
        public deudoresFechaView()
        {
            InitializeComponent();
        }

        void CollectionViewSourceListDeuda_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as ventaProductoModel).CantidadFaltante > 0;
        }
        void CollectionViewSourceFechas_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = (e.Item as ventaProductoModel).CantidadFaltante > 0;
        }
    }
}
