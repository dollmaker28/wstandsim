using System;
using WStandSim.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;

namespace WStandSim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stock : ContentPage
    {
        // Instanzierung
        Simulation s;
        Timer t;

        // Initialisieren
        public Stock()
        {
            InitializeComponent();
            s = new Simulation();
            BindingContext = s;
        }

        // Timer für Buttons
        public void CreateTimer()
        {
            t = new Timer
            {
                Interval = 100,
                Enabled = false
            };
            t.AutoReset = true;
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

        // Buttonfunktionen für Halten und Loslassen
        #region UpDownButtons halten/loslassen

        // UP
        private void Button_PressedSausageUP(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedSausageUP;
            }
        }

        private void Button_ReleaseSausageUP(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        private void Button_PressedBreadUP(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedBreadUP;
            }
        }

        private void Button_ReleaseBreadUP(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        private void Button_PressedBeerUP(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedBeerUP;
            }
        }

        private void Button_ReleaseBeerUP(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        private void Button_PressedLemonadeUP(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedLemonadeUp;
            }
        }

        private void Button_ReleaseLemonadeUP(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        // DOWN
        private void Button_PressedSausageDOWN(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedSausageDOWN;
            }
        }

        private void Button_ReleaseSausageDOWN(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        private void Button_PressedBreadDOWN(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedBreadDOWN;
            }
        }

        private void Button_ReleaseBreadDOWN(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        private void Button_PressedBeerDOWN(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedBeerDOWN;
            }
        }

        private void Button_ReleaseBeerDOWN(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }

        private void Button_PressedLemonadeDOWN(object sender, EventArgs e)
        {
            if (s.ButtonIsActive == false)
            {
                s.ButtonIsActive = true;
                CreateTimer();
                t.Enabled = true;
                t.Elapsed += Button_ClickedLemonadeDOWN;
            }
        }

        private void Button_ReleaseLemonadeDOWN(object sender, EventArgs e)
        {
            t.Enabled = false;
            s.ButtonIsActive = false;
        }
        #endregion

        // Button Kaufen
        private void Button_ClickedBuy(object sender, EventArgs e)
        {
            // Button deaktivieren
            IsEnabled = false;
            // Kaufen aufrufen
            s.Buy();
            // Button aktivieren
            IsEnabled = true;
            // Manuell aktualisieren
            OnAppearing();
        }

        // Methode zur Übernahme des Geänderter Werte
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Property muss aktualisiert werden, da Stock eine andere Instanz der Simulation hat, als Overview
            s.SetAmountPerItem();

            SausAm.Text = s.SausageAmount.ToString();
            BreadAm.Text = s.BreadAmount.ToString();
            BeerAm.Text = s.BeerAmount.ToString();
            LemonAm.Text = s.LemonadeAmount.ToString();
        }

    }
}