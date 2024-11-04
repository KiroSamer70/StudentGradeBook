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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        student _selectedstudent=new student();
        studentEntities _context=new studentEntities();
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            list.ItemsSource=_context.students.ToList();

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var student = new student
            {
                student_name = txt_name.Text,
                student_sub1 = sub1.Text,
                student_sub2 = sub2.Text,
                student_sub3 = sub3.Text
                ,
                student_grade1 = int.Parse(gd1.Text),
                student_grade2 = int.Parse(gd2.Text),
                student_grade3 = int.Parse(gd3.Text)
            };

            _context.students.Add(student);
            _context.SaveChanges();
            Load();
            ClearInputs();

        }

        private void txt_Grade_TextChanged(object sender, TextChangedEventArgs e)
        {





        }

        private void But_data_Click(object sender, RoutedEventArgs e)
        {
            




        }

        private void update_click(object sender, RoutedEventArgs e)
        {
            _selectedstudent.student_name = txt_name.Text;
            _selectedstudent.student_sub1 = sub1.Text;
            _selectedstudent.student_sub2 = sub2.Text;
            _selectedstudent.student_sub3 = sub3.Text;
            _selectedstudent.student_grade1 = int.Parse(gd1.Text);
            _selectedstudent.student_grade2 = int.Parse(gd2.Text);
            _selectedstudent.student_grade3 = int.Parse(gd3.Text);       
            _context.SaveChanges();
            Load();
            ClearInputs();



        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedstudent = (student)list.SelectedItem;

            txt_name.Text = _selectedstudent.student_name;
            sub1.Text = _selectedstudent.student_sub1;
            sub2.Text = _selectedstudent.student_sub2;
            sub3.Text = _selectedstudent.student_sub3;
            gd1.Text = _selectedstudent.student_grade1.ToString();
            gd2.Text = _selectedstudent.student_grade2.ToString();
            gd3.Text = _selectedstudent.student_grade3.ToString();


          

        }

        private void Btn_avrege(object sender, RoutedEventArgs e)
        {

          var avrege=  CalculateAverage(_selectedstudent.student_grade1, _selectedstudent.student_grade2, _selectedstudent.student_grade3);
             AverageGradeTextBox.Text= avrege.ToString();



        }
        private double CalculateAverage(dynamic grade1, dynamic grade2, dynamic grade3)
        {
            return (grade1 + grade2 + grade3) / 3.0;
        }
        public void ClearInputs()
        {
            txt_name.Text = "";
            sub1.Text = "";
            sub2.Text = "";
            sub3.Text = "";
            gd1.Text = "";
            gd2.Text = "";
            gd3.Text = "";
        }

    }
}
