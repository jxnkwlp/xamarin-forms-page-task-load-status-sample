using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            PageStatusManager.Instance.BusyCommand = new Command(DoSamething);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void DoSamething()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                PageStatusManager.Instance.UpdateLoadStatus(true);

                return false;
            });
        }
    }
}