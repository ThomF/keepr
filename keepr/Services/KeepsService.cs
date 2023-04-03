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


        internal Keep FindKeepById(int id, string userInfo)
        {
            Keep keep = _repo.FindKeepById(id);
            if(keep == null) throw new Exception("No such Keep Found! How did You get here?");
            if(keep.CreatorId != userInfo){
                keep.Views++;
                _repo.UpdateKeep(keep);
            }
            return keep;
        }

        internal List<Keep> getKeeps(string id)
        {
            List<Keep> keeps = _repo.getKeeps();
            return keeps;
        }

        internal Keep updateKeep(Keep updateData)
        {
            Keep original = this.FindKeepById(updateData.Id, updateData.CreatorId);
            if(original.CreatorId != updateData.CreatorId) throw new Exception("Stop hacking bro. You cant edit this.");
            original.Name = updateData.Name != null ? updateData.Name : original.Name;
            original.Description = updateData.Description != null ? updateData.Description : original.Description;
            // original.Img = updateData.Img != null ? updateData.Img : original.Img;
            int rowsAffected = _repo.UpdateKeep(original);
            if(rowsAffected == 0) throw new Exception($"Couldnt update that Keep with id: {updateData.Id}");
            if(rowsAffected > 1) throw new Exception($"Something broke which isnt good. Dispatching code fixers soon. {rowsAffected}");
            return original;
        }

        internal string DeleteKeep(int id, Account userInfo)
        {
            Keep keep = this.FindKeepById(id, userInfo.Id);
            if(keep.CreatorId != userInfo.Id) throw new Exception($"You should run, or get Avada Kedavra'd.");
            bool result = _repo.DeleteKeep(id);
            return $"Deleted the keep: {keep.Name}";
        }
// FIXME auth check breaks delete but is needed for passing no auth
        
    }
}