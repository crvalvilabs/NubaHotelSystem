using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.External;

namespace NubaHotel.BookingSystem.Infra.External.TokenService;

/// <summary>
/// The GetAccessTokenService class provides functionality for generating JSON Web Tokens (JWT).
/// It uses configuration settings to read token secrets, expiration times, issuers, and audiences
/// to create secure and reliable tokens for authentication and authorization purposes.
/// </summary>
public class GetAccessTokenService : IGetAccessTokenService
{
    /// <summary>
    /// Represents the configuration settings used for retrieving token-related
    /// parameters such as secret keys, expiration times, issuers, and audiences.
    /// This dependency enables the <see cref="GetAccessTokenService"/> to access
    /// application-specific configuration values required for generating JSON Web Tokens (JWT).
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// The GetAccessTokenService class is responsible for generating JSON Web Tokens (JWTs)
    /// for authentication and authorization within the application. It uses
    /// configuration settings to create secure tokens with parameters like expiration time,
    /// issuer, audience, and secret key.
    /// </summary>
    public GetAccessTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Generates a JSON Web Token (JWT) for a given email address to support authentication and authorization.
    /// The method uses configuration settings to define token parameters such as expiration time, issuer, audience,
    /// and signing credentials.
    /// </summary>
    /// <param name="email">The email address of the user for whom the token is being generated.</param>
    /// <returns>A string representation of the generated JSON Web Token (JWT).</returns>
    public TokenResult GetToken(string email)
    {
        var symmetricKey = GetSymmetricSecurityKey();
        var tokenDescriptor = GetSecurityTokenDescriptor(symmetricKey, email);
        var token = CreateAccessToken(tokenDescriptor);
        return token;
    }

    /// <summary>
    /// Generates a symmetric security key required for creating and signing
    /// JSON Web Tokens (JWT). The method retrieves the secret key from the
    /// application's configuration, converts it into a byte array, and constructs
    /// a SymmetricSecurityKey object to ensure a secure token generation process.
    /// </summary>
    /// <returns>
    /// A <see cref="SymmetricSecurityKey"/> object that represents the cryptographic
    /// key derived from the application's configured secret key.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown when the secret key cannot be found in the configuration settings.
    /// </exception>
    private SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        var secretKey = _configuration.GetSection("TokenSecrets:SecretKey").Value
                        ?? throw new Exception("Secret key not found");
        var secretKeyBytes = Convert.FromBase64String(secretKey);
        var symmetricKey = new SymmetricSecurityKey(secretKeyBytes);
        return symmetricKey;
    }

    /// <summary>
    /// Creates a security token descriptor used for generating JSON Web Tokens (JWT).
    /// The security token descriptor contains information about the token's claims, expiration time,
    /// signing credentials, and related metadata such as issuer and audience.
    /// </summary>
    /// <param name="symmetricKey">The symmetric security key used to sign the JWT for secure authentication.</param>
    /// <param name="email">The email of the user for which the token is being generated, used to create claims.</param>
    /// <returns>A <see cref="SecurityTokenDescriptor"/> containing the configuration required for generating the JWT.</returns>
    private SecurityTokenDescriptor GetSecurityTokenDescriptor(SymmetricSecurityKey symmetricKey, string email)
    {
        var tokenExpire = Convert.ToInt16(_configuration.GetSection("TokenSecrets:AccessTokenExpires").Value);
        var descriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, email)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(tokenExpire),
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256),
            Issuer = _configuration.GetSection("TokenSecrets:Issuer").Value,
            Audience = _configuration.GetSection("TokenSecrets:Audience").Value
        };
        return descriptor;
    }

    /// <summary>
    /// Generates a JSON Web Token (JWT) based on the specified security token descriptor.
    /// This method uses the provided token details like claims, expiration time, and signing credentials
    /// to create a secure token string for authentication and authorization purposes.
    /// </summary>
    /// <param name="tokenDescriptor">The <see cref="SecurityTokenDescriptor"/> containing the details
    /// and settings required to generate the token, including claims, issuer, audience, and signing credentials.</param>
    /// <returns>Returns a string representation of the generated JSON Web Token (JWT).</returns>
    private TokenResult CreateAccessToken(SecurityTokenDescriptor tokenDescriptor)
    {
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = new TokenResult
        {
            Access = token,
            Expires = tokenDescriptor.Expires
        };
        return accessToken;
    }

}