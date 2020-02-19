using Plugin.Geolocator;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AppAuthMap.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapView : ContentPage
	{
		public MapView ()
		{
			InitializeComponent ();
            Position();
        }

        private void Street_OnClicked(object sender, EventArgs e)
        {
            MyMap.MapType = MapType.Street;
        }


        private void Hybrid_OnClicked(object sender, EventArgs e)
        {
            MyMap.MapType = MapType.Hybrid;
        }

        private void Satellite_OnClicked(object sender, EventArgs e)
        {
            MyMap.MapType = MapType.Satellite;
        }

        private async void Position()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(new TimeSpan(10000));

            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
        }
    }
}