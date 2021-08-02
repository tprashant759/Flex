using System;
using System.Threading;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Map = Xamarin.Forms.Maps.Map;

namespace XamarinFlex.ViewModels
{
    public class MapsViewModel : BaseViewModel
    {
        #region Properties

        CancellationTokenSource cts;

        public Map Map { get; set; }

        #endregion

        #region Constructors

        public MapsViewModel(ContentPage page,Map mapObject)
        {
            m_view = page;
            Map = mapObject;
            m_view.Appearing += Page_Appearing;
            m_view.Disappearing += M_view_Disappearing;
        }

        private void M_view_Disappearing(object sender, EventArgs e)
        {
            try
            {
                if (cts != null && !cts.IsCancellationRequested)
                    cts.Cancel();
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private void Page_Appearing(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        #endregion

        #region Commands

        public ICommand AddPinCommand { get { return new Command(AddPinAction); } }

        public ICommand CurrentLocationCommand { get { return new Command(CurrentLocationAction); } }

        #endregion

        #region Methods

        void SetUpMap()
        {
            try
            {
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(
     new Position(36.9628066, -122.0194722), Distance.FromMiles(3)));
                var position = new Position(36.9628066, -122.0194722);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "Santa Cruz",
                    Address = "custom detail info"
                };
                Map.Pins.Add(pin);
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private void AddPinAction(object obj)
        {
            try
            {
                Map.Pins.Add(new Pin
                {
                    Position = new Position(Map.VisibleRegion.Center.Latitude, Map.VisibleRegion.Center.Longitude),
                    Label="Custom pin"
                });
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        private async void CurrentLocationAction(object obj)
        {

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                     new Position(location.Latitude, location.Longitude), Distance.FromMiles(3)));
                }
                else
                {
                    UserDialogs.Instance.Toast("Error fetching location");
                }

        
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        #endregion
    }
}
