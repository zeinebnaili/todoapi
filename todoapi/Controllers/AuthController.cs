using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoApi.Data;
using TodoApi.Models;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly TodoContext _context;

    public AuthController(IConfiguration config, TodoContext context)
    {
        _config = config;
        _context = context;
    }

    // Méthode de connexion simple sans hachage
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto login)
    {
        // Recherche l'utilisateur dans la base de données par son nom d'utilisateur
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);

        // Vérification simple sans hachage
        if (user == null || user.Password != login.Password)
        {
            // Si l'utilisateur est introuvable ou les mots de passe ne correspondent pas
            return Unauthorized("Identifiants incorrects.");
        }

        // Génération du token JWT si l'authentification réussie
        var token = GenerateJwtToken(user.Username);
        return Ok(new { Token = token });
    }

    // Méthode pour générer un token JWT
    private string GenerateJwtToken(string username)
    {
        var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]);
        var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, username) };

        var token = new JwtSecurityToken(
            _config["JwtSettings:Issuer"],
            _config["JwtSettings:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class UserLoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
