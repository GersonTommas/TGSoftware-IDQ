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
    /// Interaction logic for mainIngresosView.xaml
    /// </summary>
    public partial class mainIngresosView : UserControl
    {
        public mainIngresosView()
        {
            InitializeComponent();
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is fechaModel item)
            {
                if (item.Fecha == DateTime.Today.ToString(@"yyyy/MM/dd") | item.IngresosPerFecha.Count > 0)
                { e.Accepted = true; }
                else
                {
                    e.Accepted = false;
                }
            }
        }
    }
}
