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
//index

//What's the property name that returns the selected item's index?
//.SelectedIndex

//What's the difference between the combo box and the list box?
//a list box shows multiple items and a combo box only one.

//You remove an item from your list box but not the list of data you've associated it with. Is this a problem? Yes or no? And why?
//yes it is a problem as the other data on the list will desynchronize

//What kind of event is created when you double-click a combo or list box?
//Selection Changed event, it watches for any time the index changes to run the block of code

namespace Lecture_7_notes_assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = null;
        public MainWindow()
        {
            InitializeComponent();

            //add to selection box by accessing its .Items list
            //lbDisplay.Items.Add("Tyler");
            Preload();
            DisplayToListBox();

            lbDisplay.SelectedIndex = 0;
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
            //use .Clear() method to clear all items from listbox
            lbDisplay.Items.Clear();
            //loop through list to add each name to a different index
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
            //clicking item on listbox, then Display Student button, will add info to each textbox
            int selectedIndex = lbDisplay.SelectedIndex;
            if(selectedIndex < 0)
            {
                MessageBox.Show("Please select a name from the list");
            }
            else
            {
                DisplayStudentInfo(selectedStudent);
            }
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string csi = txtCSIGrade.Text;
            string gened = txtGenEdGrade.Text;

            int genEdGrade = int.Parse(gened);
            int csiGrade = int.Parse(csi);

            //add data to list
            students.Add(new Student(fName, lName, csiGrade, genEdGrade));
            //display new data added onto listbox
            DisplayToListBox();


        }

        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            //remove by index
            //int selectedIndex = lbDisplay.SelectedIndex;
            //students.RemoveAt(selectedIndex)

            //remove by object
            int selectedIndex = lbDisplay.SelectedIndex;
            Student selectedStudent = students[selectedIndex];
            students.Remove(selectedStudent);

            DisplayToListBox();
        }

        //this method runs when item selected in the list box changes
        private void lbDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //display student info in text boxes without clicking button, just selecting it on list
            int selectedIndex = lbDisplay.SelectedIndex;

            Student selectedStudent = students[selectedIndex];

            DisplayStudentInfo(selectedStudent);
        }

        public void DisplayStudentInfo(Student student)
        {
            
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtCSIGrade.Text = student.CSIGrade.ToString();
            txtGenEdGrade.Text = student.GenEdGrade.ToString();
        }
    }
}
