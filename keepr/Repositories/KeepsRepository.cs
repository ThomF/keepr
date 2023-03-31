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

        internal Keep findKeepById(int id)
        {
            string sql = @"
            SELECT 
            ke.*,
            act.*
            FROM keep ke
            JOIN accounts act ON ke.creatorId = act.id
            WHERE ke.id = @id;
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
    }
}