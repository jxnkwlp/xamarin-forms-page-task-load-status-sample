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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();


            PageStatusManager.Instance.BusyCommand = new Command(DoSamething);
        }

        int count = 0;

        public void DoSamething()
        {
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                count++;

                PageStatusManager.Instance.UpdateLoadStatus(count > 2);

                return false;
            });

        }
    }
}