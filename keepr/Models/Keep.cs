namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public int kept { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public int views { get; set; }
        public string CreatorId {get; set;}

        public Profile Creator {get; set;}
    }

    
}