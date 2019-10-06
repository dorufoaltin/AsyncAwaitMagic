using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgileHub.AsyncAwaitMagic.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<string> GetDemoText()
        {
            RestClient restClient = new RestClient();

            var result = await restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo");

            return await result.Content.ReadAsStringAsync();
        }

        private async void WpfContext_Click(object sender, RoutedEventArgs e)
        {
            var result = await GetDemoText();

            //var result = GetDemoText().Result;

            Console.WriteLine($"Demo text: { result }, using the context: { SynchronizationContext.Current.GetType().Name }");
        }

        private async void SingleThreadedContext_Click(object sender, RoutedEventArgs e)
        {
            SynchronizationContext.SetSynchronizationContext(new SingleThreadSynchronizationContext());

            var result = await GetDemoText();

            //await Task.Delay(1); // - add this await so we change the current unit of code execution to a thread from SingleThreadSynchronizationContext
            //var result = GetDemoText().Result;

            Console.WriteLine($"Demo text: { result }, using the context: { SynchronizationContext.Current.GetType().Name }");
        }

        private async void MultiThreadedContext_Click(object sender, RoutedEventArgs e)
        {
            SynchronizationContext.SetSynchronizationContext(new MultiThreadedSynchronizationContext(3));

            var result = await GetDemoText();

            //await Task.Delay(1); // - add this await so we change the current unit of code execution to a thread from MultiThreadedSynchronizationContext
            //var result = GetDemoText().Result;

            Console.WriteLine($"Demo text: { result }, using the context: { SynchronizationContext.Current.GetType().Name }");
        }

        private async void NewThreadContext_Click(object sender, RoutedEventArgs e)
        {
            SynchronizationContext.SetSynchronizationContext(new NewThreadPerActionSynchronizationContext());

            var result = await GetDemoText();

            //await Task.Delay(1); - add this await so we change the current unit of code execution to a thread from NewThreadPerActionSynchronizationContext
            //var result = GetDemoText().Result;

            Console.WriteLine($"Demo text: { result }, using the context: { SynchronizationContext.Current.GetType().Name }");

            SynchronizationContext.SetSynchronizationContext(null);
        }
    }
}
