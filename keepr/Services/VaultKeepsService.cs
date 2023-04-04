namespace keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

    

        internal string DeleteVaultKeep(int id, Account userInfo)
        {
            VaultKeep vaultKeep = _repo.GetVaultKeeps(id);
            if(vaultKeep == null)throw new Exception($"No such vaultkeep: {id}");
            if(vaultKeep.CreatorId != userInfo.Id) throw new Exception("woah there man. that doesnt belong to you");
            _repo.DeleteVaultKeep(id);
            return $"removed the vaultkeep";

        }

        internal VaultKeep GetVaultKeeps(int id, string userInfo)
        {
            VaultKeep vaultKeep = _repo.GetVaultKeeps(id);
            return vaultKeep;
        }
    }
}