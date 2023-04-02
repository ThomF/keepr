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
    }
}