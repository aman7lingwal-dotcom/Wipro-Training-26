using Xunit;
using UserManagementApp.Services;

public class AuthTests
{
    [Fact]
    public void User_Login_Should_Succeed()
    {
        AuthService auth = new AuthService();
        auth.Register("user", "pass", "a@mail.com");

        Assert.True(auth.Login("user", "pass"));
    }
}
