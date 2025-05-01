using System; //brings in the systems namespace, toolbox that contains many of the most-used basic tool of C#
using System.Collections.Generic; //System = the toolbox, Collections = a drawer inside the toolbox, Generic =flexible, reusable container
// 
namespace CoffeeChatCalendar; //namespace = like a link that connects related pieces of code
 
class ChatTopic //define ChatTopic class
{
    public string Title { get; set; } //public = the property can be accessed from anywhere, string = stores a text value, { get; set; } = the property can be read and written to 
    public string Description { get; set; }
    public ChatTopic(string title, string description) //construcor, allows user to create a new chat topics
    {
        Title = title;
        Description = description;
    }
}

class Booking //define Booking class
{
    public string Name { get; set; }
    public ChatTopic Topic { get; set; }
    public string Time { get; set; }
    public Booking(string userName, ChatTopic topic, string time) //constructor, allows user to create a new booking
    {
        Name = userName;
        Topic = topic;
        Time = time;
    }
}

