namespace CustomerSupportApp.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public int ChatRoomId { get; set; }
        public ChatRoom? ChatRoom { get; set; }
    }

}
