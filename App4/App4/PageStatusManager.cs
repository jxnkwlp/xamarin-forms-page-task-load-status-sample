using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    public class PageStatusManager
    {
        View _statusView;
        LoadingStatus _loadingStatus = LoadingStatus.Loading;

        ContentPage _currentPage;
        View _currentPageView;

        private static readonly PageStatusManager _instance = new PageStatusManager();

        public static PageStatusManager Instance => _instance;


        public Command BusyCommand { get; set; }

        /// <summary>
        ///  Push page 
        /// </summary> 
        public async Task PushAsync(INavigation navigation, ContentPage page)
        {
            _currentPage = page;
            _currentPageView = page.Content;

            ShowLoadingStatusView();

            await navigation.PushAsync(_currentPage);

            if (BusyCommand != null)
                BusyCommand?.Execute(null);

        }

        /// <summary>
        ///  Change task status
        /// </summary>
        /// <param name="result"></param>
        public void UpdateLoadStatus(bool result)
        {
            if (result)
                _loadingStatus = LoadingStatus.Success;
            else
                _loadingStatus = LoadingStatus.Fail;


            if (result)
            {
                _currentPage.Content = _currentPageView;
            }
            else
            {
                _currentPage.Content = _statusView = GetStatusView(LoadingStatus.Fail);
            }

        }

        private void ShowLoadingStatusView()
        {
            _currentPage.Content = _statusView = GetStatusView(LoadingStatus.Loading);
        }

        private Label GetStatusView(LoadingStatus status = LoadingStatus.Loading)
        {
            _loadingStatus = status;

            string text = "Loading...";

            if (status == LoadingStatus.Fail) text = "Load content fail, tapped be reload.";

            var label = new Label()
            {
                Text = text,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 16,
            };

            label.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => StatusViewTapped()),
            });

            return label;
        }

        private void StatusViewTapped()
        {
            if (_loadingStatus == LoadingStatus.Loading)
                return;

            ShowLoadingStatusView();


            BusyCommand?.Execute(null);

        }


        //private void SafeUpdate(Action action)
        //{
        //    Device.BeginInvokeOnMainThread(action);
        //}

        public enum LoadingStatus
        {
            Loading,
            Success,
            Fail,
        }
    }
}
