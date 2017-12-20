using Belli.Forms.MVVM;
using Belli.Forms.MVVM.Service;
using Xamarin.Forms;

namespace Belli.Forms
{
    public partial class App : Application
    {
        public App()
        {

            BelliMVVM.Initialize();

            InitializeComponent();


            INavigationService navigation = DependencyService.Get<INavigationService>();
            navigation.MainPage(new MainPage());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
