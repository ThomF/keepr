namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Vault createVault(Vault vaultData)
        {
            string sql = @"
            INSERT INTO vault
            (creatorId, name, description, img, isPrivate)
            VALUES
            (@creatorId, @name, @description, @img, @isPrivate);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, vaultData);
            vaultData.Id = id;
            return vaultData;
        }



        internal Vault GetVaultById(int id)
        {
        string sql = @"
        SELECT 
        va.*,
        act.*
        FROM vault va
        JOIN accounts act ON va.creatorId = act.id
        WHERE va.id = @id
        ";
        Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, prof)=>
        {
            vault.Creator = prof;
            return vault;
        }, new {id}).FirstOrDefault();
        return vault;
        }
internal Vault[] GetMyVaults(string userInfo)
{
    string sql = @"
        SELECT 
        v.*,
        u.*
        FROM vault v
        JOIN accounts u ON v.creatorId = u.id
        WHERE v.creatorId = @userInfo
    ";
    
    var vaults = _db.Query<Vault, Profile, Vault>(
        sql,
        (v, u) =>
        {
            v.Creator = u;
            return v;
        },
        new { userInfo }
    ).ToArray();
    
    return vaults;
}


        internal int EditVault(Vault vault)
        {
            string sql = @"
            UPDATE vault
            SET
            name = @name, 
            isPrivate = @isPrivate
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, vault);
            return rows;
        }

        internal bool DeleteVault(int id)
        {
            string sql = @"
            DELETE FROM vault WHERE id = @id;
            ";
            int rows = _db.Execute(sql, new {id});
            return rows == 1;
        }

        internal List<VaultKeepz> GetVaultKeeps(int id, string uId)
        {
            
            string sql = @"
            SELECT 
            kp.*,
            vk.*,
            act.*
            FROM vaultKeep vk
            JOIN keep kp ON vk.keepId = kp.id
            JOIN accounts act ON kp.creatorId = act.id
            WHERE vk.vaultId = @id;
            ";
            List<VaultKeepz> vaultKeeps = _db.Query<VaultKeepz, VaultKeep, Profile, VaultKeepz>(sql, (vaultKeepz, vaultKeep, profile)=>
            {

                vaultKeepz.VaultKeepId = vaultKeep.Id;
                vaultKeepz.Creator = profile;
            
                return vaultKeepz;
            },new {id}).ToList();
            return vaultKeeps;
        }
    }
}