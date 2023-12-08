using DatasetFileUpload.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace DatasetFileUpload.Controllers;

[ApiController]
[Authorize]
public class AuthController : Controller
{
    private readonly ILogger logger;
    private readonly IConfiguration configuration;
    private TokenService tokenService;

    public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
        this.tokenService = new TokenService(configuration);
    }

    [HttpPost("token/{datasetIdentifier}/{versionNumber}")]
    [Authorize(Roles = "UploadService", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<string> GetUploadToken(string datasetIdentifier, string versionNumber, [FromBody] AuthInfo user)
    {
        return tokenService.GetUploadToken(user, new DatasetVersionIdentifier(datasetIdentifier, versionNumber));
    }
}
