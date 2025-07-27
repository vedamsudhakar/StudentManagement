namespace StudentManagement.Interfaces
{
    public interface IDialogService
    {
        bool? ShowDialog(object viewModel, string windowName);
    }
}
