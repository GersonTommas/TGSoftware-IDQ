using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IDQ.Domain.Base
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string PropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                return true;
            }
        }
    }
}