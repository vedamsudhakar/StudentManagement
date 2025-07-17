using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();

        public List<Student> Students { get => students; set => students = value; }

        public MainWindow()
        {
            InitializeComponent();

            FillSampleStudentsData();

            this.DataContext = this;
        }

        private void FillSampleStudentsData()
        {
            Students.Add(new Student()
            {
                FirstName = "John",
                LastName = "Doe",
                DOB = new DateTime(1995, 5, 20),
                Address = "123 Main St, Springfield"
            });

            Students.Add(new Student()
            {
                FirstName = "Jane",
                LastName = "Smith",
                DOB = new DateTime(1998, 8, 15),
                Address = "456 Elm St, Springfield"
            });

            Students.Add(new Student()
            {
                FirstName = "Alice",
                LastName = "Johnson",
                DOB = new DateTime(2000, 12, 1),
                Address = "789 Oak St, Springfield"
            });
        }

        public bool SaveStudent(string name, string lastName, string dob, string address)
        {
            var connectionString = "Server=localhost;Database=StudentManagement;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    var query = "INSERT INTO Student(FirstName, LastName, DOB, Address) VALUES(@Name, @lastName, @dob, @address)";

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "Name",
                        SqlDbType = System.Data.SqlDbType.NVarChar,
                        Value = name
                    });

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "lastName",
                        SqlDbType = System.Data.SqlDbType.NVarChar,
                        Value = lastName
                    });

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "dob",
                        SqlDbType = System.Data.SqlDbType.NVarChar,
                        Value = dob
                    });

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "address",
                        SqlDbType = System.Data.SqlDbType.NVarChar,
                        Value = address
                    });

                    command.CommandText = query;    
                    command.Connection = connection;
                    var rowsInserted = command.ExecuteNonQuery();

                    return rowsInserted > 0;
                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = dataGrid.SelectedItem as Student;

            
        }
    }
}
