using System;
using Avalonia.Controls;
using Fuyu.Platform.Launcher;

namespace Fuyu.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // placeholder, launch properly later
            StartEft();
        }

        public void StartEft()
        {
            var cwd = Environment.CurrentDirectory;
            var accountId = 480892;
            var address = "http://localhost:8000";

            using (var process = EftProcess.Get(cwd, accountId, address))
            {
                process.Start();
            }
        }
    }
}