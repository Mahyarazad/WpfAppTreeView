using PropertyChanged;
using System.ComponentModel;

namespace ViewModel.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = (s, e) => { };
    }
}