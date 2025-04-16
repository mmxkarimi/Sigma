using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sigma.App.ViewModels;

namespace Sigma.App.Pages
{
    public class ChatMessage : INotifyPropertyChanged
    {
        private string message;
        private bool isUser;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public bool IsUser
        {
            get => isUser;
            set
            {
                isUser = value;
                OnPropertyChanged(nameof(IsUser));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChatMessage(string message, bool isUser)
        {
            this.Message = message;
            this.IsUser = isUser;
        }
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _inputText;
        private ObservableCollection<ChatMessage> _messages;

        public MainPageViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
            SendCommand = new Command(ExecuteSendCommand);
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ChatMessage> Messages
        {
            get => _messages;
            set
            {
                if (_messages != value)
                {
                    _messages = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command SendCommand { get; }

        private void ExecuteSendCommand()
        {
            if (string.IsNullOrWhiteSpace(InputText))
                return;

            // Add user message
            Messages.Add(new ChatMessage(InputText, true));

            // Clear input
            InputText = string.Empty;

            // TODO: Add AI response logic here
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
