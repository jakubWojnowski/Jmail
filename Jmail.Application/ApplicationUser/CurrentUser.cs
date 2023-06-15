namespace Jmail.Application.ApplicationUser;

public class CurrentUser
{
    private readonly IEnumerable<string> _roles;

    public CurrentUser(string id, string email, IEnumerable<string> roles)
    {
        _roles = roles;
        Id = id;
        Email = email;
    }

    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<string> Roles => _roles;

    public bool IsInRole(string role) => Roles.Contains(role);
}
