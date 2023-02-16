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

//What "Item" in your listbox and combo box do you add objects to to display them?

//What's the property name that returns the selected item's index?

//What's the difference between the combo box and the list box?

//You remove an item from your list box but not the list of data you've associated it with. Is this a problem? Yes or no? And why?

//What kind of event is created when you double-click a combo or list box?

namespace Lecture_7_notes_assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();

            //add to selection box by accessing its .Items list
            //lbDisplay.Items.Add("Tyler");
            Preload();
            DisplayToListBox();
        }

        public void Preload()
        {
            //Student student1 = new Student()
            //{
            //    FirstName = "Tyler",
            //    LastName = "Simpson",
            //    CSIGrade = 100,
            //    GenEdGrade = 95,
            //};
            Student student = new Student("Tyler", "Simpson", 100, 95);
            students.Add(student);
            students.Add(new Student("Fluffy", "Shiva", 110, 120));
            students.Add(new Student("Wayne", "Campbell", 50, 60));
            students.Add(new Student("Garth", "Algar", 75, 65));
        }

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            //add user input from textbox to list after clicking button
            string userInput = txtToAdd.Text;

            lbDisplay.Items.Add(userInput);
        }

        public void DisplayToListBox()
        {
            for (int i = 0; i < students.Count; i++)
            {
                string firstName = students[i].FirstName;
                string lastName = students[i].LastName;
                string fullName = firstName + " " + lastName;
                lbDisplay.Items.Add(fullName);
            }
        }

        private void btnDisplayStudent_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbDisplay.SelectedIndex;
            if(selectedIndex < 0)
            {
                MessageBox.Show("Please select a name from the list");
            }
            else
            {
                Student selectedStudent = students[selectedIndex];
            }
        }
    }
}
