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

// NOTE issue with the isPrivate
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
            bool result = _repo.DeleteVault(id);
            if(vault.CreatorId != userInfo.Id) throw new Exception("Woah there buddy that isnt your vault to delete");
            return $"Deleted vault: {vault.Name}";
        }
    }
}