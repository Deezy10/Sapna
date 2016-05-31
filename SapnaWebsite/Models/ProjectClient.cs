namespace SapnaWebsite.Models
{
    public class ProjectClient
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
