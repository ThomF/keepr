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
            if(vault.CreatorId != userInfo && vault.IsPrivate == true)throw new Exception("That vaults private bro");
            if(vault == null) throw new Exception("No such vault");
            return vault;
        }

        internal Vault[] GetMyVaults(string userInfo)
        {
            Vault[] vault = _repo.GetMyVaults(userInfo);
            return vault;
        }
        internal VaultKeep createVaultKeep(VaultKeep vaultKeepData)
        {
            
            Vault vault = this.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);
            if(vault.CreatorId != vaultKeepData.CreatorId) throw new Exception("sterp");
            VaultKeep vaultKeep = _repo.createVaultKeep(vaultKeepData);
            
            return vaultKeep;
        }
internal List<VaultKeepz> GetVaultKeeps(int id, string uId)
        {
            Vault vault = this.GetVaultById(id, uId);
            // if(vault) throw new Exception("Woah there bro, you arent on the list...");
            List<VaultKeepz> vaultKeeps = _repo.GetVaultKeeps(id, uId);
            return vaultKeeps;
        }
// NOTE issue with the isPrivate ??? solved
        internal Vault EditVault(Vault updateData)
        {
            Vault original = this.GetVaultById(updateData.Id, updateData.CreatorId);
            if(original.CreatorId != updateData.CreatorId) throw new Exception("Stop trying to edit someone elses vault bro");
            original.Name = updateData.Name != null ? updateData.Name : original.Name;
            original.IsPrivate = updateData.IsPrivate != null ? updateData.IsPrivate : original.IsPrivate;
            _repo.EditVault(original);
            return original;

        }

        internal string DeleteVault(int id, Account userInfo)
        {
            Vault vault = this.GetVaultById(id, userInfo.Id);
            if(vault.CreatorId != userInfo.Id) throw new Exception("Woah there buddy that isnt your vault to delete");
            bool result = _repo.DeleteVault(id);
            return $"Deleted vault: {vault.Name}";
        }
    }
}