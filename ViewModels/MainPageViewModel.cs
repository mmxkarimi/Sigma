using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Sigma.App.ViewModels
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
                OnPropertyChanged();
            }
        }

        public bool IsUser
        {
            get => isUser;
            set
            {
                isUser = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ChatMessage(string message, bool isUser)
        {
            Message = message;
            IsUser = isUser;
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _inputText;
        private ObservableCollection<ChatMessage> _messages;
        private bool _isProcessing;

        public MainPageViewModel()
        {
            Messages = new ObservableCollection<ChatMessage>();
            SendCommand = new Command(ExecuteSendCommand, () => !IsProcessing && !string.IsNullOrWhiteSpace(InputText));
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
                    (SendCommand as Command)?.ChangeCanExecute();
                }
            }
        }

        public bool IsProcessing
        {
            get => _isProcessing;
            set
            {
                if (_isProcessing != value)
                {
                    _isProcessing = value;
                    OnPropertyChanged();
                    (SendCommand as Command)?.ChangeCanExecute();
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

        public ICommand SendCommand { get; }

        private async void ExecuteSendCommand()
        {
            if (string.IsNullOrWhiteSpace(InputText))
                return;

            try
            {
                IsProcessing = true;
                var userMessage = InputText;
                InputText = string.Empty;

                // Add user message
                Messages.Add(new ChatMessage(userMessage, true));

                // Simulate AI response (replace with actual AI logic)
                await Task.Delay(1000);
                Messages.Add(new ChatMessage($"Echo: {userMessage}", false));
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsProcessing = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 