

namespace ViewModel.Data
{
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name => this.Type == DirectoryItemType.Drive ? this.FullPath : GetFileFolderName(FullPath);

        #region Helper methods
        /// <summary>
        /// Helper method to get file and folder name
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                return string.Empty;
            }

            var normilizedPath = directory.Replace("/", "\\");

            var lastIndex = normilizedPath.LastIndexOf('\\');

            if (lastIndex <= 0) { return directory; }

            return directory.Substring(lastIndex + 1);
        }
        #endregion
    }
}
