using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    public partial class MainPage : ContentPage
    {
        private Label GetLoadingView()
        {
            var label = new Label()
            {
                Text = "loading...",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            return label;
        }



        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var page = new Page2();

            await PageStatusManager.Instance.PushAsync(Navigation, page);

            //var content = page.Content;

            //page.Content = GetLoadingView();

            //await Navigation.PushAsync(page);

            //page.DoSamething();

            //page.Content = content;
            //content = null;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var page = new Page3();

            await PageStatusManager.Instance.PushAsync(Navigation, page);
        }
    }
}
