namespace GreetingApp.Models
{
    // Encapsulated Greeting model
    public class Greeting
    {
        private string _name;
        private string _message;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}