using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Android.Services.Storage
{
    public class ExternalStorageService
    {
        public async Task<PermissionStatus>? CheckAndRequestPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
                return status;


            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                throw new AccessViolationException();
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }
    }
}
