public interface ICredentials {
    bool IsValid();
}

public class TokenCredentials : ICredentials {

    private readonly IUserDAO userDao;

    public TokenCredentials(IUserDAO userDao) {
        this.userDao = userDao;
    }

    public int AccessID { get; set; }
    public byte[] Token { get; set; }

    public bool IsValid() {
        //validate token
        //using userDao
        return true;
    }
}

public class UsernamePasswordCredentials : ICredentials {

    private readonly IUserDAO userDao;

    public UsernamePasswordCredentials(IUserDAO userDao) {
        this.userDao = userDao;
    }

    public string Username { get; set; }
    public string Password { get; set; }

    public bool IsValid() {
        //validate username password
        //using userDao
        return true;
    }
}

public class AuthenticationService {

    private readonly IUserDAO userDao;
    private ICredentials credentials;

    public AuthenticationService(IUserDAO userDao) {
        this.userDao = userDao;
    }

    public void SetCredentials(string username, string password) {
        this.credentials = new UsernamePasswordCredentials(this.userDao) {
            Username = username,
            Password = password
        };
    }

    public void SetCredentials(int accessID, byte[] token) {
        this.credentials = new TokenCredentials(this.userDao) {
            AccessID = accessID,
            Token = token
        };
    }

    public bool ValidateCredentials() { return credentials.IsValid(); }

}