namespace keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep CreateKeep(Keep keepData)
        {
            string sql = @"
            INSERT INTO keep
            (creatorId, name, description, img, views, kept)
            VALUES
            (@creatorId, @name, @description, @img, @views, @kept);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, keepData);
            keepData.Id = id;
            return keepData;
        }

// COUNT(kpt.id) AS Kept,
//             LEFT JOIN kept kpt ON kpt.keepId = ke.id
//             GROUP BY kpt.id;

        internal Keep FindKeepById(int id)
        {
            string sql = @"
            SELECT 
            ke.*,
            
            act.*
            FROM keep ke
            
            JOIN accounts act ON ke.creatorId = act.id
            WHERE ke.id = @id
            
            ";
            Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, prof)=>
            {
                keep.Creator = prof;
                return keep;
            }, new { id }).FirstOrDefault();
            return keep;
        }

        internal List<Keep> getKeeps()
        {
            string sql = @"
            SELECT ke.*,
            act.*
            FROM keep ke
            JOIN accounts act ON ke.creatorId = act.id;
            ";
            List<Keep> keep = _db.Query<Keep, Profile, Keep>(sql, (keep, prof)=>
            {
                keep.Creator = prof;
                return keep;
            }).ToList();
            return keep;
        }

        internal int UpdateKeep(Keep update)
        {
            string sql = @"
            UPDATE keep
            SET
            name = @name,
            description = @description,
            views = @views
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, update);
            return rows;
        }


        internal bool DeleteKeep(int id)
        {
            string sql = @"
            DELETE FROM keep WHERE id = @id;
            ";
            int rows = _db.Execute(sql, new {id});
            return rows == 1;
        }

        internal List<VaultKeepz> GetVaultKeeps(string id)
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
                if (vaultKeepz != null && vaultKeep != null && profile != null)
            {
                vaultKeepz.VaultKeepId = vaultKeep.Id;
                vaultKeepz.Creator = profile;
            }
                return vaultKeepz;
            },new {id}).ToList();
            return vaultKeeps;
        }
    }
}