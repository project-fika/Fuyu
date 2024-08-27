using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Fuyu.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
			services.AddWpfBlazorWebView();
            services.AddFluentUIComponents();
			services.AddBlazorWebViewDeveloperTools();
			Resources.Add("services", services.BuildServiceProvider());
        }
    }
}
