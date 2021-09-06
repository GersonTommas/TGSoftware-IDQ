using IDQ.Domain.Base;
using System.Windows;

namespace IDQ.WPF.Base
{
    public class ViewModelBase : PropertyChangedBase
    {
        public Window thisWindow;

        public virtual void setInitialize(Window sentWindow)
        {
            thisWindow = sentWindow;
        }
    }
}
