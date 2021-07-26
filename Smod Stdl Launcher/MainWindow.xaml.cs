
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Smod_Stdl_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string modDir = "./mods/";
        //string modDir = "K:/Steam/steamapps/sourcemods/SMOD Standalone/mods/";
        string launchParamsFile = "./launch.commands";
        string launchParams = "";

        public void getLaunchParams()
        {
            if (File.Exists(launchParamsFile))
            {
                launchParams = File.ReadAllText(launchParamsFile);
            }
        }

        public void getMods()
        {

            if (Directory.Exists(modDir))
            {
                
                DirectoryInfo di = new DirectoryInfo(modDir);
                DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.TopDirectoryOnly);

                foreach (DirectoryInfo dir in directories)
                {

                    Button newBtn = new Button();
                    string modName = dir.Name;
                    newBtn.Content = modName;
                    newBtn.BorderThickness = new Thickness(0, 0, 0, 0);
                    newBtn.Background = new SolidColorBrush(Color.FromArgb(0,21, 21, 21));
                    newBtn.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    newBtn.MouseEnter += (sender, e) =>
                    {
  
                    };
                    newBtn.MouseLeave += (sender, e) =>
                    {

                    };
                    newBtn.Click += (sender, e) =>
                    {
                        Process.Start("./hl2.exe", "-game mods/" + modName + " " + launchParams);
                    };


                    Buttons.Children.Add(newBtn);
                }
            }

        }
        public MainWindow()
        {
            InitializeComponent();
            getLaunchParams();
            getMods();
        }
    }
}
