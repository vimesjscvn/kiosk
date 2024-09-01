namespace CS.VM.Requests
{
    public class SendEmailRequest
    {
        public string Link { get; set; }
        public string Host { get; set; } = "smtp.gmail.com";
        public int Post { get; set; } = 587;
        public string FromEmail { get; set; }
        public string PassFromEmail { get; set; }
        public string ToEmail { get; set; }
    }
}