namespace Core.Contracts.Wpf;

public interface ILoginModel
{
    int IdUser { get; set; }
    int IdProfile { get; set; }
    string FullName { get; set; }
    string Email { get; set; }
    string Username { get; set; }
}