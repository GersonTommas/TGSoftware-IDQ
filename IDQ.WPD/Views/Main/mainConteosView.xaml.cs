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

namespace IDQ.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for mainConteosView.xaml
    /// </summary>
    public partial class mainConteosView : UserControl
    {
        public mainConteosView()
        {
            InitializeComponent();
        }

        void CollectionViewSourceFechas_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is fechaModel item)
            {
                e.Accepted = item.Fecha == DateTime.Today.ToString(@"yyyy/MM/dd") | item.ConteosPerFecha.Count > 0;
            }
        }
    }
}
