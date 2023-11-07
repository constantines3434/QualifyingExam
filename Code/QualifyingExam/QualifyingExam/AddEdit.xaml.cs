using QualifyingExam.Model;
using System;
using System.Collections.Generic;
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
    public partial class AddEdit : Page
    {
        Student localStudent;
        bool flag = false;

        public AddEdit(Student student)
        {
            InitializeComponent();

            if (student != null)
            {
                localStudent = student;
                flag = true;
            }
            else
            {
                localStudent = new Student(); // Создайте новый объект, если редактируется несуществующий
            }
            DataContext = localStudent;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            localStudent.Surname = SurnameTextBox.Text;
            localStudent.Name = NameTextBox.Text;
            localStudent.Patronimic = PatronimicTextBox.Text;
            localStudent.Informatics = Convert.ToInt32((InformaticsGradeComboBox.SelectedItem as ComboBoxItem).Content);
            localStudent.Physics = Convert.ToInt32((PhysicsGradeComboBox.SelectedItem as ComboBoxItem).Content);

            if (!flag) // Если не редактирование, то добавляем новый объект
            {
                localStudent.Id = Student.students.Count + 1;
                Student.students.Add(localStudent);
                MessageBox.Show("Сохранено");
               //Manager.MainFrame.Navigate(new ListOfStudents());
            }
        }
    }
}
