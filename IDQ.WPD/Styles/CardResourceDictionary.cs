using IDQ.WPF.Enumerators;
using System;
using System.Windows;

namespace IDQ.WPF.Styles
{
    public class CardResourceDictionary : ResourceDictionary
    {
        Uri _lightSource;
        Uri _darkSource;

        public Uri LightSource
        {
            get => _lightSource;
            set
            {
                _lightSource = value;
                UpdateSource();
            }
        }

        public Uri DarkSource
        {
            get => _darkSource;
            set
            {
                _darkSource = value;
                UpdateSource();
            }
        }

        void UpdateSource()
        {
            Uri val = App.card == CardEnum.Light ? LightSource : DarkSource;
            if (val != null && Source != val)
            {
                Source = val;
            }
        }
    }
}
