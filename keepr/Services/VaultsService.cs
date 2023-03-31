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
    }
}