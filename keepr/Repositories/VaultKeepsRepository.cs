namespace keepr.Repositories
{
    public class VaultKeepsRepository
    {
        public readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        



        internal VaultKeep GetVaultKeeps(int id)
        {
            string sql = @"
            SELECT 
            vk.*,
            act.*
            FROM vaultKeep vk
            JOIN accounts act ON vk.creatorId = act.id
            WHERE vk.id = @id;
            ";
            VaultKeep vaultKeep = _db.Query<VaultKeep, Profile, VaultKeep>(sql, (vaultKeep, prof)=>
            {
                vaultKeep.Creator = prof;
                return vaultKeep;
            }, new {id}).FirstOrDefault();
            return vaultKeep;
        }


        internal void DeleteVaultKeep(int id)
        {
            string sql = @"
            DELETE FROM vaultKeep
            WHERE id = @id
            ";
            _db.Execute(sql, new {id});
        }


    }
}