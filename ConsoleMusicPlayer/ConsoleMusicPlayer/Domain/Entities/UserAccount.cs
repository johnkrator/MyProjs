namespace ConsoleMusicPlayer.Domain.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public long Password { get; set; }
        public int TotalLogin { get; set; }
        public bool IsLocked { get; set; }
    }
}
