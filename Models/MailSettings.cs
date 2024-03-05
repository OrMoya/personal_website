namespace MyPersonalWebsite.Models
{
    public class MailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }    
        //public string ServerAddress { get; set; }  
        public int Port { get; set; }
        public string ToMail { get; set; }   
        public string Host { get; set; }
    }
}
