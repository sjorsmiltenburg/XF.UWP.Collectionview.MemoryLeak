using System.Threading.Tasks;

namespace MemLeak
{
    public abstract class BaseViewModel : NotifyPropertyBase
    {
        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                OnIsBusyChanged();
            }
        }

        protected BaseViewModel()
        {
        }

        public abstract Task Init();

        public virtual void OnAppSleep() { }
        public virtual void OnAppResume() { }

        protected virtual void OnIsBusyChanged() { }

        public virtual void OnViewDisappearing() { }

        public virtual void OnViewAppearing() { }


    }
}
