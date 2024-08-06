using System.ComponentModel;
using System.Runtime.CompilerServices;
using Test.SQLiteDB;
namespace Test.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region DependencyService
        public ISQLiteDB SQLiteDB => DependencyService.Get<ISQLiteDB>();
        #endregion
        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action? onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
