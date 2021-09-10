using IDQ.Domain.Models;
using IDQ.EntityFramework;
using IDQ.WPF.States.Navigators;
using System;

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
            _ = context.globalDb.fechas.Add(new fechaModel { Fecha = DateTime.Today.ToString(@"yyyy/MM/dd") });
            context.globalDb.SaveChanges();

        });
        //public static Command darkCommand => new((object parameter) => { Properties.Settings.Default.skinTheme = Skin.Dark.ToString(); Properties.Settings.Default.Save(); });
        //public static Command lightCommand => new((object parameter) => { Properties.Settings.Default.skinTheme = Skin.Light.ToString(); Properties.Settings.Default.Save(); });
    }
}
