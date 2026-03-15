using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UI;

namespace UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var bSave = this.FindControl<Button>("BrowseSaveBtn");
        if (bSave != null) bSave.Click += BrowseSave_Click;

        var bOpen = this.FindControl<Button>("BrowseOpenBtn");
        if (bOpen != null) bOpen.Click += BrowseOpen_Click;
        
        // Подписываем кнопки Сохранить/Загрузить
        var sBtn = this.FindControl<Button>("SerializeBtn");
        if (sBtn != null) sBtn.Click += Serialize_Click;
        
        var dBtn = this.FindControl<Button>("DeserializeBtn");
        if (dBtn != null) dBtn.Click += Deserialize_Click;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private async void BrowseSave_Click(object? sender, RoutedEventArgs e)
    {
        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Сохранить файл",
            FileTypeChoices = new[] { new FilePickerFileType("Binary") { Patterns = new[] { "*.dat" } } }
        });

        if (file != null && SavePathBox != null)
            SavePathBox.Text = file.Path.LocalPath;
    }

    private async void BrowseOpen_Click(object? sender, RoutedEventArgs e)
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Открыть файл",
            AllowMultiple = false
        });

        if (files.Count > 0 && OpenPathBox != null)
            OpenPathBox.Text = files[0].Path.LocalPath;
    }

    private void Serialize_Click(object sender, RoutedEventArgs e)
    {
    }

    private void Deserialize_Click(object sender, RoutedEventArgs e)
    {
    }
}

