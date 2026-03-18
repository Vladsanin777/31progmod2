using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

using Human;
using Student;

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
                switch (SerializeTab.SelectedIndex) {
                    case 0:
                        {
                            if (FirstNameHuman.Text is string firstName &&
                                    SecondNameHuman.Text is string secondName &&
                                    SurnameHuman.Text is string surname) {
                                HumanBase human = new HumanBase(firstName,
                                        secondName, surname);
                                
                                human.serialize(path);
                            }
                        }
                        break;
                    case 1:
                        {
                            if (FirstNameStudent.Text is string firstName &&
                                    SecondNameStudent.Text is string secondName &&
                                    SurnameStudent.Text is string surname &&
                                    CourseStudent.Text is string course &&
                                    StudyBuildingStudent.Text is string studyBuilding &&
                                    GroupStudent.Text is string _group) {
                                if (byte.TryParse(course, out byte _course)) {
                                    StudentBase student = new StudentBase(firstName, secondName, surname,
                                            _course, studyBuilding, _group);

                                    student.serialize(path);
                                }
                            }
                        }
                        break;
                }
            }
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeserializePathBox.Text is string path && !string.IsNullOrWhiteSpace(path))
            {
                switch (SerializeTab.SelectedIndex) {
                    case 0:
                        {
                            HumanBase human = new HumanBase();
                            human.deserialize(path);

                            FirstNameHuman.Text = human.getFirstName();
                            SecondNameHuman.Text = human.getSecondName();
                            SurnameHuman.Text = human.getSurname();
                        }
                        break;
                    case 1:
                        {
                            StudentBase student = new StudentBase();
                            student.deserialize(path);

                            FirstNameStudent.Text = student.getFirstName();
                            SecondNameStudent.Text = student.getSecondName();
                            SurnameStudent.Text = student.getSurname();
                            CourseStudent.Text = student.getCourse().ToString();
                            StudyBuildingStudent.Text = student.getStudyBuilding();
                            GroupStudent.Text = student.getGroup();
                        }
                        break;
                    }
            }
        }

        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }

            if (sender is TextBox textBox)
            {
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
