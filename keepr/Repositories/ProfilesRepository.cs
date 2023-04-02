namespace keepr.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal object CreateProfile(string id)
        {
            throw new NotImplementedException();
        }

        internal Profile GetProfileById(string id)
        {
            string sql = @"
            SELECT 
            *
            FROM accounts WHERE id = @id;
            ";
            return _db.QueryFirstOrDefault<Account>(sql, new {id});
        }
    internal List<Keep> GetKeepsByCreatorId(string creatorId)
{
    string sql = @"
    SELECT k.*, act.*
    FROM keep k
    JOIN accounts act ON k.creatorId = act.id
    WHERE k.creatorId = @creatorId;
    ";
    List<Keep> keep = _db.Query<Keep, Account, Keep>(
        sql,
        (keep, account) =>
        {
            keep.Creator = account;
            return keep;
        },
        new { creatorId }
    ).ToList();
    return keep;
}
    }
}