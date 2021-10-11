using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
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
            if (sentMedida != null)
            {
                _editMedida = sentMedida;
                newMedida = new medidaModel()
                {
                    Activo = sentMedida.Activo,
                    Medida = sentMedida.Medida,
                    Tipo = sentMedida.Tipo
                };
            }
        }
        #endregion // Initialize


        #region Variables
        public string groupBoxTitle => _editMedida != null ? "ID: " + _editMedida.Id : "Nueva Medida";

        readonly productoModel _newEditProducto;
        readonly medidaModel _editMedida;

        public medidaModel newMedida { get; } = new medidaModel() { Activo = true };
        #endregion // Variables


        #region Helpers
        void helperGuardarNuevo()
        {
            medidaModel _compareMedida = findCompare();

            if (_compareMedida == null)
            {
                _ = context.globalDb.medidas.Add(newMedida);
                _ = context.globalDb.SaveChanges();
                Shared.GlobalVars.messageError.Guardado();

                if (_newEditProducto != null) { _newEditProducto.Medida = newMedida; Shared.Navigators.UpdateProductoSlider(null); }
                else { Shared.Navigators.UpdateEditorSlider(null); }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        void helperGuardarEdit()
        {
            medidaModel _compareMedida = findCompare();

            if (_compareMedida == null || _compareMedida.Id == _editMedida.Id)
            {
                _editMedida.Activo = newMedida.Activo; _editMedida.Medida = newMedida.Medida;
                _ = context.globalDb.SaveChanges();
                Shared.GlobalVars.messageError.Guardado();

                if (_newEditProducto != null) { Shared.Navigators.UpdateProductoSlider(null); }
                else { Shared.Navigators.UpdateEditorSlider(null); }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        medidaModel findCompare()
        {
            medidaModel _result = null;

            newMedida.Medida = newMedida.Medida.Trim();

            try { _result = context.globalDb.medidas.Single(x => x.Medida.ToLower() == newMedida.Medida.ToLower() && x.Tipo == newMedida.Tipo); } catch { }

            return _result;
        }

        bool checkGuardar => !string.IsNullOrWhiteSpace(newMedida.Medida) && newMedida.Medida.Length > 0 && newMedida.Tipo > 0;
        #endregion // Helpers


        #region Commands
        public Command ControlCommandCancelar => new Command((object parameter) => Shared.Navigators.UpdateProductoSlider(null));

        public Command guardarCommand => new Command(
            (object parameter) => { if (_editMedida != null) { helperGuardarEdit(); } else { helperGuardarNuevo(); } },
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
