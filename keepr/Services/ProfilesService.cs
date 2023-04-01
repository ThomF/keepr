namespace keepr.Services
{
    public class ProfilesService
    {

        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        internal object GetProfileById(int id, string userInfo)
        {
            Account profile = _repo.GetProfileById(userInfo);
            if(profile == null) throw new Exception("woah woah woah, no such profile...");
            return profile;
        }
    }
}