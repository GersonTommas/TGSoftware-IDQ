using IDQ.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace IDQ.WPF
{
    public enum Skin { Dark, Light }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Skin skin { get; set; } = Skin.Light;

        public App()
        {
            if (Enum.TryParse(WPF.Properties.Settings.Default.skinTheme, result: out Skin tempSkin)) { if (Enum.IsDefined(typeof(Skin), tempSkin)) { skin = tempSkin; } }
        }

        public static new App Current { get => Application.Current as App; }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var splashScreen = new SplashWindow();
            splashScreen.Show();
        }

        internal void InitializeApplication(SplashWindow splashWindow)
        {
            context.InitializeDatabase();
            // fake workload, but with progress updates.
            //Thread.Sleep(1500);

            EventWaitHandle mainWindowLoaded = new ManualResetEvent(false);

            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke((Action)(() =>
            {
                MainWindow = new Views.MainView();
                MainWindow.Loaded += (sender, e) =>
                {
                    mainWindowLoaded.Set();
                };
                splashWindow.SetProgress(0.9);
                MainWindow.Show();
                splashWindow.SetProgress(1);
            }));

            // Wait until the Main window has finished initializing and loading
            mainWindowLoaded.WaitOne();
        }
    }
}