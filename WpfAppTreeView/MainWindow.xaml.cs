using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructor
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }


        #endregion


        #region App start
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var driver in Directory.GetLogicalDrives())
            {
                var treeItem = new TreeViewItem() 
                { 
                    Header = driver,
                    Tag = driver,
                };

                treeItem.Items.Add(null);
                treeItem.Expanded += Folder_Expanded;

                FolderView.Items.Add(treeItem); 
            }
        }

        #region Folder Expanded
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if(item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            item.Items.Clear();

            var fullPath = (string)item.Tag;
            var directories = new List<string>();
            var files = new List<string>();

            #region Get Folders
            try
            {

                var dirs = Directory.GetDirectories(fullPath);
                
                if(dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch
            {

            }

            foreach (var directory in directories) 
            {
                var subItem = new TreeViewItem() 
                { 
                    Header = GetFileFolderName(directory),
                    Tag = directory,
                };
                subItem.Items.Add(null);
                subItem.Expanded += Folder_Expanded;
                item.Items.Add(subItem);
            }
            #endregion

            #region Get Files
            try
            {

                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }
            }
            catch
            {

            }

            foreach (var file in files)
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(file),
                    Tag = file,
                };
                item.Items.Add(subItem);
            }
            #endregion
        }

        public static string GetFileFolderName(string directory)
        {
            if(string.IsNullOrEmpty(directory))
            {
                return string.Empty;
            }

            var normilizedPath = directory.Replace("/", "\\");

            var lastIndex = normilizedPath.LastIndexOf('\\');

            if(lastIndex <= 0) { return directory; }

            return directory.Substring(lastIndex + 1);
        }


        #endregion

        #endregion
    }
}
