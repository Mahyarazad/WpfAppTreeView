using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfAppTreeView
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is null) return new object();
            var path = (string)value;

            if (path is null) return null;

            //gGet the name of the item
            var name = MainWindow.GetFileFolderName(path);

            var image = "file.png";

            // if the name is black we presume that it is drive 
            if(name == string.Empty)
            {
                image = "windows-drive.png";
            }else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "folder.png";
            }
            else
            {

            }

            return new BitmapImage (new Uri($"pack://application:,,,/Images/{image}"));
         
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
