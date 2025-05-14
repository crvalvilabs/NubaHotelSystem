using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NubaHotel.BookingSystem.Application.DTOs;
using NubaHotel.BookingSystem.Application.External;

namespace NubaHotel.BookingSystem.Infra.External.TokenService;

/// <summary>
/// The GetRefreshTokenService class provides functionality for generating JSON Web Tokens (JWT).
/// It uses configuration settings to read token secrets, expiration times, issuers, and audiences
/// to create secure and reliable tokens for authentication and authorization purposes.
/// </summary>
public class GetRefreshTokenService : IGetRefreshTokenService
{
    /// <summary>
    /// Represents an instance of the IConfiguration interface used to access
    /// the application’s configuration settings. This is used to retrieve
    /// values such as token secrets, expiration times, issuer, and audience
    /// required for generating JSON Web Tokens (JWT).
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// The GetRefreshTokenService class is responsible for managing the creation of refresh tokens.
    /// It leverages configuration settings and an external service implementation to provide secure
    /// and consistent token generation.
    /// </summary>
    public GetRefreshTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Generates a JSON Web Token (JWT) for the specified email.
    /// Uses the application's configuration settings to create a secure token
    /// with appropriate claims, expiration, issuer, and audience values.
    /// </summary>
    /// <param name="email">The email address to be used as the identifier in the token's claims.</param>
    /// <returns>A string representation of the generated JWT.</returns>
    public TokenResult GetToken(string email)
    {
        var symmetricKey = GetSymmetricSecurityKey();
        var tokenDescriptor = GetSecurityTokenDescriptor(symmetricKey, email);
        var token = CreateRefreshToken(tokenDescriptor);
        return token;
    }

    /// <summary>
    /// Generates a symmetric security key using the secret key specified in the application's configuration.
    /// This key is used to sign JSON Web Tokens (JWT) to ensure their integrity and authenticity.
    /// </summary>
    /// <returns>A SymmetricSecurityKey object generated from the application's secret key.</returns>
    /// <exception cref="Exception">Thrown when the secret key is not found in the configuration.</exception>
    private SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        var secretKey = _configuration.GetSection("TokenSecrets:SecretKey").Value 
                        ?? throw new Exception("Secret key not found");
        var secretKeyBytes = Convert.FromBase64String(secretKey);
        var symmetricKey = new SymmetricSecurityKey(secretKeyBytes);
        return symmetricKey;
    }

    /// <summary>
    /// Constructs and returns a <see cref="SecurityTokenDescriptor"/> containing the necessary claims,
    /// expiration configuration, signing credentials, issuer, and audience for generating a secure JSON Web Token (JWT).
    /// </summary>
    /// <param name="symmetricKey">The symmetric security key used for token signing, ensuring token integrity and authenticity.</param>
    /// <param name="email">The email address of the user, used as a claim to uniquely identify the user within the token.</param>
    /// <returns>A <see cref="SecurityTokenDescriptor"/> object configured with claims, expiration time, signing credentials, issuer, and audience.</returns>
    private SecurityTokenDescriptor GetSecurityTokenDescriptor(SymmetricSecurityKey symmetricKey, string email)
    {
        var tokenExpire = Convert.ToInt16(_configuration.GetSection("TokenSecrets:RefreshTokenExpires").Value);
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, email)
            ]),
            Expires = DateTime.UtcNow.AddDays(tokenExpire),
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256),
            Issuer = _configuration.GetSection("TokenSecrets:Issuer").Value,
            Audience = _configuration.GetSection("TokenSecrets:Audience").Value
        };
        return descriptor;
    }

    /// <summary>
    /// Generates a refresh token using the provided token descriptor.
    /// This method employs the JsonWebTokenHandler to create a secure token
    /// based on the configured token descriptor.
    /// </summary>
    /// <param name="tokenDescriptor">The descriptor containing the claims, signing credentials, and other token parameters.</param>
    /// <returns>A <see cref="TokenResult"/> object containing the generated refresh token and its expiration date.</returns>
    private TokenResult CreateRefreshToken(SecurityTokenDescriptor tokenDescriptor)
    {
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var refreshToken = new TokenResult
        {
            Refresh = token,
            Expires = tokenDescriptor.Expires
        };
        return refreshToken;
    }
}
