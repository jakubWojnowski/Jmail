namespace Jmail.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public Role Role { get; set; }


    public List<Message> Messages { get; set; }
}