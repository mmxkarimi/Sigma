using MaterialColorUtilities.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Android.Services.Colors
{
    public class DynamicColorService
    {
        MaterialColorService colorService;
        /// <summary>
        /// Return Color As ARGB
        /// </summary>
        /// <param name="isdynamic"></param>
        /// <returns></returns>
        public string GetColor(bool? isdynamic)
        {
            return colorService.SchemeMaui.Surface.ToArgbHex();
        }

        public DynamicColorService()
        {
            colorService = IPlatformApplication.Current.Services.GetService<MaterialColorService>();
        }
    }
}
