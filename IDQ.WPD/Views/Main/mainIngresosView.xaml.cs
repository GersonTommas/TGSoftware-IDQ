using IDQ.Domain.Models;
using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace IDQ.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for mainIngresosView.xaml
    /// </summary>
    public partial class mainIngresosView : UserControl
    {
        #region Initialize
        public mainIngresosView() { InitializeComponent(); }
        #endregion // Initialize


        #region Filters
        void CollectionViewSource_Filter(object sender, FilterEventArgs e)
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
        #endregion // Filters
    }
}
