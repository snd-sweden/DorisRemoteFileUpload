using DatasetFileUpload.Services.Auth;

class DummyAuthService : IAuthService
{

    public AuthInfo GetAuthenticatedUser(HttpContext httpContext)
    {
        return new AuthInfo(
            Email : "example@example.com",
            EduPersonPrincipalName : "t001@ex.se"
        );
    }

    public string GetUploadToken(AuthInfo user, string datasetIdentifier, string versionNumber)
    {
        return "";
    }

    public string GetServiceToken()
    {
        return "";
    }
}