namespace MauiExample.Components;

public partial class HelloBlank : ContentView
{

    public static readonly BindableProperty BlankProperty = BindableProperty.Create(nameof(BlankText), typeof(string), typeof(HelloBlank), string.Empty);

    public string BlankText
    {
        get => (string)GetValue(HelloBlank.BlankProperty);
        set => SetValue(HelloBlank.BlankProperty, value);
    }

    public HelloBlank()
	{
		InitializeComponent();
	}

}