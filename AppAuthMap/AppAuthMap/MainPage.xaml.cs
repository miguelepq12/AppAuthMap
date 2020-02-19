using AppAuthMap.Views;
using System;
using Xamarin.Forms;

namespace AppAuthMap
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

		}

        async void OnFbBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FbAuth());
        }

        async void OnMapBtn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapView());
        }
    }
}
