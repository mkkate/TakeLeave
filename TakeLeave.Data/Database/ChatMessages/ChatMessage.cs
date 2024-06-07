using System.ComponentModel.DataAnnotations.Schema;
using TakeLeave.Data.Database.Employees;

namespace TakeLeave.Data.Database.ChatMessages
{
    [Table("ChatMessages")]
    public class ChatMessage
    {
        public int ID { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Seen { get; set; }

        public Employee Sender { get; set; }
        public Employee Receiver { get; set; }
    }
}
