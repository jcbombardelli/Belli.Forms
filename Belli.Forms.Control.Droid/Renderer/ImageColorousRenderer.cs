using Android.Graphics;
using Belli.Forms.Control.Controls;
using Belli.Forms.Control.Droid.Renderer;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRendererAttribute(typeof(ImageColorous), typeof(ImageColorousRenderer))]
namespace Belli.Forms.Control.Droid.Renderer
{
    public class ImageColorousRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ImageColorous.ColorProperty.PropertyName)
                SetTint();
        }

        void SetTint()
        {
            if (Control == null || Element == null)
                return;

            if (((ImageColorous)Element).Color.Equals(Xamarin.Forms.Color.Transparent))
            {
                //Turn off tinting

                if (Control.ColorFilter != null)
                    Control.ClearColorFilter();

                return;
            }

            //Apply tint color
            var colorFilter = new PorterDuffColorFilter(((ImageColorous)Element).Color.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.SetColorFilter(colorFilter);
        }
    }
}