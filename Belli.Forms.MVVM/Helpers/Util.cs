using Plugin.Vibrate;
using System;

namespace Belli.Forms.MVVM.Helpers
{
    public class Util
    {

        private Util() { }


        public static void Vibrate()
        {
            try
            {
                var v = CrossVibrate.Current;
                v.Vibration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
