using System.Collections.ObjectModel;
using ViewModel.Data;

namespace ViewModel.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {
            var drives = DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(drives.Select(drive=> new DirectoryItemViewModel(drive.FullPath, drive.Type)));
        }
    }
}
