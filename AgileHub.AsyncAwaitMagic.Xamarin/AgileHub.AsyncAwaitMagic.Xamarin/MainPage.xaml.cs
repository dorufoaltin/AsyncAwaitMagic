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
            RestClient restClient = new RestClient();

            var result = restClient.Get("http://asyncawaitmagic.azurewebsites.net/api/demo").Result;

            Result = $"Reached the end with result: {result.StatusCode}!";
        }
    }
}
