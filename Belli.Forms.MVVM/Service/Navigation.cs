using Belli.Forms.MVVM.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Belli.Forms.MVVM.Service
{

    public interface INavigationService
    {
        void MainPage(IView view);
        void MainPage(Page page);
        void MainNavigationPage(IView view, bool toolbar);
        void MainNavigationPage(Page view, bool toolbar);
        void PushAsync(IView view);
        void PushAsync(Page page);
        void PopAsync();
        Task PushModalAsync(IView view);
        Task PushModalAsync(Page page);
        Task PopModalAsync();
    }

    public class Navigation : INavigationService
    {

        private Page currentPage;
        private IView currentView;

        private NavigationPage navigation;

        private Stack<IView> stackViews;
        private Stack<Page> stackPages;

        private bool toolbar;


        public void MainNavigationPage(IView view, bool toolbar)
        {
            this.toolbar = toolbar;
            this.currentView = view;


            if (this.toolbar)
            {
                stackViews = null;

                navigation = new NavigationPage((ContentPage)view);
                Application.Current.MainPage = navigation;
            }
            else
            {
                stackViews = new Stack<IView>();
                stackViews.Push(this.currentView);

                Application.Current.MainPage = (ContentPage)stackViews.Peek();
            }

            ErasePageContext();
        }

        public void MainNavigationPage(Page page, bool toolbar)
        {
            this.toolbar = toolbar;
            this.currentPage = page;


            if (this.toolbar)
            {
                stackPages = null;

                navigation = new NavigationPage(page);
                Application.Current.MainPage = navigation;
            }
            else
            {
                stackPages = new Stack<Page>();
                stackPages.Push(this.currentPage);

                Application.Current.MainPage = stackPages.Peek();
            }

            EraseViewContext();
        }

        public void MainPage(IView view)
        {
            try
            {
                this.currentView = view;
                Application.Current.MainPage = ((ContentPage)view);

            }
            finally
            {
                ErasePageContext();
            }
        }

        public void MainPage(Page page)
        {
            try
            {
                this.currentPage = page;
                Application.Current.MainPage = page;

            }
            finally
            {
                EraseViewContext();
            }
        }

        public void PopAsync()
        {

            if (stackPages != null && stackPages.Count > 0)
            {
                MainPage(stackPages.Pop());
            }
            else if (stackViews != null && stackViews.Count > 0)
            {
                MainPage(stackViews.Pop());
            }
            else if (navigation != null)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public Task PopModalAsync()
        {
            return Application.Current.MainPage.Navigation.PopModalAsync();
        }

        public void PushAsync(IView view)
        {

            if (navigation == null)
            {

                if (stackViews == null)
                {
                    stackViews = new Stack<IView>();
                    stackViews.Push(currentView);
                }

                currentView = view;
                stackViews.Push(currentView);
                MainPage(currentView);

            }
            else
            {
                navigation.PushAsync((ContentPage)view);
            }
        }

        public void PushAsync(Page page)
        {
            if (navigation == null)
            {

                if (stackPages == null)
                {
                    stackPages = new Stack<Page>();
                    stackPages.Push(currentPage);
                }

                currentPage = page;
                stackPages.Push(currentPage);
                MainPage(currentPage);

            }
            else
            {
                navigation.PushAsync(page);
            }
        }

        public async Task PushModalAsync(IView view)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync((ContentPage)view);
        }

        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);
        }


        private void EraseViewContext()
        {
            stackViews = null;
            currentView = null;
        }

        private void ErasePageContext()
        {
            stackPages = null;
            currentPage = null;
        }
    }
}
