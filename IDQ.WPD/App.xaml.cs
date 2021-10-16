using IDQ.EntityFramework;
using IDQ.WPF.Enumerators;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace IDQ.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SkinEnum skin { get; set; } = SkinEnum.Light;
        public static CardEnum card { get; set; } = CardEnum.Light;

        public App()
        {
            if (Enum.TryParse(WPF.Properties.Settings.Default.skinTheme, result: out SkinEnum tempSkin)) { if (Enum.IsDefined(typeof(SkinEnum), tempSkin)) { skin = tempSkin; } }
            if (Enum.TryParse(WPF.Properties.Settings.Default.cardTheme, result: out CardEnum tempCard)) { if (Enum.IsDefined(typeof(CardEnum), tempCard)) { card = tempCard; } }
        }

        public static new App Current => Application.Current as App;

        void OnStartup(object sender, StartupEventArgs e)
        {
            SplashWindow splashScreen = new SplashWindow();
            splashScreen.Show();
        }

        internal void InitializeApplication()
        {
            context.InitializeDatabase();
            EntityFramework.Updates.xUpdateService.xDoUpdate(WPF.Properties.Settings.Default.Version);
            WPF.Properties.Settings.Default.Version = 2.0M;
            WPF.Properties.Settings.Default.Save();

            EventWaitHandle mainWindowLoaded = new ManualResetEvent(false);

            // Create the main window, but on the UI thread.
            _ = Dispatcher.BeginInvoke((Action)(() =>
              {
                  MainWindow = new ContentWindow();
                  MainWindow.Loaded += (sender, e) =>
                  {
                      _ = mainWindowLoaded.Set();
                  };
                  MainWindow.Show();
              }));

            // Wait until the Main window has finished initializing and loading
            _ = mainWindowLoaded.WaitOne();
        }
    }
}