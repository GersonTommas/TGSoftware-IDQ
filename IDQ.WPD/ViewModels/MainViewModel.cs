using IDQ.Domain.Models;
using IDQ.Domain.Services;
using IDQ.EntityFramework;
using IDQ.EntityFramework.Services;
using IDQ.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.WPF.ViewModels
{
    public class MainViewModel : Base.ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Productos);
        }

        public static Command comTest => new((object parameter) =>
        {
            IDataService<cajaModel> cajaActualService = new GenericDataService<cajaModel>();
            cajaModel cajaActual = cajaActualService.Get(1).Result;
            cajaActual.CajaActual -= 30;
            cajaActualService.Update(cajaActual.Id, cajaActual);

        });
        //public static Command darkCommand => new((object parameter) => { Properties.Settings.Default.skinTheme = Skin.Dark.ToString(); Properties.Settings.Default.Save(); });
        //public static Command lightCommand => new((object parameter) => { Properties.Settings.Default.skinTheme = Skin.Light.ToString(); Properties.Settings.Default.Save(); });
    }
}
