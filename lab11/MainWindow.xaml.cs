using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseSerializeBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog serializeFileDialog = new SaveFileDialog();
            serializeFileDialog.Title = "Serialize file";
            serializeFileDialog.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";

            if (serializeFileDialog.ShowDialog() == true)
            {
                SerializePathBox.Text = serializeFileDialog.FileName;
            }
        }

        private void BrowseDeserializeBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog deserializeFileDialog = new OpenFileDialog();
            deserializeFileDialog.Title = "Deserialize file";
            deserializeFileDialog.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";

            if (deserializeFileDialog.ShowDialog() == true)
            {
                DeserializePathBox.Text = deserializeFileDialog.FileName;
            }
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SerializePathBox.Text is string path && !string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Объект успешно сериализован!", "Успех");
            }
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeserializePathBox.Text is string path && File.Exists(path))
            {
                MessageBox.Show("Объект успешно десериализован!", "Успех");
            }
        }

        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 1. Разрешаем только цифры
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }

            // 2. Безопасно получаем TextBox и проверяем его на null
            if (sender is TextBox textBox)
            {
                // Используем оператор ?? "", чтобы гарантировать отсутствие null в тексте
                string currentText = textBox.Text ?? "";
                string fullText = currentText.Insert(textBox.SelectionStart, e.Text);

                if (int.TryParse(fullText, out int value))
                {
                    if (value > 255)
                    {
                        e.Handled = true; 
                    }
                }
            }
        }
    }
}
