namespace keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vaultsService;
        private readonly KeepsService _keepsService;
        private readonly Auth0Provider _auth;

        public VaultsController(VaultsService vaultsService, KeepsService keepsService, Auth0Provider auth)
        {
            _vaultsService = vaultsService;
            _keepsService = keepsService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault vault = _vaultsService.createVault(vaultData);
            vault.Creator = userInfo;
            return Ok(vault);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        async public Task<ActionResult<Vault>> GetVaultById(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.GetVaultById(id, userInfo?.Id);
            return vault;
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        async public Task<ActionResult<Vault>> EditVault([FromBody] Vault updateData, int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            updateData.CreatorId = userInfo.Id;
            updateData.Id = id;
            Vault vault = _vaultsService.EditVault(updateData);
            return Ok(vault);

            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        async public Task<ActionResult<string>> DeleteVault(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            String message = _vaultsService.DeleteVault(id, userInfo);
            return Ok(message);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public async  Task<ActionResult<List<VaultKeepz>>> GetVaultKeeps(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<VaultKeepz> vaultKeep = _keepsService.GetVaultKeeps(id, userInfo?.Id);
            return Ok(vaultKeep);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
    }
}