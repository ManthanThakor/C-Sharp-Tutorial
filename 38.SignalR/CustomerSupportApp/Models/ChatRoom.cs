namespace CustomerSupportApp.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }
}
