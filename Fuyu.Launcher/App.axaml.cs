using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaBlazorWebView;
using Fuyu.Platform.Launcher;

namespace Fuyu.Launcher
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void RegisterServices()
        {
            var routes = typeof(Routes); // Routes.razor

            base.RegisterServices();

            AvaloniaBlazorWebViewBuilder.Initialize(
                default,
                setting => {
                    // setting for blazor 
                    setting.ComponentType = routes;
                    setting.Selector = "#app";

                    // using internal resources (css, js, etc)
                    setting.ResourceAssembly = routes.Assembly;
                },
                inject => {
                    // inject services here
                });
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
