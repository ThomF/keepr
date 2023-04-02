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
        async public Task<ActionResult<Profile>> GetProfileById()
        {
            try 
            {
            Profile userInfo = await _auth.GetUserInfoAsync<Profile>(HttpContext);
            Profile profile = (Profile)_profilesService.GetProfileById(userInfo?.Id);
            return Ok(profile);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }

    }
}