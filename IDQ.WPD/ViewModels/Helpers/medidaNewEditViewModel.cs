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
                isEdit = true;
            }
        }
        #endregion // Initialize


        #region Variables
        bool _isEdit;
        public bool isEdit { get => _isEdit; set { if (SetProperty(ref _isEdit, value)) { OnPropertyChanged(); } } }

        public string groupBoxTitle => isEdit ? "ID: " + _editMedida.Id : "Nueva Medida";

        readonly medidaModel _editMedida;

        public medidaModel newMedida { get; } = new medidaModel() { Activo = true };
        #endregion // Variables


        #region Helpers
        void helperGuardar()
        {
            medidaModel compareMedida = null;
            if (!string.IsNullOrWhiteSpace(newMedida.Medida)) { newMedida.Medida = newMedida.Medida.Trim(); }

            try { compareMedida = context.globalDb.medidas.Single(x => x.Medida.ToLower() == newMedida.Medida.ToLower() && x.Tipo == newMedida.Tipo); } catch { }

            if (isEdit)
            {
                if (compareMedida == null || compareMedida.Id == _editMedida.Id)
                {
                    _editMedida.Activo = newMedida.Activo; _editMedida.Medida = newMedida.Medida;
                    _ = context.globalDb.SaveChanges();
                    Shared.GlobalVars.messageError.Guardado();

                    Shared.Navigators.UpdateProductoSlider(null);
                    //thisWindow.DialogResult = true;
                }
                else { Shared.GlobalVars.messageError.Existencia(); }
            }
            else if (compareMedida == null)
            {
                _ = context.globalDb.medidas.Add(newMedida);
                _ = context.globalDb.SaveChanges();
                Shared.GlobalVars.messageError.Guardado();

                Shared.Navigators.UpdateProductoSlider(null);
                //thisWindow.DialogResult = true;
                //if (Navigator != null) { Navigator.CurrentViewModel = null; }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        bool checkGuardar => !string.IsNullOrWhiteSpace(newMedida.Medida) && newMedida.Medida.Length > 0 && newMedida.Tipo > 0;
        #endregion // Helpers


        #region Commands
        public Command ControlCommandCancelar => new Command((object parameter) => Shared.Navigators.UpdateProductoSlider(null));

        public Command guardarCommand => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
