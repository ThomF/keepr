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
            string sql = @"
            INSERT INTO accounts
            (name, picture, email, id)
            VALUES
            (@Name, @Picture, @Email, @Id)";
            _db.Execute(sql, id);
            return id;
        }

        internal Account GetProfileById(string id)
        {
            string sql = @"
            SELECT 
            *
            FROM accounts WHERE id = @id;
            ";
            return _db.QueryFirstOrDefault<Account>(sql, new { id });
        }
    }
}