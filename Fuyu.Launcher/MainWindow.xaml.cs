using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Fuyu.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
			services.AddWpfBlazorWebView();
			services.AddBlazorWebViewDeveloperTools();
			Resources.Add("services", services.BuildServiceProvider());
        }
    }
}
