using MauiExample.Services;

namespace MauiExample.Pages;

public partial class SecondPage : ContentPage
{

	private LoggingService loggingService;

	public SecondPage(LoggingService loggingService)
	{
		InitializeComponent();

		this.loggingService = loggingService;
	}

    private void LogMessage(object sender, EventArgs e)
    {
        var message = MessageField.Text;
		
		loggingService.LogMessage(message);

    }

}