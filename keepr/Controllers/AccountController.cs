namespace keepr.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, VaultsService vaultsService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPost]
  [Authorize]
  async public Task<ActionResult<Account>> editAccount([FromBody] Account accountData)
  {
    try 
    {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        Account act = _accountService.Edit(accountData, userInfo.Email);
        // act.Email = userInfo.Email;
        return Ok(act);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  
  [HttpGet("vaults")]
  public async Task<ActionResult<Vault>> GetMyVaults(){
    try 
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault[] vault = _vaultsService.GetMyVaults(userInfo?.Id);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }




}
