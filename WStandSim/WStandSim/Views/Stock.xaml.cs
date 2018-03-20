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
        //Overview overview;

        // Initialisieren
        public Stock ()
		{
			InitializeComponent ();
            s = new Simulation();
            BindingContext = s;
            //overview = new Overview();
        }

        // Zurück
        private void Button_ClickedOverview(object sender, EventArgs e)
        {
            //if (overview == null)
            //{
            //    overview = new Overview();
            //    await Navigation.PushModalAsync(overview);
            //}
            //else
            //    await Navigation.PushModalAsync(overview);


            //base.OnBackButtonPressed(Overview);
            Navigation.PopModalAsync();
            //var vUpdatedPage = new Overview();
            //Navigation.InsertPageBefore(vUpdatedPage, this);
            //Navigation.PopModalAsync();
        }

        // Buttons für Ein - Verkauf
        #region UpDownButtons
        private void Button_ClickedSausageUP(object sender, EventArgs e)
        {
            //s.RaiseSausages();
            s.Raise("sausage");
        }
        private void Button_ClickedSausageDOWN(object sender, EventArgs e)
        {
            //s.LowerSausages();
            s.Lower("sausage");
        }
        private void Button_ClickedBreadUP(object sender, EventArgs e)
        {
            //s.RaiseBread();
            s.Raise("bread");
        }
        private void Button_ClickedBreadDOWN(object sender, EventArgs e)
        {
            //s.LowerBread();
            s.Lower("bread");
        }
        private void Button_ClickedBeerUP(object sender, EventArgs e)
        {
            //s.RaiseBeer();
            s.Raise("beer");
        }
        private void Button_ClickedBeerDOWN(object sender, EventArgs e)
        {
            //s.LowerBeer();
            s.Lower("beer");
        }
        private void Button_ClickedLemonadeUp(object sender, EventArgs e)
        {
            //s.RaiseLemonades();
            s.Raise("lemonade");
        }
        private void Button_ClickedLemonadeDOWN(object sender, EventArgs e)
        {
            //s.Loweremonades();
            s.Lower("lemonade");
        }
        #endregion

        // Button Kaufen
        private void Button_ClickedBuy(object sender, EventArgs e)
        {
            s.Buy();
        }


        private void Button_ClickedContinue(object sender, EventArgs e)
        {
            s.SimulateNewDayAndSeason();
            s.CalculateNewWeather();
        }
    }
} 