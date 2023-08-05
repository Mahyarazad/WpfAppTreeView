
using System.Collections.ObjectModel;
using System.Windows.Input;
using ViewModel.Data;

namespace ViewModel.ViewModels
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The way that we clear children we need to use this constructor for adding a children
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="type"></param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            
            FullPath = fullPath;
            Type = type;
            this.ExpandCommand = new RelayCommand(Expand);
            ClearChildren();
        }
        public ICommand ExpandCommand { get; set; }
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name => this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryItem.GetFileFolderName(FullPath);

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        /// <summary>
        ///  Indicates if this item can be expanded
        /// </summary>
        public bool CanExpand => Type != DirectoryItemType.File;
        public bool IsExpanded
        {
            get 
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                if (value == true)
                    Expand();
                else
                    ClearChildren();
            }
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();

            if(Type != DirectoryItemType.File)
            {
                Children.Add(null);
            }
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File)
            {
                return;
            }

            var children = DirectoryStructure.GetDirectoryContents(FullPath);
                
            Children = new ObservableCollection<DirectoryItemViewModel>(children.Select(item => new DirectoryItemViewModel(item.FullPath, item.Type)));
        }
    }
}
