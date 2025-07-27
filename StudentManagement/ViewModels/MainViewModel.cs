using StudentManagement.Dialogs;
using StudentManagement.Interfaces;
using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StudentManagement.ViewModels
{
    public class MainViewModel
    {
        private IDialogService _dialogService;

        public MainViewModel()
        {

            _dialogService = new DialogService();

            FillSampleStudents();

            AddStudentCommand = new AddStudentCommand(OpenStudentDialog);
        }

        // Add properties and methods for the main view model here
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public ICommand AddStudentCommand { get; set; }

        private void FillSampleStudents()
        {
            Students.Add(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                DOB = new DateTime(2000, 1, 1),
                Address = "123 Main St, Springfield"
            });

            Students.Add(new Student
            {
                FirstName = "Jane",
                LastName = "Smith",
                DOB = new DateTime(1999, 5, 15),
                Address = "456 Elm St, Springfield"
            });

            Students.Add(new Student
            {
                FirstName = "Alice",
                LastName = "Johnson",
                DOB = new DateTime(2001, 3, 10),
                Address = "789 Oak St, Springfield"
            });
        }

        private void OpenStudentDialog(object parameter)
        {
            var viewModel = new AddStudentDialogViewModel();
            _dialogService.ShowDialog(viewModel, typeof(AddStudentDialog).FullName);

            if (viewModel.Student != null)
            {
                Students.Add(viewModel.Student);
            }
        }
    }
}
