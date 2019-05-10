using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AgileHub.AsyncAwaitMagic.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            if (saveResult)
                return;

            txtResult.Text =  $"Reached the end with result: {saveResult}!";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool saveResult = false;

            var task = Task.Factory.StartNew(() =>
            {
                DemoService service = new DemoService();

                saveResult = service.SaveNewDemoTextSyncHack("someValue");

                if (saveResult)
                    return;
            });

            task.Wait();

            txtResult.Text =  $"Reached the end with result: {saveResult}!";
        }
    }
}
