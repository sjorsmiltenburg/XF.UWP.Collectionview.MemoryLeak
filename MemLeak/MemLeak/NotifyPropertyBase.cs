using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace MemLeak
{
    public abstract class NotifyPropertyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            OnPropertyChanged(property.GetMemberInfo().Name);
        }
    }
}
