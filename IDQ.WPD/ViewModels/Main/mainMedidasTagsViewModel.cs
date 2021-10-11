﻿using IDQ.Domain.Models;
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

        public medidaModel selectedMedida { get; set; }
        public tagModel selectedTag { get; set; }
        #endregion // Variables


        #region Helpers
        void helperNewMedida()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.medidaNewEditViewModel());
        }

        void helperEditMedida()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.medidaNewEditViewModel(selectedMedida));
        }

        void helperNewTag()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.tagNewEditViewModel());
        }

        void helperEditTag()
        {
            Shared.Navigators.UpdateEditorSlider(new Helpers.tagNewEditViewModel(selectedTag));
        }

        bool checkEditMedida => selectedMedida != null;

        bool checkEditTag => selectedTag != null;
        #endregion // Helpers


        #region Commands
        public Command controlCommandNuevaMedida => new Command((object parameter) => helperNewMedida());

        public Command controlCommandEditarMedida => new Command(
            (object parameter) => helperEditMedida(),
            (object parameter) => checkEditMedida);

        public Command controlCommandNuevoTag => new Command((object parameter) => helperNewTag());

        public Command controlCommandEditarTag => new Command(
            (object parameter) => helperEditTag(),
            (object parameter) => checkEditTag);
        #endregion // Commands
    }
}
