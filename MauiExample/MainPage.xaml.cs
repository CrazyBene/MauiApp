using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace MauiExample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private MainPageViewModel viewModel;

        private Label label = new Label
        {
            Text = "Visible if condition is true dynamically",
            HorizontalOptions = LayoutOptions.Center
        };

        public MainPage()
        {
            InitializeComponent();

            viewModel = new MainPageViewModel
            {
                IsConditionMet = false,
                Items = new List<string> { "Item 1", "Item 2", "Item 3" }
            };

            BindingContext = viewModel;

            for (int i = 1; i <= 5; i++)
            {
                var label = new Label
                {
                    Text = $"Dynamic Label {i}",
                    HorizontalOptions = LayoutOptions.Center
                };

                LoopContainer.Children.Add(label);
            }
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

        private void ChangeVisibility(object sender, EventArgs e)
        {
            viewModel.IsConditionMet = !viewModel.IsConditionMet;

            if (ConditionalContainer.Children.Count == 0)
            {
                ConditionalContainer.Children.Add(label);
            } else
            {
                ConditionalContainer.Children.Remove(label);
            }
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool isConditionMet = false;
        private List<string> items = new();

        public bool IsConditionMet
        {
            get => isConditionMet;
            set
            {
                if (isConditionMet != value)
                {
                    isConditionMet = value;
                    OnPropertyChanged(nameof(IsConditionMet));
                }
            }
        }

        public List<String> Items
        {
            get => items;
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
