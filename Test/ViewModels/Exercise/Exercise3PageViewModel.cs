using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise3PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise3> data = new ObservableCollection<Models.Exercise.Exercise3>();
        public ObservableCollection<Models.Exercise.Exercise3> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise3PageViewModel()
        {
            WeakReferenceMessenger.Default.Unregister<List<Models.Exercise.Exercise3>>(this);
            WeakReferenceMessenger.Default.Register<List<Models.Exercise.Exercise3>>(this, async (r, m) =>
            {
                await Task.Delay(250);
                Data = new ObservableCollection<Models.Exercise.Exercise3>(m);
            });
        }
    }
}
