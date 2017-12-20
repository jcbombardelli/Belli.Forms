using System;
using System.ComponentModel;
using System.Threading;

namespace Belli.Forms.MVVM.ViewModel
{
    public abstract class ViewModel : IViewModel
    {
        private bool loading = false;
        public bool IsLoading
        {
            get => loading;
            set
            {
                loading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }


        public event EventHandler ViewModelLoaded;

        public event PropertyChangedEventHandler PropertyChanged;

        public static SynchronizationContext UISynchronizationContext { get; set; }

        public void OnViewModelLoaded()
        {
            ViewModelLoaded?.Invoke(this, null);
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        ~ViewModel()
        {
            ViewModelLoaded = null;
            PropertyChanged = null;
        }

    }


    public abstract class ViewModel<TModel> : ViewModel where TModel : class, new()
    {

        private TModel modelInstance;

        public TModel ModelInstance
        {
            get => modelInstance;
            set
            {
                modelInstance = value;
                OnPropertyChanged(nameof(ModelInstance));
            }
        }

        public ViewModel() : base()
        {
            modelInstance = new TModel();
        }
    }


    public abstract class ViewModel<TModel, TModelKey> : ViewModel<TModel>
        where TModel : class, TModelKey, new()
        where TModelKey : class
    {
        public ViewModel() : base()
        {
            throw new Exception(StringTable.Class_Not_Implemented);
        }

    }

}
