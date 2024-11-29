namespace MauiExample.Components;

public partial class Counter : ContentView
{

    int count = 0;

    public Counter()
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

}