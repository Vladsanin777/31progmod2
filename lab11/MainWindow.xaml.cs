using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                SavePathBox.Text = saveFileDialog.FileName;
            }
        }

        private void BrowseOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Открыть файл";
            openFileDialog.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                OpenPathBox.Text = openFileDialog.FileName;
            }
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SavePathBox.Text is string path && !string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Объект успешно сериализован!", "Успех");
            }
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (OpenPathBox.Text is string path && File.Exists(path))
            {
                MessageBox.Show("Объект успешно десериализован!", "Успех");
            }
        }
    }
}

