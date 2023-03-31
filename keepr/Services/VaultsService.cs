namespace keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;

        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        internal Vault createVault(Vault vaultData)
        {
            Vault vault = _repo.createVault(vaultData);
            return vault;
        }

        internal Vault GetVaultById(int id, string userInfo)
        {
            Vault vault = _repo.GetVaultById(id);
            if(vault == null) throw new Exception("No such vault");
            return vault;
        }
    }
}