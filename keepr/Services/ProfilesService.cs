namespace keepr.Services
{
    public class ProfilesService
    {

        private readonly ProfilesRepository _repo;

        public ProfilesService(ProfilesRepository repo)
        {
            _repo = repo;
        }

        internal object GetProfileById(string ActId)
        {
            Account profile = (Account)_repo.GetProfileById(ActId);
            if(profile == null) throw new Exception("woah woah woah, no such profile...");
            return profile;
        }
    }
}