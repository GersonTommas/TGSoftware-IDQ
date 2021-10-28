using IDQ.Domain.Base;
using System;
using System.Windows;

namespace IDQ.WPF.Base
{
    public class ViewModelBase : PropertyChangedBase
    {
        #region Properties
        public Window thisWindow;

        public bool localDebug => Shared.GlobalVars.globalDebug;

        public string globalStringFecha = DateTime.Today.ToString(@"yyyy/MM/dd");
        public string globalStringHora = DateTime.Now.ToString(@"HH:mm:ss");
        #endregion // Properties



        #region Voids
        public virtual void setInitialize(Window sentWindow) { thisWindow = sentWindow; }

        internal virtual bool bCompareStrings(string firstString, string secondString) { return string.Equals(firstString, secondString, StringComparison.OrdinalIgnoreCase); }
        #endregion // Voids



        #region Commands
        public virtual Command bNextControl => new Command((object parameter) => { Shared.GlobalVars.nextTarget(parameter); });
        #endregion // Commands
    }
}
