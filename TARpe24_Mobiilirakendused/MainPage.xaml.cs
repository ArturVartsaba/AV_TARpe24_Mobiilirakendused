using Android.Security.Identity;

namespace TARpe24_Mobiilirakendused
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            BotImage.Rotation += 20; //Pöörab pildi 20 kraadi iga vajutusega
            BotImage.Opacity -= 0.1; //Vähendab pildi nähtavust iga vajutusega
            var rnd = new Random();
            var rndColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BackgroundColor = rndColor; //muudab tausta värvi

            if (count >= 5)
            {
                //Kui on viis vajutust, muuda nupp punaseks
                CounterBtn.BackgroundColor = Colors.Red; 
            }

            if (count >= 10)
            {
                //Kui on 10 vajutust, tee pilti mittenähtavaks ja muuda teksti
                BotImage.IsVisible = false;
                CounterBtn.Text = "Pilt kadus ära! Vajuta Reset."; 
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void OnResetClicked(object? sender, EventArgs e)
        {
            count = 0; 
            CounterBtn.Text = "Alustame uuesti!";
            BotImage.Rotation = 0; //pildi pööre tehakse algseks
            BotImage.IsVisible = true; //Pilt tehakse nähtavaks
            CounterBtn.BackgroundColor = Colors.Blue; //Nuppu värv mutub tagasi siniseks
            BotImage.Opacity = 1; //Pilt tehakse nähtavaks
            BackgroundColor = Colors.White; //Muudab tausta värvi algseks

            if (BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                //Liigutab pidli ekraani servale
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                //Liigutab pildi ekraani teise servale
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
        }
    }
}
