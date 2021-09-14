using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System.Linq;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class tagNewEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        public INavigator Navigator { get; set; }

        public tagNewEditViewModel() { }
        
        public tagNewEditViewModel(tagModel sentTag)
        {
            if (sentTag != null)
            {
                _editTag = sentTag;
                newTag = new tagModel()
                {
                    Activo = sentTag.Activo,
                    Minimo = sentTag.Minimo,
                    Tag = sentTag.Tag
                };
                isEdit = true;
            }
        }
        #endregion // Initialize


        #region Variables
        bool _isEdit;
        public bool isEdit { get => _isEdit; set { if (SetProperty(ref _isEdit, value)) { OnPropertyChanged(); } } }

        public string groupBoxTitle => isEdit ? "ID: " + _editTag.Id : "Nuevo Tag";

        readonly tagModel _editTag;

        public tagModel newTag { get; } = new tagModel() { Activo = true };
        #endregion // Variables


        #region Helpers
        void helperGuardar()
        {
            tagModel compareTag = null;
            if (!string.IsNullOrWhiteSpace(newTag.Tag)) { newTag.Tag = newTag.Tag.Trim(); }

            try { compareTag = context.globalDb.tags.Single(x => x.Tag.ToLower() == newTag.Tag.ToLower() && x.Minimo == newTag.Minimo); } catch { }

            if (isEdit)
            {
                if (compareTag == null || compareTag.Id == newTag.Id)
                {
                    _editTag.Activo = newTag.Activo;
                    _editTag.Minimo = newTag.Minimo;
                    _editTag.Tag = newTag.Tag;

                    _ = context.globalDb.SaveChanges();

                    Shared.Navigators.UpdateProductoSlider(null);
                }
                else { Shared.GlobalVars.messageError.Existencia(); }
            }
            else if (compareTag == null)
            {
                context.globalDb.tags.Local.Add(newTag);
                _ = context.globalDb.SaveChanges();

                if (Navigator != null) { Navigator.CurrentViewModel = null; }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        bool checkGuardar()
        {
            try { if (newTag.Minimo >= 0 && !string.IsNullOrWhiteSpace(newTag.Tag) && newTag.Tag.Length > 0) { return true; } } catch { }
            return false;
        }
        #endregion // Helpers


        #region Commands
        public Command ControlCommandCancelar => new Command((object parameter) => { Shared.Navigators.UpdateProductoSlider(null); });

        public Command guardarTagCommand => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar());
        #endregion // Commands
    }
}
