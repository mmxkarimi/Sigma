using Android.Content;
using AndroidX.Core.Content;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.App.Extensions.Services
{
    public class PermissionHelper 
    {
        public async Task<bool> CheckPermissionAsync()
        {
            return Android.OS.Environment.IsExternalStorageManager;
        }

        public async Task<bool> GetPermissionAsync()
        {
            var intent = new Intent(Settings.ActionManageAppAllFilesAccessPermission);
            intent.SetData(Android.Net.Uri.Parse($"package:{Platform.CurrentActivity?.PackageName}"));
            Platform.CurrentActivity?.StartActivity(intent);
            return await CheckPermissionAsync();
                
        }
    }
}
