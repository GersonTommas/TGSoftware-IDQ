using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class productoNewEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator Navigator { get; } = new Navigator();

        public productoNewEditViewModel()
        {
            newProducto.Activo = true;
        }
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

        public void setInitialize(productoModel sentProducto, Window sentWindow)
        {
            if (sentWindow != null) { thisWindow = sentWindow; }
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
        public void setInitialize(string sentCodigo)
        {
            if (!string.IsNullOrWhiteSpace(sentCodigo))
            {
                isForceNewCode = true;
                newProducto.Codigo = sentCodigo;
            }
        }
        #endregion // Initialize


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

        productoModel _editProducto;

        productoModel _newProducto = new productoModel();
        public productoModel newProducto { get => _newProducto; set { if (SetProperty(ref _newProducto, value)) { OnPropertyChanged(); } } }

        string _strNewCode;
        public string strNewCode { get => _strNewCode; set { if (SetProperty(ref _strNewCode, value)) { OnPropertyChanged(); } } }
        #endregion // Variables


        #region Helpers
        void helperGuardar()
        {
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

                    Shared.GlobalVars.UpdateEditorSlider(null);
                    //thisWindow.DialogResult = true;
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
                    
                    productoModel tempProducto = context.globalDb.productos.CreateProxy();
                    tempProducto.Activo = newProducto.Activo;
                    tempProducto.Agregado = newProducto.Agregado;
                    tempProducto.Codigo = newProducto.Codigo;
                    tempProducto.Descripcion = newProducto.Descripcion;
                    tempProducto.FechaModificado = newProducto.FechaModificado;
                    tempProducto.FechaModificadoID = newProducto.FechaModificadoID;
                    tempProducto.Medida = newProducto.Medida;
                    tempProducto.MedidaID = newProducto.MedidaID;
                    tempProducto.PrecioActual = newProducto.PrecioActual;
                    tempProducto.PrecioIngreso = newProducto.PrecioIngreso;
                    tempProducto.Stock = newProducto.Stock;
                    tempProducto.StockInicial = newProducto.StockInicial;
                    tempProducto.Tag = newProducto.Tag;
                    tempProducto.TagID = newProducto.TagID;
                    
                    context.globalDb.productos.Local.Add(tempProducto);
                    _ = context.globalDb.SaveChanges();

                    Shared.GlobalVars.UpdateEditorSlider(null);
                    //thisWindow.DialogResult = true;
                }
            }
        }

        bool checkGuardar()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(newProducto.Codigo) && !string.IsNullOrWhiteSpace(newProducto.Descripcion) && newProducto.Tag != null && newProducto.Medida != null)
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
            (object parameter) => { Navigator.CurrentViewModel = new tagNewEditViewModel(Navigator); },
            (object parameter) => Navigator.CurrentViewModel == null);

        public Command controlCommandNewMedida => new Command(
            (object parameter) => { Navigator.CurrentViewModel = new medidaNewEditViewModel(Navigator); },
            (object parameter) => Navigator.CurrentViewModel == null);

        public Command cancelCommand => new Command(
            (object parameter) => { Shared.GlobalVars.UpdateEditorSlider(null); /*if (Navigator.CurrentViewModel != null) { Navigator.CurrentViewModel = null; } else { thisWindow.DialogResult = false; }*/ });
        #endregion // Commands
    }
}
