using IDQ.Domain.Models;
using IDQ.Domain.Services;
using IDQ.EntityFramework;
using IDQ.EntityFramework.Services;
using IDQ.WPF.States.Navigators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class productoNewEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        public productoNewEditViewModel() { }

        public productoNewEditViewModel(productoModel sentProducto)
        {
            if (sentProducto != null)
            {
                _editProducto = sentProducto;

                newProducto.Activo = sentProducto.Activo;
                newProducto.Agregado = sentProducto.Agregado;
                newProducto.Codigo = sentProducto.Codigo;
                newProducto.Descripcion = sentProducto.Descripcion;
                newProducto.FechaModificado = sentProducto.FechaModificado;
                newProducto.FechaModificadoID = sentProducto.FechaModificadoID;
                newProducto.Medida = sentProducto.Medida;
                newProducto.MedidaID = sentProducto.MedidaID;
                newProducto.PrecioActual = sentProducto.PrecioActual;
                newProducto.PrecioIngreso = sentProducto.PrecioIngreso;
                newProducto.Stock = sentProducto.Stock;
                newProducto.StockInicial = sentProducto.StockInicial;
                newProducto.Tag = sentProducto.Tag;
                newProducto.TagID = sentProducto.TagID;
                
                isEdit = true;
            }
        }
        public productoNewEditViewModel(string sentCodigo)
        {
            if (!string.IsNullOrWhiteSpace(sentCodigo))
            {
                newProducto.Codigo = sentCodigo.Trim();
                newProducto.Activo = true;
                isForceNewCode = true;
            }
        }
        #endregion // Initialize


        #region Animation
        public INavigator ProductoTagMedidaNavigator => Shared.Navigators.ProductoTagMedidaNavigator;

        bool _isAnimationLoading;

        bool _startAnimation;
        public bool startAnimation { get => _startAnimation; set { if (SetProperty(ref _startAnimation, value)) { OnPropertyChanged(); } } }

        bool _isEditBarEnabled;
        public bool isEditBarEnabled { get => _isEditBarEnabled; set { if (SetProperty(ref _isEditBarEnabled, value)) { OnPropertyChanged(); } } }

        public async void updateEditorSlider(Base.ViewModelBase sentViewModel)
        {
            if (_isAnimationLoading == false)
            {
                _isAnimationLoading = true;

                await PutTaskDelay(sentViewModel, sentViewModel is not null);
            }
        }
        async Task PutTaskDelay(Base.ViewModelBase sentObject, bool sentBool)
        {
            startAnimation = sentBool;

            if (!sentBool) { await Task.Delay(900); isEditBarEnabled = sentBool; }

            Shared.Navigators.ProductoTagMedidaNavigator.CurrentViewModel = sentObject;

            if (sentBool) { isEditBarEnabled = sentBool; await Task.Delay(900); }

            _isAnimationLoading = false;
        }
        #endregion // Animation


        #region Variables
        public ObservableCollection<tagModel> sourceCollectionTags => context.globalAllTags;
        public ObservableCollection<medidaModel> sourceCollectionMedidas => context.globalAllMedidas;
        public string groupBoxTitle => isEdit ? "ID: " + _editProducto.Id : "Nuevo Producto";


        bool _isForceNewCode;
        public bool isForceNewCode { get => _isForceNewCode; set { if (SetProperty(ref _isForceNewCode, value)) { OnPropertyChanged(); } } }
        bool _isEdit;
        public bool isEdit { get => _isEdit; set { if (SetProperty(ref _isEdit, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(groupBoxTitle)); } } }
        bool _isMaster;
        public bool isMaster { get => _isMaster; set { if (SetProperty(ref _isMaster, value)) { OnPropertyChanged(); } } }

        readonly productoModel _editProducto;

        productoModel _newProducto = new productoModel() { Activo = true };
        public productoModel newProducto { get => _newProducto; set { if (SetProperty(ref _newProducto, value)) { OnPropertyChanged(); } } }

        string _strNewCode;
        public string strNewCode { get => _strNewCode; set { if (SetProperty(ref _strNewCode, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Helpers
        void helperGuardar()
        {

            IDataService<productoModel> dataService = new GenericDataService<productoModel>();

            productoModel compareProductCodigo = null;
            productoModel compareProductDescripcion = null;

            if (!string.IsNullOrWhiteSpace(newProducto.Codigo)) { newProducto.Codigo = newProducto.Codigo.Trim(); }
            if (!string.IsNullOrWhiteSpace(newProducto.Descripcion)) { newProducto.Descripcion = newProducto.Descripcion.Trim(); }

            try { compareProductCodigo = context.globalDb.productos.Single(x => x.Codigo.ToLower() == newProducto.Codigo.ToLower()); } catch { }
            try { compareProductDescripcion = context.globalDb.productos.Single(x => x.Descripcion.ToLower() == newProducto.Descripcion.ToLower()); } catch { }

            if (isEdit)
            {
                if (compareProductCodigo == null || compareProductDescripcion == null || compareProductCodigo.Id == _editProducto.Id || compareProductDescripcion.Id == _editProducto.Id)
                {
                    _editProducto.Activo = newProducto.Activo;
                    _editProducto.Codigo = newProducto.Codigo;
                    _editProducto.Descripcion = newProducto.Descripcion;
                    _editProducto.FechaModificado = newProducto.FechaModificado;
                    _editProducto.PrecioActual = newProducto.PrecioActual;
                    _editProducto.TagID = newProducto.Tag.Id;
                    _editProducto.Tag = newProducto.Tag;
                    _editProducto.MedidaID = newProducto.Medida.Id;
                    _editProducto.Medida = newProducto.Medida;

                    _ = context.globalDb.SaveChanges();
                    Shared.GlobalVars.messageError.Guardado();

                    Shared.Navigators.UpdateEditorSlider(null);
                }
                else { Shared.GlobalVars.messageError.Existencia(); }
            }
            else
            {
                if (compareProductCodigo != null || compareProductDescripcion != null) { Shared.GlobalVars.messageError.Existencia(); }
                else
                {
                    newProducto.Stock = newProducto.StockInicial;
                    newProducto.TagID = newProducto.Tag.Id;
                    newProducto.MedidaID = newProducto.Medida.Id;
                    _ = dataService.Create(newProducto);

                    Shared.Navigators.UpdateEditorSlider(null);
                }
            }
        }

        bool checkGuardar()
        {
            try
            {
                if (ProductoTagMedidaNavigator.CurrentViewModel == null && !string.IsNullOrWhiteSpace(newProducto.Codigo) && !string.IsNullOrWhiteSpace(newProducto.Descripcion) && newProducto.Tag != null && newProducto.Medida != null)
                {
                    if (newProducto.Codigo.Length > 0 && newProducto.Descripcion.Length > 0 && newProducto.Medida.Id > 0 && newProducto.PrecioActual > 0)
                    { return true; }
                }
            }
            catch { }
            return false;
        }

        bool checkCodeDuplicate()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(newProducto.Codigo))
                {
                    try { newProducto.Codigo = newProducto.Codigo.Trim(); } catch { }
                    productoModel compareProductCodigo = context.globalDb.productos.Single(x => x.Codigo.ToLower() == newProducto.Codigo.ToLower());
                    return !isEdit || compareProductCodigo.Id != _editProducto.Id;
                }
                else { return false; }
            }
            catch { return false; }
        }
        #endregion // Helpers


        #region CommandsMusicaigoExiste(); } else { Shared.GlobalVars.nextTarget(parameter); } });

        public Command controlGuardarCommand => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar());

        public Command controlCommandNewTag => new Command(
            (object parameter) => { Shared.Navigators.UpdateProductoSlider(new tagNewEditViewModel(newProducto)); },
            (object parameter) => ProductoTagMedidaNavigator.CurrentViewModel == null);

        public Command controlCommandNewMedida => new Command(
            (object parameter) => { Shared.Navigators.UpdateProductoSlider(new medidaNewEditViewModel(newProducto)); },
            (object parameter) => ProductoTagMedidaNavigator.CurrentViewModel == null);

        public Command cancelCommand => new Command(
            (object parameter) => { Shared.Navigators.UpdateEditorSlider(null); },
            (object parameter) => ProductoTagMedidaNavigator.CurrentViewModel == null);
        #endregion // Commands
    }
}
