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
        public AddEdit()
        {
            InitializeComponent();
            //if (student != null)
            //    localStudent = student;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            localStudent.Surname = SurnameTextBox.Text;
            localStudent.Name = NameTextBox.Text;
            localStudent.Patronimic = PatronimicTextBox.Text;
            localStudent.MathGrade = (int)MathGradeComboBox.SelectedItem;
            localStudent.Informatics = (int)InformaticsGradeComboBox.SelectedItem;
            localStudent.Physics = (int)PhysicsGradeComboBox.SelectedItem;

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
