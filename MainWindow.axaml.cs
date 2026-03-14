using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage; // Важно для работы с файлами
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LabApp;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    // Выбор файла для СОХРАНЕНИЯ
    private async void BrowseSave_Click(object sender, RoutedEventArgs e)
    {
        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Сохранить файл",
            FileTypeChoices = new[] { new FilePickerFileType("Binary") { Patterns = new[] { "*.dat" } } }
        });

        if (file != null)
            SavePathBox.Text = file.Path.LocalPath;
    }

    // Выбор файла для ОТКРЫТИЯ
    private async void BrowseOpen_Click(object sender, RoutedEventArgs e)
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Открыть файл",
            AllowMultiple = false
        });

        if (files.Count > 0)
            OpenPathBox.Text = files[0].Path.LocalPath;
    }

    private void Serialize_Click(object sender, RoutedEventArgs e)
    {
        // Здесь ваш код с BinaryWriter и sizeof
    }

    private void Deserialize_Click(object sender, RoutedEventArgs e)
    {
        // Здесь ваш код с BinaryReader
    }
}

