using IDQ.Domain.Models;
using IDQ.WPF.Enumerators;
using IDQ.WPF.States.Navigators;
using IDQ.WPF.ViewModels.Helpers;
using System.Windows;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for HelperWindow.xaml
    /// </summary>
    public partial class HelperWindow : Window
    {
        #region Initialize
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
        #endregion // Initialize
    }



    class HelperWindowViewModel : Base.ViewModelBase
    {
        #region Initialize
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
                //(Navigator.CurrentViewModel as stockEditViewModel).setInitialize(sentProducto, thisWindow);
            }
            else if (sentEnum == ProductosEnum.Edit)
            {
                //(Navigator.CurrentViewModel as productoNewEditViewModel).setInitialize(sentProducto, thisWindow);
            }
        }
        #endregion // Initialize


        #region Commands
        public Command cancelCommand => new Command((object parameter) => thisWindow.DialogResult = false);
        #endregion // Commands
    }
}
