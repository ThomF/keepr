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
    }
}