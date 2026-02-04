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
            BotImage.Rotation += 20;
            BotImage.Opacity -= 0.1;
            var rnd = new Random();
            var rndColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BackgroundColor = rndColor; //muudab tausta värvi

            if (count >= 5)
            {
                CounterBtn.BackgroundColor = Colors.Red;
            }

            if (count >= 10)
            {
                BotImage.IsVisible = false;
                CounterBtn.Text = "Pilt kadus ära! Vajuta Reset.";
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void OnResetClicked(object? sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = "Alustame uuesti!";
            BotImage.Rotation = 0;
            BotImage.IsVisible = true;
            CounterBtn.BackgroundColor = Colors.Blue;
            BotImage.Opacity = 1;
            BackgroundColor = Colors.White;

            if (BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
        }
    }
}
