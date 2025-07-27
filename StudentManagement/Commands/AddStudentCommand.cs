using StudentManagement.Dialogs;
using System;
using System.Windows.Input;

namespace StudentManagement.ViewModels
{
    public class AddStudentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _executeAction;

        public AddStudentCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke(parameter);
        }
    }
}