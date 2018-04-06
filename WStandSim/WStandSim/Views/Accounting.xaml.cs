using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Accounting : ContentPage
	{
        Simulation s;
		public Accounting ()
		{
			InitializeComponent ();
            s = new Simulation();
            BindingContext = s;
        }

        // Zurück
        private void Button_ClickedOverview(object sender, EventArgs e)
        {
            // Button deaktivieren
            IsEnabled = false;
            // Zurück zur Startseite
            Navigation.PopModalAsync();
            // Button aktivieren
            IsEnabled = true;
        }
    }
}