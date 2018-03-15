using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stock : ContentPage
	{
		public Stock ()
		{
			InitializeComponent ();
		}

        private void Button_ClickedCheckout(object sender, EventArgs e)
        {

        }

        async private void Button_ClickedOverview(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Overview());
        }
    }
}