using AgileHub.AsyncAwaitMagic.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgileHub.AsyncAwaitMagic.Xamarin
{
    public partial class MainPage : ContentPage
    {
        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                if (value != _result)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this;
        }
        
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DemoService service = new DemoService();

            var saveResult = service.SaveNewDemoTextSyncHack("someValue");

            if (saveResult)
                return;

            Result = $"Reached the end with result: {saveResult}!";
        }

        private void Button_Clicked(object sender, EventArgs e)
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

            Result = $"Reached the end with result: {saveResult}!";
        }
    }
}
