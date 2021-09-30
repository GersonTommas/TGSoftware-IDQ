using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Collections.ObjectModel;

namespace IDQ.WPF.ViewModels.Main
{
    public class mainMedidasTagsViewModel : Base.ViewModelBase
    {
        #region Initialize
        public mainMedidasTagsViewModel() { }
        #endregion // Initialize


        #region Variables
        public ObservableCollection<medidaModel> CollectionSourceMedidas => context.globalAllMedidas;
        public ObservableCollection<tagModel> CollectionSourceTags => context.globalAllTags;
        #endregion // Variables


        #region Helpers
        void helperNewMedida()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.medidaNewEditViewModel());
        }

        void helperEditMedida()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.medidaNewEditViewModel());
        }

        void helperNewTag()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.tagNewEditViewModel());
        }

        void helperEditTag()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.tagNewEditViewModel());
        }

        bool checkEditMedida => true;

        bool checkEditTag => true;
        #endregion // Helpers


        #region Commands
        public Command buttonCommandNewMedida => new Command((object parameter) => helperNewMedida());

        public Command buttonCommandEditMedida => new Command(
            (object parameter) => helperEditMedida(),
            (object parameter) => checkEditMedida);

        public Command buttonCommandNewTag => new Command((object parameter) => helperNewTag());

        public Command buttonCommandEditTag => new Command(
            (object parameter) => helperEditTag(),
            (object parameter) => checkEditTag);
        #endregion // Commands
    }
}
