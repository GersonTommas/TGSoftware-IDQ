using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class productoNewEditViewModel : Base.ViewModelBase
    {
        public INavigator Navigator { get; } = new Navigator();

        public productoNewEditViewModel()
        {

        }

        public void setInitialize(productoModel sentProducto, Window sentWindow)
        {
            if (sentWindow != null) { thisWindow = sentWindow; }
            if (sentProducto != null)
            {
                _editProducto = sentProducto;

                newProducto = new productoModel()
                {
                    Activo = sentProducto.Activo,
                    Agregado = sentProducto.Agregado,
                    Codigo = sentProducto.Codigo,
                    Descripcion = sentProducto.Descripcion,
                    FechaModificado = sentProducto.FechaModificado,
                    FechaModificadoID = sentProducto.FechaModificadoID,
                    Medida = sentProducto.Medida,
                    MedidaID = sentProducto.MedidaID,
                    PrecioActual = sentProducto.PrecioActual,
                    PrecioIngreso = sentProducto.PrecioIngreso,
                    Stock = sentProducto.Stock,
                    StockInicial = sentProducto.StockInicial,
                    Tag = sentProducto.Tag,
                    TagID = sentProducto.TagID
                };

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

        bool _isForceNewCode;
        public bool isForceNewCode { get => _isForceNewCode; set { if (SetProperty(ref _isForceNewCode, value)) { OnPropertyChanged(); } } }
        bool _isEdit;
        public bool isEdit { get => _isEdit; set { if (SetProperty(ref _isEdit, value)) { OnPropertyChanged(); OnPropertyChanged(nameof(groupBoxTitle)); } } }
        bool _isMaster;
        public bool isMaster { get => _isMaster; set { if (SetProperty(ref _isMaster, value)) { OnPropertyChanged(); } } }

        productoModel _editProducto;

        productoModel _newProducto = new productoModel() { Activo = true };
        public productoModel newProducto { get => _newProducto; set { if (SetProperty(ref _newProducto, value)) { OnPropertyChanged(); } } }


        string _strNewCode;
        public string strNewCode { get => _strNewCode; set { if (SetProperty(ref _strNewCode, value)) { OnPropertyChanged(); } } }


        public string groupBoxTitle => isEdit ? "ID: " + _editProducto.Id : "Nuevo Producto";



        public ObservableCollection<tagModel> sourceCollectionTags => context.globalAllTags;
        public ObservableCollection<medidaModel> sourceCollectionMedidas => context.globalAllMedidas;


        public Command controlCommandNewTag => new Command(
            (object parameter) => { Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Tags); (Navigator.CurrentViewModel as tagNewEditViewModel).Navigator = Navigator; },
            (object parameter) => Navigator.CurrentViewModel == null);

        public Command controlCommandNewMedida => new Command(
            (object parameter) => { Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Medidas); (Navigator.CurrentViewModel as medidaNewEditViewModel).Navigator = Navigator; },
            (object parameter) => Navigator.CurrentViewModel == null);

        public Command cancelCommand => new Command(
            (object parameter) => { if (Navigator.CurrentViewModel != null) { Navigator.CurrentViewModel = null; } else { thisWindow.DialogResult = false; } });


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

                    thisWindow.DialogResult = true;
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

                    _ = context.globalDb.productos.Add(newProducto);
                    _ = context.globalDb.SaveChanges();

                    thisWindow.DialogResult = true;
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



        #region Commands
        public Command textBoxCommandCodigoDuplicado => new Command((object parameter) => { if (checkCodeDuplicate()) { Shared.GlobalVars.messageError.CodigoExiste(); } else { Shared.GlobalVars.nextTarget(parameter); } });

        public Command controlGuardarCommand => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar());
        #endregion // Commands
    }
}
