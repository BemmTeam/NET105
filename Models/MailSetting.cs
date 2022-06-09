namespace NET105.Models
{
     public class MailSettings { 
        
        public string Mail { get; set;} // email của bạn 
        
        public string DisPlayName {get; set;} // tên hiển thị 

        public string Password {get ;set; } // mật khẩu email 

        public string Host { get; set;} // host của email 

        public int Port { get;set; } // port của email 
    }
}