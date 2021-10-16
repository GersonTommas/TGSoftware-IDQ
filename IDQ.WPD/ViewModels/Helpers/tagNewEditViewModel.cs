using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System.Linq;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class tagNewEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        public tagNewEditViewModel() { }

        public tagNewEditViewModel(productoModel sentProducto) { _newProducto = sentProducto; }
        
        public tagNewEditViewModel(tagModel sentTag)
        {
            if (sentTag is not null)
            {
                _editTag = sentTag;
                newTag = new tagModel()
                {
                    Activo = sentTag.Activo,
                    Minimo = sentTag.Minimo,
                    Tag = sentTag.Tag
                };
            }
        }
        #endregion // Initialize


        #region Variables
        public string groupBoxTitle => _editTag is not null ? "ID: " + _editTag.Id : "Nuevo Tag";

        readonly productoModel _newProducto;
        readonly tagModel _editTag;

        public tagModel newTag { get; } = new tagModel() { Activo = true };
        #endregion // Variables


        #region Helpers
        void helperGuardarNuevo()
        {
            tagModel _compareTag = findCompare();

            if (_compareTag is null)
            {
                context.globalDb.tags.Local.Add(newTag);
                _ = context.globalDb.SaveChanges();

                if (_newProducto is not null) { _newProducto.Tag = newTag; Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(null); }
                else { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        void helperGuardarEdit()
        {
            tagModel _compareTag = findCompare();

            if (_compareTag is null || _compareTag.Id == _editTag.Id)
            {
                _editTag.Activo = newTag.Activo;
                _editTag.Minimo = newTag.Minimo;
                _editTag.Tag = newTag.Tag;

                _ = context.globalDb.SaveChanges();

                if (_newProducto is not null) { Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(null); }
                else { Shared.Navigators.ContentTopNavigator.updateNavigator(null); }
            }
            else { Shared.GlobalVars.messageError.Existencia(); }
        }

        tagModel findCompare()
        {
            tagModel _result = null;

            newTag.Tag = newTag.Tag.Trim();

            try { _result = context.globalDb.tags.Single(x => x.Tag.ToLower() == newTag.Tag.ToLower() && x.Minimo == newTag.Minimo); } catch { }

            return _result;
        }

        bool checkGuardar => newTag.Minimo >= 0 && !string.IsNullOrWhiteSpace(newTag.Tag) && newTag.Tag?.Length > 0;
        /*
        {
            try { if (newTag.Minimo >= 0 && !string.IsNullOrWhiteSpace(newTag.Tag) && newTag.Tag.Length > 0) { return true; } } catch { }
            return false;
        }*/
        #endregion // Helpers


        #region Commands
        public Command ControlCommandCancelar => new Command((object parameter) => { if (Shared.Navigators.ProductoTagMedidaNavigator.CurrentViewModel is not null) { Shared.Navigators.ProductoTagMedidaNavigator.updateNavigator(null); } else { Shared.Navigators.ContentTopNavigator.updateNavigator(null); } });

        public Command guardarTagCommand => new Command(
            (object parameter) => { if (_editTag is not null) { helperGuardarEdit(); } else { helperGuardarNuevo(); } },
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
