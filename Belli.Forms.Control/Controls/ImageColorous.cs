using Xamarin.Forms;

namespace Belli.Forms.Control.Controls
{
    public class ImageColorous : Image
    {
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(
                nameof(Color), typeof(Color),
                typeof(ImageColorous), Color.Black);


        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

    }
}
