namespace SocialNetworkingAPI.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SenderUserName { get; set; }

        public string ReceiverUserName { get; set; }

        public DateTime ReadingDate { get; set; }

        public DateTime SendingDate { get; set; }

        public bool IsSenderDelete { get; set; }

        public bool IsReceiverDelete { get; set; }

        public ApplicationUser Sender { get; set; }

        public int SenderId { get; set; }

        public ApplicationUser Receiver { get; set; }

        public int ReceiverId { get; set; }
    }


}
