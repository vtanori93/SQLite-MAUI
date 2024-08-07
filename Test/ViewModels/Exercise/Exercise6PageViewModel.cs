
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace Test.ViewModels.Exercise
{
    public class Exercise6PageViewModel : BaseViewModel
    {
        ObservableCollection<Models.Exercise.Exercise6> data = new ObservableCollection<Models.Exercise.Exercise6>();
        public ObservableCollection<Models.Exercise.Exercise6> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }
        public Exercise6PageViewModel()
        {
            WeakReferenceMessenger.Default.Unregister<List<Models.Exercise.Exercise6>>(this);
            WeakReferenceMessenger.Default.Register<List<Models.Exercise.Exercise6>>(this, async (r, m) =>
            {
                await Task.Delay(250);
                Data = new ObservableCollection<Models.Exercise.Exercise6>(m);
            });
        }
    }
}
