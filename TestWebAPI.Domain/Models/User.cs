namespace TestWebAPI.Domain.Models
{
    public class User
    {
        private List<string> imgPath = new List<string>();

        public IReadOnlyCollection<string> Images
        {
            get { return imgPath; }
        }

        public string Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public User( string? login, string? password)
        {
            Id = Guid.NewGuid().ToString();
            Login = login;
            Password = password;
        }
        
        public void AddPhoto(string photo)
        {
            imgPath.Add(photo);
        }
    }
}
