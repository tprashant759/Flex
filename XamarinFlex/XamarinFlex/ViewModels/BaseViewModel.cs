using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XamarinFlex.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {

        #region Properties

        public ContentPage m_view { get; set; }

        #endregion

        #region Notify Property Change

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
               [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(propertyName));
        }

        //protected void SetValue<T>(ref T backingField,
        //      T value,
        //      [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(
        //                 backingField, value)) return;
        //    backingField = value;
        //    OnPropertyChanged(propertyName);
        //}

        #endregion

        #region Enums

        public enum Flex
        {
            Geofence=0,
            Maps=1,
            SQLite=2,
            SkiaSharp=3,
            PushNotification=4,
            BLE=5,
            WiFiHotSpot=6
        }

        #endregion

        #region Constructors

        public BaseViewModel()
        {
          
        }

        #endregion

        #region Methods

        public void HandleExceptions(Exception exception)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
