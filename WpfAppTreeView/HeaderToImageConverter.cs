using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ViewModel.Data;

namespace WpfAppTreeView
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (DirectoryItemType)value switch
            {
                DirectoryItemType.Folder => new BitmapImage(new Uri($"pack://application:,,,/Images/folder.png")),
                DirectoryItemType.Drive => new BitmapImage(new Uri($"pack://application:,,,/Images/windows-drive.png")),
                _ => new BitmapImage(new Uri($"pack://application:,,,/Images/file.png")),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
