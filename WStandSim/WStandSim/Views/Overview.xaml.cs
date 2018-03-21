using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Database;
using WStandSim.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentPage
    {

        Simulation s;
        Stock stock;
        public Overview()
        {
            InitializeComponent();
            s = new Simulation();
            //u = new UserDatabaseController();
            s.ReturnWeather.ToString();
            BindingContext = s;
            stock = new Stock();
            //u.SelectCurrentBalance();
        }


        

        private void Button_ClickedContinue(object sender, EventArgs e)
        {
            // Artikel verkaufen und den Kontostand aktualisieren
            s.Sell();

            // Tag und ev. Jahreszeit um 1 nach vorne setzen
            s.SimulateNewDayAndSeason(); 
            s.CalculateNewWeather();

            CurrBal.Text = s.CurrentBalance.ToString();
        }


        async private void Button_ClickedStock(object sender, EventArgs e)
        {
            if (stock == null)
            {
                stock = new Stock();
                await Navigation.PushModalAsync(stock);
            }
            else
                await Navigation.PushModalAsync(stock);
        }

        // Methode zur Übernahme des Geänderten Guthabens
        protected override void OnAppearing()
        {
            base.OnAppearing();

            CurrBal.Text = s.CurrentBalance.ToString();
            RecYest.Text = s.ReceiptsYesterday.ToString();
            ExpYest.Text = s.ExpendituresYesterday.ToString();
        }
    }

}