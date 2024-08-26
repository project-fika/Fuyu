using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Fuyu.Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddWpfBlazorWebView();
#if DEBUG
			serviceCollection.AddBlazorWebViewDeveloperTools();
#endif
			Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
