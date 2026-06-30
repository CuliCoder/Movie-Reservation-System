namespace Movie_Reservation_System.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> Post(UserRequest user)
    {
        var result = await _userService.AddAsync(user);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Put(UserRequest user)
    {
        var result = await _userService.UpdateAsync(user);
        return Ok(result);
    }
    [HttpDelete("id")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }
}