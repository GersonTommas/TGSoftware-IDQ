using IDQ.Domain.Models;
using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Views
{
    /// <summary>
    /// Interaction logic for ConsumosView.xaml
    /// </summary>
    public partial class ConsumosView : UserControl
    {
        #region Initialize
        public ConsumosView() { InitializeComponent(); }
        #endregion // Initialize


        #region Filter
        void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is fechaModel item)
            {
                e.Accepted = item.Fecha == DateTime.Today.ToString(@"yyyy/MM/dd") | item.ConsumosProductosPerFecha.Count > 0;
            }
        }
        #endregion // Filter
    }
}

