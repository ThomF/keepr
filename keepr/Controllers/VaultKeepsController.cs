namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vaultKeepsService;
        private readonly VaultsService _vaultsService;

        private readonly Auth0Provider _auth;

        public VaultKeepsController(VaultKeepsService vaultKeepsService,VaultsService vaultsService, Auth0Provider auth)
        {
            _vaultKeepsService = vaultKeepsService;
            _vaultsService = vaultsService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> createVaultKeep([FromBody] VaultKeep vaultKeepData)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            vaultKeepData.CreatorId = userInfo.Id;
            VaultKeep vaultKeep = _vaultsService.createVaultKeep(vaultKeepData);
            return Ok(vaultKeep);

            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteVaultlKeep(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            String message = _vaultKeepsService.DeleteVaultKeep(id, userInfo);
            return Ok(message);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        } 

        


        
    }
}