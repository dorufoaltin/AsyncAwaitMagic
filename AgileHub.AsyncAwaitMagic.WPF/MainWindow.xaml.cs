using AgileHub.AsyncAwaitMagic.Standard;
using AgileHub.AsyncAwaitMagic.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
        private string _demoProperty;

        public string DemoProperty
        {
            get { return _demoProperty; }
            set
            {
                RestClient restClient = new RestClient();

                var postResult = restClient.Post<string>(value, "http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

                if (!postResult.IsSuccessStatusCode)
                    return;

                _demoProperty = value;

                //DemoService service = new DemoService();

                //var result = service.SaveNewDemoTextSyncHack(value);

                //if (!result)
                //    return;


                //_demoProperty = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DemoProperty = "5";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RunProcessAsync("C:\\Windows\\system32\\notepad.exe").Wait();

            MessageBox.Show("Notepad inchis!");
        }

        private async Task RunProcessAsync(string processName)
        {
            await ProcessHelpers.RunProcessAsync(processName);
        }
    }
}
