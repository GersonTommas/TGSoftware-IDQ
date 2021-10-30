using IDQ.Domain.Models;
using IDQ.EntityFramework;
using System.Linq;

namespace IDQ.WPF.ViewModels.Helpers
{
    public class motivoNewViewModel : Base.ViewModelBase
    {
        #region Initialize
        public motivoNewViewModel() { }
        #endregion // Initialize



        #region Properties
        string _Motivo;
        public string Motivo { get => _Motivo; set { if (SetProperty(ref _Motivo, value)) { OnPropertyChanged(); } } }
        #endregion // Properties



        #region Commands
        public Command controlCommandGuardar => new Command(
            (object parameter) =>
            {
                Motivo = Motivo.Trim();
                if (!context.globalDb.retiroMotivos.Local.Any(x => bCompareStrings(x.Motivo, Motivo)))
                {
                    context.globalDb.retiroMotivos.Local.Add(new motivoRetiroModel() { Motivo = Motivo });
                    _ = context.globalDb.SaveChanges();

                    Shared.Navigators.RetiroMotivoNavigator.updateNavigator(null);
                }
                else
                {
                    Shared.GlobalErrors.Existencia();
                }
            },
            (object parameter) => !string.IsNullOrWhiteSpace(Motivo));
        #endregion // Commands
    }
}
