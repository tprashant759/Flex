using System;
using Xamarin.Forms;

namespace XamarinFlex.ViewModels
{
    public class SkiaSharpViewModel : BaseViewModel
    {
        #region Properties


        #endregion

        #region Constructors

        public SkiaSharpViewModel(ContentPage page)
        {
            m_view = page;
            m_view.Appearing += M_view_Appearing;
        }

        private void M_view_Appearing(object sender, EventArgs e)
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



        #endregion

        #region Methods



        #endregion
    }
}
