using IDQ.Domain.Base;
using System;
using System.Windows;

namespace IDQ.WPF.Base
{
    public class ViewModelBase : PropertyChangedBase
    {
        public Window thisWindow;

        public string globalStringFecha = DateTime.Today.ToString(@"yyyy/MM/dd");
        public string globalStringHora = DateTime.Now.ToString(@"HH:mm:ss");

        public virtual void setInitialize(Window sentWindow)
        {
            thisWindow = sentWindow;
        }

        public virtual Command bNextControl => new Command((object parameter) => { Shared.GlobalVars.nextTarget(parameter); });
    }
}
