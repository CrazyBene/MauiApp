namespace MauiExample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            ProgressBar.Progress = 0;
            await ProgressBar.ProgressTo(1, 250, Easing.Linear);
        }

        private void OnSubmit(object sender, EventArgs e)
        {
            SubmitButton.Text = InputeField.Text;
        }
    }

}
