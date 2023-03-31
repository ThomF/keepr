namespace keepr.Services
{
    public class KeepsService
    {

        private readonly KeepsRepository _repo;

        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        internal Keep CreateKeep(Keep keepData)
        {
            Keep keep = _repo.CreateKeep(keepData);
            return keep;
        }

        internal Keep findKeepById(int id, string userInfo)
        {
            Keep keep = _repo.findKeepById(id);
            if(keep == null) throw new Exception("No such Keep Found! How did You get here?");
            return keep;
        }

        internal List<Keep> getKeeps(string id)
        {
            List<Keep> keeps = _repo.getKeeps();
            return keeps;
        }
    }
}