

namespace NET105.Helper 
{
    public class MessageHelper 
    {
        public const string success = "alert alert-success"; 

        public const string error = "alert alert-danger"; 

        
        public string Message {get;set;}

        public string MessageType {get; set;}

    
        public string Icon {get;set;}

        public MessageHelper(string _message , string _type){

            MessageType = _type;
            Message = _message;

            switch(_type)
            {
                case MessageHelper.success : Icon = "fas fa-check-circle"; break;
                case MessageHelper.error : Icon = "fas fa-times-circle"; break;
                default : Icon = "fas fa-check-circle"; break;
            }
        }
    }
}