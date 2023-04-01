namespace keepr.Repositories
{
    public class VaultKeepsRepository
    {
        public readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep createVaultKeep(VaultKeep vaultKeepData)
        {
            string sql = @"
            INSERT INTO vaultKeep
            (keepId, vaultId, creatorId)
            VALUES
            (@keepId, @vaultId, @creatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
            vaultKeepData.Id = id;
            return vaultKeepData;
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
    }
}