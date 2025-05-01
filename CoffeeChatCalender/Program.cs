// See https://aka.ms/new-console-template for more information
using Systems //brings in the systems namespace, toolbox that contains many of the most-used basic tool of C#
using System.Collections.Generic; //System = the toolbox, Collections = a drawer inside the toolbox, Generic =flexible, reusable container
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

class Program //contains the main()method, the entry of every C# application
{
    static List<ChatTopic> topics = new List<ChatTopic>() //static = (in simple terms) only one copy, shared by everyone;  () = build me a new list
    {
        new ChatTopic("Interview Prep.", "Sharing tips on how I landed my current job."),
        new ChatTopic("Tech Trends", "Open to discuss the latest trends since Mindful AI's new release."),
        new ChatTopic("Internship Experience Sharing", "Happy to share experiences and insights from my previous internship."),
    };

    static List<Booking> bookings = new List<Booking>(); //create a new list for all user bookings 
    static void Main() //static = run it directly, void = no need to return anything, Main() = Action!
    {
        while (true) //keeps running until the user chooses to exit 
        {
            Console.WriteLine ("Book a Quick Coffee Chat"); //WriteLine = print text and move to the next line
            Console.WriteLine ("=============================");
            Console.WriteLine ("1. View Topics");
            Console.WriteLine ("2. Book a Chat");
            Console.WriteLine ("3. View Bookings");
            Console.WriteLine ("4. Exit");
            Console.Write ("Select an option");// Write = print and stay on the same line 
            var input = Console.Readline(); // var = make a new variable, input = name of the variable, Console.Readline() = wait for the user to type something and hit enter
            switch (input) //switch = check which option the user selected and do the corresponding action
            {
                case"1": ShowTopics(); break; //break = stop checking other cases 
                case"2": BookCahat(); break; 
                case"3": ViewBookings(); break; 
                case"4': return; //return = exit the program in Main(), bcs Main() is the entry point of the program
                default: Console.WriteLine ("Invalid input, please try again."); break; //default = do this if the user types something that is not one of the options provided 
            }
        }
    }

    static void ShowTopics() //ShowTopics() = method name 
    {
        Console.WriteLine ("\nOpen to the following topics!");
        for (int i=0; i<topics.Count; i++) //for = loop through the list of topics, i=0  = start from the first topic, i<topics.Count = till the last topic on the list, i++  = add 1 to i 
        {
        Console.WriteLine ($"{i+1}. {topics[i].Title} - {topics[i].Description}"); //$ = string interpolation to plug in values, {i+1} = show topic number in the way humans count, {topics [i]} = grab the ith topic from the list 
        }

    }

    static void BookChat()
    {
        ShowTopics(); //call the ShowTopics() method to show the list of topics 
        Console.Write("\nChoose a topic!");
    }

    //checking if the typed-in numver is valid 
    if (!int.TryParse(Console.ReadLine(), out int topicIndex) ||topicIndex <1 || topicIndex >topics.Count) //TryParse = a method used to convert a string into an int; If convertion succeeds, furthercheck if the number is valid, if yes, store the int output in topicIndex
    {
        Console.WriteLine ("Invalid input, please try again."); //error message
        return; //exit TryParse() method
    }

    Console.Write ("Please enter your name:");
    string name = Console.ReadLine(); //stores the user input in name 
    Console.Write ("Please enter your preferred time:"); 
    string time - Console.ReadLine (); //stores the user input in time 

    var booking = new Booking(name, topics[topicIndex -1], time); //create a new booking object using the Booking class; [topicIndex -1] tells the computer which topic to grab from the bookings list
    bookings.Add(Booking); //add the new booking to bookings list 

    Console.WriteLine ($"\nBooking confirmed! {name}, you have booked a quick coffee chat on {booking.topic.title}} at {time}."); //confirm booking message

    static void ViewBookings()
    {
        if (bookings.Count == 0) //no bookings 
        {
            Console.WriteLine ("\nNo bookings yet. Schedule one now!"); 
            return' //exit ViewBookings() method 
        }
    }

    Console.WriteLine (\nYour future bookings!); 
    foreach (var b in bookings) //foreach = loop through each booking in the bookings list; b = a short nickname for booking  
    {
        Console.WriteLine ("$\n{b.Name} - (booking.Topic.Title} - {b.Time}"); //print out the booking details 
    }








 







