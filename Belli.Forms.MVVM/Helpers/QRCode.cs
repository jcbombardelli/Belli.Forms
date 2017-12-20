using System.Collections.Generic;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace Belli.Forms.MVVM.Helpers
{
    public class QRCode
    {

        public static ZXingScannerPage CapturePageAsync(
            ZXingScannerPage scanPage, string title, ZXing.BarcodeFormat format)
        {

            if (scanPage == null)
            {
                var options = new MobileBarcodeScanningOptions
                {
                    PossibleFormats = new List<ZXing.BarcodeFormat>() { format }
                };

#if __ANDROID__
            MobileBarcodeScanner.Initialize(Application);
#endif

                scanPage = new ZXingScannerPage(options)
                {
                    IsScanning = true
                };

            };

            scanPage.Title = title;
            return scanPage;
        }
    }
}
