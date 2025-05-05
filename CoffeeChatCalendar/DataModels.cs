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
    public string Name { get; set; } // The name of the person booking the chat
    public User selectedUser { get; set; } // The user being booked for the chat
    public ChatTopic Topic { get; set; } // The topic of the chat (now a ChatTopic object)
    public string Time { get; set; } // The time of the chat

    public Booking(string name, User selectedUser, ChatTopic topic, string time) // Constructor to initialize a booking
    {
        Name = name;
        this.selectedUser = selectedUser;
        Topic = topic;
        Time = time;
    }
}

class User
{
    public string Name { get; set; }
    public List<string> AvailableTimes { get; set; }
    public Dictionary<string, string> TimeTopics { get; set; } //A dict. allows us to store key-value pairs.
    public User(string name, List<string> availableTimes) //constructor, allows user to create a new user (like a profile setup helper)
    {
        Name = name;
        AvailableTimes = availableTimes;
        TimeTopics = new Dictionary<string, string>(); //We don't receive it, so we need to create it from scratch. 
    }
}



