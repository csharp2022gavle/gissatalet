using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gissatalet.models
{
    internal class DownloadFont
    {
        public static async Task MainTask()
        {
            try
            {
                HttpClient client = new();
                var response = await client.GetStringAsync("https://raw.githubusercontent.com/xero/figlet-fonts/master/Bloody.flf");
                await File.WriteAllTextAsync(Tasks.fontPath, response.ToString());
                client.CancelPendingRequests();
            }
            catch
            {
                string error = Strings.Localization("loadingFontError");
                SetCursor.SetXandWrite(error);
                Thread.Sleep(200);
            }
        }
    }
}
