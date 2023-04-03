namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;
        private readonly Auth0Provider _auth;

        public ProfilesController(ProfilesService profilesService, Auth0Provider auth)
        {
            _profilesService = profilesService;
            _auth = auth;
        }


        [HttpGet("{id}")]
        public ActionResult<Account> GetProfileById(string id)
        {
            try
            {
                // Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                Account profile = (Account)_profilesService.GetProfileById(id);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/keeps")]
    public async Task<ActionResult<List<Keep>>> GetProfileKeeps(string id)
    {
    try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<Keep> keeps = _profilesService.GetProfileKeeps(id);
            return Ok(keeps);
        }
            catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetProfileVaults(string id)
    {
    try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<Vault> vaults = _profilesService.GetProfileVaults(id, userInfo?.Id);
            return Ok(vaults);
        }
            catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    }
}