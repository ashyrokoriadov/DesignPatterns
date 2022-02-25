using Autofac;
using CommandExample.IoC;
using CommandExample.ViewModels;
using System.Windows;

namespace CommandExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using var scope = ContainerPreparer.Container.BeginLifetimeScope();
            DataContext = scope.Resolve<RemoteControleViewModel>();
            InitializeComponent();
        }
    }
}
