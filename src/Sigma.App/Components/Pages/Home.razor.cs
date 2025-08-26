using Microsoft.AspNetCore.Components;
using Sigma.App.Components.Layout;
using Sigma.App.Extensions.Models;
using Sigma.App.Extensions.Services;
using System.IO;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Sigma.App.Components.Pages
{
    public partial class Home
    {
        [Inject] public PermissionHelper PermissionHelper { get; set; }

        public string Error { get; set; }

        public List<Chat> Messages { get; set; } = new();
        public bool Disabled { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        private bool showModal = false;
        private Modal myModal;

        public async Task ClearChat()
        {

        }
        public async Task SendMessage()
        {
            Disabled = true;
            string prompt = Message;
            Message = string.Empty;

            Messages.Add(new() { Prompt = prompt, Role = ChatRole.User });
            await InvokeAsync(() => StateHasChanged());

            try
            {
                Messages.Add(new() { Prompt = "", Role = ChatRole.Assistant });
                await InvokeAsync(() => StateHasChanged());
            }
            finally
            {
                Disabled = false;
                await InvokeAsync(() => StateHasChanged());
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!await PermissionHelper.CheckPermissionAsync())
            {
                Error = "This app needs MANAGE_EXTERNAL_STORAGE permission to access GGUF files in your Downloads folder. Due to .NET MAUI limitations, please grant this permission manually via ADB, or if you have a solution, please submit an issue on our GitHub repository.";
                myModal.Show();
            }
            
            

        }
    }
}