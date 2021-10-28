using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;
using System.Linq;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class medidaNewEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        public medidaNewEditViewModel() { }

        public medidaNewEditViewModel(productoModel sentProducto) { _newEditProducto = sentProducto; }

        public medidaNewEditViewModel(medidaModel sentMedida)
        {
            if (sentMedida is not null)
            {
                _editMedida = sentMedida;
                newMedida = new medidaModel()
                {
                    Activo = sentMedida.Activo,
                    Medida = sentMedida.Medida,
                    TipoSelector = sentMedida.TipoSelector
                };
            }
        }
        #endregion // Initialize


        #region Variables
        public string groupBoxTitle => _editMedida is not null ? "ID: " + _editMedida.Id : "Nueva Medida";

        readonly productoModel _newEditProducto;
        readonly medidaModel _editMedida;

        public medidaModel newMedida { get; } = new medidaModel() { Activo = true };

        public ObservableCollection<medidaSelectorModel> CollectionSourceTipoSelector => context.globalDb.medidaSelector.Local.ToObservableCollection();
        #endregion // Variables


        #region Helpers
        void helperGuardarNuevo()
        {
            medidaModel _compareMedida = findCompare();

            if (_compareMedida is null)
            {
                _ = context.globalDb.medidas.Add(newMedida);
                _ = context.globalDb.SaveChanges();
                Shared.GlobalErrors.Guardado();

                if (_newEditProducto is not null) { _newEditProducto.Medida = newMedida; Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(null); }
                else { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }
            }
            else { Shared.GlobalErrors.Existencia(); }
        }

        void helperGuardarEdit()
        {
            medidaModel _compareMedida = findCompare();

            if (_compareMedida is null || _compareMedida.Id == _editMedida.Id)
            {
                _editMedida.Activo = newMedida.Activo; _editMedida.Medida = newMedida.Medida;
                _ = context.globalDb.SaveChanges();
                Shared.GlobalErrors.Guardado();

                if (_newEditProducto is not null) { Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(null); }
                else { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }
            }
            else { Shared.GlobalErrors.Existencia(); }
        }

        medidaModel findCompare()
        {
            medidaModel _result = null;

            newMedida.Medida = newMedida.Medida.Trim();

            try { _result = context.globalDb.medidas.Single(x => x.Medida.ToLower() == newMedida.Medida.ToLower() && x.TipoSelector.Tipo == newMedida.TipoSelector.Tipo); } catch { }

            return _result;
        }

        bool checkGuardar => !string.IsNullOrWhiteSpace(newMedida.Medida) && newMedida.Medida.Length > 0 && newMedida.TipoSelector is not null;
        #endregion // Helpers


        #region Commands
        public Command ControlCommandCancelar => new Command((object parameter) => { if (Shared.Navigators.ProductoTagMedidaNavigator.CurrentViewModel is not null) { Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(null); } else { Shared.Navigators.ContentTopNavigator.updateNavigator(null); } });

        public Command guardarCommand => new Command(
            (object parameter) => { if (_editMedida is not null) { helperGuardarEdit(); } else { helperGuardarNuevo(); } },
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
