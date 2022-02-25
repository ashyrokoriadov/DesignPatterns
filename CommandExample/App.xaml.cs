using CommandExample.IoC;
using System.Windows;

namespace CommandExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DefaultDependencies.Register(ContainerPreparer.Builder);
        }
    }
}
