namespace Register_Console_App.Interfaces
{
    public interface IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();
    }
}