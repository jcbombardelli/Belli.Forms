using Belli.Forms.MVVM.Service;
using Xamarin.Forms;

namespace Belli.Forms.MVVM
{
    public class BelliMVVM
    {

        public static void Initialize()
        {
            DependencyService.Register<INavigationService, Navigation>();
            DependencyService.Register<IMessageService, Messages>();

        }

    }
}
