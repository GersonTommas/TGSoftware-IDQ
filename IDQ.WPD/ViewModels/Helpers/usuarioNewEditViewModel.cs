using IDQ.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class usuarioNewEditViewModel : Base.ViewModelBase
    {
        #region Initialize
        readonly States.Navigators.INavigator thisNavigator;

        public usuarioNewEditViewModel() { }
        public usuarioNewEditViewModel(States.Navigators.INavigator sentNavigator)
        {
            thisNavigator = sentNavigator;
        }
        public usuarioNewEditViewModel(usuarioModel sentUsuario, States.Navigators.INavigator sentNavigator)
        {
            thisNavigator = sentNavigator;

            if (sentUsuario is not null)
            {
                _EditUsuario = sentUsuario;

                newUsuario = new usuarioModel()
                {
                    Activo = sentUsuario.Activo,
                    Apellido = sentUsuario.Apellido,
                    Contraseña = sentUsuario.Contraseña,
                    Detalle = sentUsuario.Detalle,
                    FechaDeIngreso = sentUsuario.FechaDeIngreso,
                    FechaSalida = sentUsuario.FechaSalida,
                    Nivel = sentUsuario.Nivel,
                    Nombre = sentUsuario.Nombre,
                    Resto = sentUsuario.Resto,
                    Usuario = sentUsuario.Usuario
                };
            }
        }
        #endregion // Initialize


        #region Variables
        readonly usuarioModel _EditUsuario;
        public usuarioModel newUsuario { get; } = new usuarioModel();

        public string groupTitle => _EditUsuario is not null ? "Editar Usuario ID: " + _EditUsuario.Id : "Nuevo Usuario";
        #endregion // Variables


        #region Helpers
        void helperGuardarNuevo()
        {
            Shared.Navigators.ContentTopNavigator.updateNavigator(null);
        }

        void helperGuardarEditado()
        {
            Shared.Navigators.ContentTopNavigator.updateNavigator(null);
        }

        bool checkGuardar => true;
        #endregion // Helpers


        #region Commands
        public Command buttonCommandGuardar => new Command(
            (object parameter) => { if (_EditUsuario is not null) { helperGuardarEditado(); } else { helperGuardarNuevo(); } },
            (object parameter) => checkGuardar);
        #endregion // Commands
    }
}
