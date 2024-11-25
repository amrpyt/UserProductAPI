// UserProductAPI/Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly HttpClient _httpClient;
  private readonly string _vbAppUrl = "http://localhost:8080/api/";

  public UsersController()
  {
      _httpClient = new HttpClient();
  }

  [HttpPost]
  public async Task<IActionResult> AddUser([FromBody] UserModel user)
  {
      try
      {
          var json = JsonSerializer.Serialize(user);
          var content = new StringContent(json, Encoding.UTF8, "application/json");

          var response = await _httpClient.PostAsync(_vbAppUrl, content);

          if (response.IsSuccessStatusCode)
          {
              return Ok("User added successfully");
          }

          return BadRequest("Failed to add user");
      }
      catch (Exception ex)
      {
          return StatusCode(500, $"Internal server error: {ex.Message}");
      }
  }
}

// UserProductAPI/Models/UserModel.cs
public class UserModel
{
  public string Username { get; set; }
  public string Email { get; set; }
}