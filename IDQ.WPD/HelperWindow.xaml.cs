using IDQ.Domain.Models;
using IDQ.WPF.Enumerators;
using IDQ.WPF.States.Navigators;
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
using System.Windows.Shapes;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for HelperWindow.xaml
    /// </summary>
    public partial class HelperWindow : Window
    {
        public HelperWindow(ProductosEnum sentEnum, productoModel sentProducto = null)
        {
            InitializeComponent(); HelperWindowViewModel dtContext = DataContext as HelperWindowViewModel; dtContext.setInitialize(this);

            if (sentEnum == ProductosEnum.New)
            {
                dtContext.initializeHelperNewProducto(sentEnum);
            }
            else
            {
                if (sentProducto == null) { Close(); }
                else
                {
                    dtContext.initializeHelperProducto(sentEnum, sentProducto);
                }
            }
        }
    }

    class HelperWindowViewModel : Base.ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();


        public HelperWindowViewModel() { }

        public void initializeHelperNewProducto(ProductosEnum sentEnum)
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(sentEnum);
            productoNewEditViewModel dtContext = Navigator.CurrentViewModel as productoNewEditViewModel;
            if (sentEnum == ProductosEnum.New)
            {
                dtContext.setInitialize(thisWindow);
            }
        }
        public void initializeHelperProducto(ProductosEnum sentEnum, productoModel sentProducto)
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(sentEnum);
            if (sentEnum == ProductosEnum.Stock)
            {
                (Navigator.CurrentViewModel as stockEditViewModel).setInitialize(sentProducto, thisWindow);
            }
            else if (sentEnum == ProductosEnum.Edit)
            {
                (Navigator.CurrentViewModel as productoNewEditViewModel).setInitialize(sentProducto, thisWindow);
            }
        }

        public Command cancelCommand => new Command((object parameter) => thisWindow.DialogResult = false);
    }
}
