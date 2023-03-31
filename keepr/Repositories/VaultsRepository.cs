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
    }
}