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
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RestClient restClient = new RestClient();

            var result = await restClient.Get<string>("http://asyncawaitmagic.azurewebsites.net/api/demo");

            resultlabel.Text = result;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await ProcessHelpers.RunProcessAsync("C:\\Windows\\system32\\notepad.exe");

            MessageBox.Show("Notepad inchis!");
        }
    }
}
