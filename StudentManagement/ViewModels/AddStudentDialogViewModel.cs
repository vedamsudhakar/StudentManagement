using StudentManagement.Commands;
using StudentManagement.Models;
using System.Windows.Input;

namespace StudentManagement.ViewModels
{
    public class AddStudentDialogViewModel
    {
        public AddStudentDialogViewModel()
        {
            SaveCommand = new SaveCommand();
            CancelCommand = new CancelCommand();
        }
       
        public Student Student { get; set; } = new Student();

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }
    }
}
