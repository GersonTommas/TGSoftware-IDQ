using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class tagNewEditViewModel : Base.ViewModelBase
    {
        public INavigator Navigator { get; set; }

        public tagNewEditViewModel() { }

        public void setInitialize(tagModel sentTag)
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


        bool _isEdit;
        public bool isEdit { get => _isEdit; set { if (SetProperty(ref _isEdit, value)) { OnPropertyChanged(); } } }

        public string groupBoxTitle => isEdit ? "ID: " + _editTag.Id : "Nuevo Tag";

        tagModel _editTag;

        tagModel _newTag = new tagModel() { Activo = true };
        public tagModel newTag { get => _newTag; set { if (SetProperty(ref _newTag, value)) { OnPropertyChanged(); } } }


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

                    //thisWindow.DialogResult = true;
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

        public Command guardarTagCommand => new Command(
            (object parameter) => helperGuardar(),
            (object parameter) => checkGuardar());
    }
}
