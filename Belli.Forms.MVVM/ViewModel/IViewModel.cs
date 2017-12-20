using System;
using System.ComponentModel;

namespace Belli.Forms.MVVM.ViewModel
{
    public interface IViewModel : INotifyPropertyChanged
    {
        event EventHandler ViewModelLoaded;
        void OnViewModelLoaded();
        void OnPropertyChanged(string name);

    }
}
