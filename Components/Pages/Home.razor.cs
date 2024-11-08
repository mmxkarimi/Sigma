#pragma warning disable CA2012 
#pragma warning disable CS4014
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Sigma.Android.Services.LLM;
using Sigma.Android.Services.Storage;

namespace Sigma.Android.Components.Pages
{
    public partial class Home
    {
        protected async override Task OnInitializedAsync()
        {
            var name = Path.Combine(FileSystem.Current.AppDataDirectory , "gpt-arm.gguf");
            var l = new FileInfo(name).Length;
        }

        [Inject]
        SettingsService? SettingsService { get; set; }

        [Inject]
        IJSRuntime? JSRuntime { get; set; }

        [Inject]

        LLamaInterfaceService? InterfaceService { get; set; }

        [Inject]

        ExternalStorageService? ExternalStorage { get; set; }

        string Prompt = string.Empty;
        async Task ButtonSendClicked()
        {
            await JSRuntime.InvokeVoidAsync("LockChat");
            await JSRuntime.InvokeVoidAsync("AppendChat", Prompt, "user");
            var response = InterfaceService.Chat(Prompt);
            Prompt = string.Empty;
            await JSRuntime.InvokeVoidAsync("AppendChat", response, "jabir");
            await JSRuntime.InvokeVoidAsync("UnLockChat");
        }

        async Task CleanChat()
        {
            await JSRuntime.InvokeVoidAsync("CleanChat");
        }
    }
}