using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using static XamarinFlex.ViewModels.BaseViewModel;

namespace XamarinFlex.ViewModels
{

    public class FlexClass
    {
        public string title { get; set; }

        public Flex flexType { get; set; }
    }

    public class HomePageViewModel : BaseViewModel
    {

        #region Properties

        private ObservableCollection<FlexClass> flexSource;

        public ObservableCollection<FlexClass> FlexSource
        {
            get { return flexSource; }
            set { flexSource = value; OnPropertyChanged(); }
        }

        private FlexClass selectedFlexItem;

        public FlexClass SelectedFlexItem
        {
            get { return selectedFlexItem; }
            set { selectedFlexItem = value; OnPropertyChanged();
                if (value != null)
                {
                    OpenRespectiveFlex(value.flexType);
                    value = null; 
                }
            }
        }


        #endregion

        #region Constructors

        public HomePageViewModel(ContentPage page)
        {
            m_view = page;
            m_view.Appearing += M_view_Appearing;
        }

        private void M_view_Appearing(object sender, EventArgs e)
        {
            try
            {
                FlexSource = new ObservableCollection<FlexClass>();
                FlexSource.Add(new FlexClass { title="GeoFence",flexType=Flex.Geofence});
                FlexSource.Add(new FlexClass { title = "Maps", flexType = Flex.Maps });
                FlexSource.Add(new FlexClass { title = "SQLite", flexType = Flex.SQLite });
                FlexSource.Add(new FlexClass { title = "SkiaSharp", flexType = Flex.SkiaSharp });
                FlexSource.Add(new FlexClass { title = "PushNotification", flexType = Flex.PushNotification });
                FlexSource.Add(new FlexClass { title = "BLE", flexType = Flex.BLE });
                FlexSource.Add(new FlexClass { title = "PushNotification", flexType = Flex.PushNotification });
                FlexSource.Add(new FlexClass { title = "WiFiHotSpot", flexType = Flex.WiFiHotSpot });
            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        #endregion

        #region Commands

        public ICommand SampleCommand { get { return new Command(SampleAction); } }


        #endregion

        #region Methods

        private void SampleAction(object obj)
        {
            try
            {

            }
            catch (Exception ex)
            {
                HandleExceptions(ex);
            }
        }

        async void OpenRespectiveFlex(Flex flexType)
        {
            try
            {
                var pageId = flexType.GetHashCode();
                switch(pageId)
                {
                    case 0: //GeoFence
                        //await m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
                    case 1: //Maps
                        await m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
                    case 2: //SQLite
                        //await m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
                    case 3: //Skiasharp
                        //await m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
                    case 4: //PushNotif
                        //await m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
                    case 5: //BLE
                        //await m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
                    case 6: //WiFiHotspot
                        //wait m_view.Navigation.PushAsync(new Views.Maps.MapsPin());
                        break;
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
