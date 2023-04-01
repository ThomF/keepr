namespace keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep createVaultKeep(VaultKeep vaultKeepData)
        {
            VaultKeep vaultKeep = _repo.createVaultKeep(vaultKeepData);
            return vaultKeep;
        }

        internal VaultKeep GetVaultKeeps(int id, string userInfo)
        {
            VaultKeep vaultKeep = _repo.GetVaultKeeps(id);
            return vaultKeep;
        }
    }
}