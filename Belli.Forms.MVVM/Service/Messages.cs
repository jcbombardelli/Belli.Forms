using System.Threading.Tasks;
using Xamarin.Forms;

namespace Belli.Forms.MVVM.Service
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message);
        Task<bool> ShowYesNoAsync(string title, string message);
    }

    public class Messages : IMessageService
    {

        public async Task ShowAsync(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, StringTable.Ok);
        }

        public async Task<bool> ShowYesNoAsync(string title, string message)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, StringTable.Yes, StringTable.No);
        }
    }
}
