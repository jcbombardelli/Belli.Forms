using System.Threading.Tasks;

namespace Belli.Forms.MVVM.ViewModel
{
    public interface IEditViewModel : IViewModel
    {
        Task<bool> UpdateModel();
        void EnableEditMode();
        void DisableEditMode();
    }
}
