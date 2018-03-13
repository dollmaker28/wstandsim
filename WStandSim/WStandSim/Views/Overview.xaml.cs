using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Overview : ContentPage
	{
		public Overview ()
		{
			InitializeComponent ();
		}

        private void Button_ClickedContinue(object sender, EventArgs e)
        {
            // Instanzierung der Klasse Simulation
            Simulation s = new Simulation();

            s.SimulateNewDayAndSeason();
        }
    }
}