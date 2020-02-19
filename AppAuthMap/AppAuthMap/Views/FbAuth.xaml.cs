using AppAuthMap.Models;
using AppAuthMap.ViewModels;
using System;

using Xamarin.Forms;
using Device = Xamarin.Forms.Device;

namespace AppAuthMap.Views
{
    public partial class FbAuth : ContentPage
    {
        public FbAuth()
        {
            InitializeComponent();

            Title = "Facebook Profile";
            BackgroundColor = Color.White;
        }

        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
        {

            //Dirección para abrir la pagina login de FB con los datos configurados por el desarrollador
            var apiRequest =
               "https://www.facebook.com/dialog/oauth?client_id="
               + Configuration.ClientId
               + "&display=popup&response_type=token&redirect_uri="
               +Configuration.UrlRedirect +
               "&scope=" 
               + Configuration.Scope;

            //Se crea una vista web donde se manejará la petición y el retorno de la misma
            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;
            Content = webView;
        }

        /**
         * Se retorna el token del usuario y con el mismo se hace otra petición para pedir los datos, 
         * cuando regresan esos datos se hace una unión con la vista (binding)
         **/
        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            
            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                var vm = BindingContext as FacebookViewModel;

                await vm.SetFacebookUserProfileAsync(accessToken);

                Content = MainStackLayout;

                setData(vm.FacebookProfile);
            }
        }

        /**
         * Función para la persistencia de datos si es necesario
         **/
        private void setData(FacebookProfile facebookProfile)
        {
           
        }

        /**
         * Función que obtiene el token de la dirección que retorna el login de FB
         **/
        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                {
                    at = url.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "");
                }

                var accessToken = at.Remove(at.IndexOf("&expires_in="));

                return accessToken;
            }

            return string.Empty;
        }
    }
}
