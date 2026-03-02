using Xunit;
using UserManagementApp.Services;

public class EncryptionTests
{
    [Fact]
    public void Encryption_Should_Work()
    {
        EncryptionService service = new EncryptionService();
        string text = "Secret";

        string encrypted = service.Encrypt(text);
        string decrypted = service.Decrypt(encrypted);

        Assert.Equal(text, decrypted);
    }
}
