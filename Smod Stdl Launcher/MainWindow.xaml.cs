
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System;


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
        

        private void getLaunchParams()
        {
            if (File.Exists(launchParamsFile))
            {
                launchParams = File.ReadAllText(launchParamsFile);
            }
        }

        private void updateTextBox()
        {
            launchParamsTextBox.Text = launchParams;
        }

        public void updateLaunchParams(object sender, TextChangedEventArgs args)
        {
            string newParams = launchParamsTextBox.Text;
            launchParams = newParams;
            File.WriteAllText(launchParamsFile, newParams);
        }

        private void getMods()
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
            getLaunchParams();
            InitializeComponent();
            updateTextBox();
            getMods();
            
        }
    }
}
