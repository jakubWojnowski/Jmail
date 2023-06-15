namespace Jmail.Application.ApplicationUser;

public interface IUserContext
{
    CurrentUser GetCurrentUser();
}