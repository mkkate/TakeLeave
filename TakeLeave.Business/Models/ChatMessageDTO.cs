namespace TakeLeave.Business.Models
{
    public class ChatMessageDTO
    {
        public int ID { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
