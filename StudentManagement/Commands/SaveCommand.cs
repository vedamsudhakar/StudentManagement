using System;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.Commands
{
    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Save command executed!");
        }
    }
}
