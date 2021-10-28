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
            if (sentProducto is not null)
            {
                _editProducto = sentProducto;

                newProducto.Activo = sentProducto.Activo;
                newProducto.Agregado = sentProducto.Agregado;
                newProducto.Codigo = sentProducto.Codigo;
                newProducto.Descripcion = sentProducto.Descripcion;
                newProducto.FechaModificado = sentProducto.FechaModificado;
                newProducto.Medida = sentProducto.Medida;
                newProducto.PrecioActual = sentProducto.PrecioActual;
                newProducto.PrecioIngreso = sentProducto.PrecioIngreso;
                newProducto.Stock = sentProducto.Stock;
                newProducto.StockInicial = sentProducto.StockInicial;
                newProducto.Tag = sentProducto.Tag;
                
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
                if (compareProductCodigo is null || compareProductDescripcion is null || compareProductCodigo.Id == _editProducto.Id || compareProductDescripcion.Id == _editProducto.Id)
                {
                    _editProducto.Activo = newProducto.Activo;
                    _editProducto.Codigo = newProducto.Codigo;
                    _editProducto.Descripcion = newProducto.Descripcion;
                    _editProducto.FechaModificado = newProducto.FechaModificado;
                    _editProducto.PrecioActual = newProducto.PrecioActual;
                    _editProducto.Tag = newProducto.Tag;
                    _editProducto.Medida = newProducto.Medida;

                    _ = context.globalDb.SaveChanges();
                    Shared.GlobalErrors.Guardado();

                    Shared.Navigators.ContentTopNavigator.updateNavigator(null);
                }
                else { Shared.GlobalErrors.Existencia(); }
            }
            else
            {
                if (compareProductCodigo is not null || compareProductDescripcion is not null) { Shared.GlobalErrors.Existencia(); }
                else
                {
                    newProducto.Stock = newProducto.StockInicial;
                    _ = dataService.Create(newProducto);

                    Shared.Navigators.ContentTopNavigator.updateNavigator(null);
                }
            }
        }

        bool checkGuardar()
        {
            try
            {
                if (ProductoTagMedidaNavigator.CurrentViewModel is null && !string.IsNullOrWhiteSpace(newProducto.Codigo) && !string.IsNullOrWhiteSpace(newProducto.Descripcion) && newProducto.Tag is not null && newProducto.Medida is not null)
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


        #region Commands

        //MusicaigoExiste(); } else { Shared.GlobalVars.nextTarget(parameter); } });

        public Command controlGuardarCommand => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar());

        public Command controlCommandNewTag => new Command(
            (object parameter) => { Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(new tagNewEditViewModel(newProducto)); },
            (object parameter) => ProductoTagMedidaNavigator.CurrentViewModel is null);

        public Command controlCommandNewMedida => new Command(
            (object parameter) => { Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(new medidaNewEditViewModel(newProducto)); },
            (object parameter) => ProductoTagMedidaNavigator.CurrentViewModel is null);

        public Command cancelCommand => new Command(
            (object parameter) => { Shared.Navigators.ContentTopNavigator.updateNavigator(null); },
            (object parameter) => ProductoTagMedidaNavigator.CurrentViewModel is null);
        #endregion // Commands
    }
}
