using QualifyingExam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QualifyingExam
{
    public partial class ListOfStudents : Page
    {
        public ListOfStudents()
        {
            InitializeComponent();
            DataOfStudents.ItemsSource = Student.students;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("data.txt"))
            {
                foreach (var student in Student.students)
                    sw.WriteLine($"{student.Id},{student.Surname},{student.Name},{student.Patronimic},{student.MathGrade},{student.Informatics},{student.Physics}");
            }
            MessageBox.Show("Сохранение данных в текстовый файл");
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEdit(null));
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEdit((sender as Button).DataContext as Student));
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                using (StreamReader sr = new StreamReader("data.txt"))
                {
                    // Создаем новую коллекцию для загруженных данных
                    ObservableCollection<Student> loadedStudents = new ObservableCollection<Student>();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 7)
                        {
                            int id = int.Parse(parts[0]);
                            string surname = parts[1];
                            string name = parts[2];
                            string patronimic = parts[3];
                            int mathGrade = int.Parse(parts[4]);
                            int informatics = int.Parse(parts[5]);
                            int physics = int.Parse(parts[6]);

                            // Создаем объект Student и добавляем его в коллекцию
                            Student student = new Student
                            {
                                Id = id,
                                Surname = surname,
                                Name = name,
                                Patronimic = patronimic,
                                MathGrade = mathGrade,
                                Informatics = informatics,
                                Physics = physics
                            };
                            loadedStudents.Add(student);
                        }
                    }
                    // Обновляем исходную коллекцию данных
                    Student.students = loadedStudents;
                }
                MessageBox.Show("Загрузка данных из файла");

                // Обновляем источник данных DataGrid
                DataOfStudents.ItemsSource = Student.students;
            }
        }
    }
}
