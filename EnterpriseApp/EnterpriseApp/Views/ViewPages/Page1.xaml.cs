using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnterpriseApp.Views.ViewPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 (string email)
		{
            try
            {
                InitializeComponent();
                stackLayoutLabel.Text = email;
            }
            catch(Exception ex)
            {

            }
        }
	}
}