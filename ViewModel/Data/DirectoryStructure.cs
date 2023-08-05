
namespace ViewModel.Data
{
    public class DirectoryStructure
    {
        /// <summary>
        /// Get All logical drives
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives() 
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type=DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Get directories at top level content
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region Get Folders
            try
            {

                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(folder=> new DirectoryItem { FullPath = folder, Type = DirectoryItemType.Folder}));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }

            
            #endregion

            #region Get Files
            try
            {

                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return items;   
            #endregion
        }
    }
}
