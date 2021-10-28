using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace IDQ.WPF.Base
{
    public abstract class UserControlBase : UserControl, INotifyPropertyChanged
    {
        #region Properties
        public bool localDebug => Shared.GlobalVars.globalDebug;
        #endregion // Properties



        #region Commands
        public static Command bNextControl => new Command((object parameter) => { Shared.GlobalVars.nextTarget(parameter); });
        #endregion // Commands



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropChanged([CallerMemberName] string PropertyName = null)
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName)); }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string PropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) { return false; }
            else { storage = value; return true; }
        }
        #endregion // PropertyChanged
    }
}
