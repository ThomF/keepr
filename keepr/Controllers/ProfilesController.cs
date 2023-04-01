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
        async public Task<ActionResult<Account>> GetProfileById(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(_profilesService.GetProfileById(id, userInfo?.Id));
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }

    }
}