namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _keepsService;
        private readonly Auth0Provider _auth;

        public KeepsController(KeepsService keepsService, Auth0Provider auth)
        {
            _keepsService = keepsService;
            _auth = auth;
        }

    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        keepData.CreatorId = userInfo.Id;
        Keep keep = _keepsService.CreateKeep(keepData);
        keep.Creator = userInfo;
        return Ok(keep);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }

    [HttpGet]
    async public Task<ActionResult<List<Keep>>>  GetKeeps()
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        List<Keep> keeps = _keepsService.getKeeps(userInfo?.Id);
        return Ok(keeps);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    async public Task<ActionResult<Keep>> FindKeepById(int id)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Keep keep = _keepsService.FindKeepById(id, userInfo?.Id);
        return Ok(keep);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    async public Task<ActionResult<Keep>> updateKeep([FromBody] Keep updateData, int id)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        updateData.CreatorId = userInfo.Id;
        updateData.Id = id;
        Keep keep = _keepsService.updateKeep(updateData);
        return Ok(keep);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<string>> DeleteKeep(int id)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        String message = _keepsService.DeleteKeep(id, userInfo);
        return Ok(message);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }





    }
}