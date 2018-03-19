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
	public partial class Stock : ContentPage
	{
        // Instanzierung
        Simulation s;

        // Initialisieren
        public Stock ()
		{
			InitializeComponent ();
            s = new Simulation();
            BindingContext = s;
        }

        // Zurück
        private void Button_ClickedOverview(object sender, EventArgs e)
        {
            base.OnBackButtonPressed();
            //await Navigation.PushModalAsync(new Overview());
        }

        // Buttons für Ein - Verkauf
        #region UpDownButtons
        private void Button_ClickedSausageUP(object sender, EventArgs e)
        {
            s.RaiseSausages();
        }
        private void Button_ClickedSausageDOWN(object sender, EventArgs e)
        {
            s.LowerSausages();
        }
        private void Button_ClickedBreadUP(object sender, EventArgs e)
        {
            s.RaiseBread();
        }
        private void Button_ClickedBreadDOWN(object sender, EventArgs e)
        {
            s.LowerBread();
        }
        private void Button_ClickedBeerUP(object sender, EventArgs e)
        {
            s.RaiseBeer();
        }
        private void Button_ClickedBeerDOWN(object sender, EventArgs e)
        {
            s.LowerBeer();
        }
        private void Button_ClickedLemonadeUp(object sender, EventArgs e)
        {
            s.RaiseLemonades();
        }
        private void Button_ClickedLemonadeDOWN(object sender, EventArgs e)
        {
            s.Loweremonades();
        }
        #endregion

        // Button Kaufen
        private void Button_ClickedBuy(object sender, EventArgs e)
        {

        }
    }
}