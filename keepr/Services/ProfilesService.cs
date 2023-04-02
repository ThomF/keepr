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

        
        internal List<Keep> GetProfileKeeps(string creatorId)
{
    List<Keep> keeps = _repo.GetKeepsByCreatorId(creatorId);
    if(keeps == null || keeps.Count == 0) throw new Exception("No keeps here!");
    return keeps;
}


    }
}