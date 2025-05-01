using System;  // Brings in the System namespace, which contains basic tools like Console
using System.Collections.Generic; // Brings in tools for working with lists and collections
using CoffeeChatCalendar; //imports CoffeeChatCalender namespace

class Program
{
    static List<ChatTopic> topics = new List<ChatTopic>() // List to store available chat topics
    {
        new ChatTopic("Interview Prep.", "Sharing tips on how I landed my current job."), // Add a topic about interview preparation
        new ChatTopic("Tech Trends", "Open to discuss the latest trends since Mindful AI's new release."), // Add a topic about tech trends
        new ChatTopic("Internship Experience Sharing", "Happy to share experiences and insights from my previous internship."), // Add a topic about internships
    };

    static List<Booking> bookings = new List<Booking>(); // List to store user bookings

    static void Main() // Main method: Entry point of the program
    {
        while (true) // Infinite loop to keep the program running until the user exits
        {
            Console.WriteLine("Book a Quick Coffee Chat"); // Display the program title
            Console.WriteLine("============================="); // Display a separator line
            Console.WriteLine("1. View Topics"); // Option to view available topics
            Console.WriteLine("2. Book a Chat"); // Option to book a chat
            Console.WriteLine("3. View Bookings"); // Option to view existing bookings
            Console.WriteLine("4. Exit"); // Option to exit the program
            Console.Write("Select an option: "); // Prompt the user to select an option
            var input = Console.ReadLine(); // Read the user's input
            switch (input) // Handle the user's input
            {
                case "1": ShowTopics(); break; // Call ShowTopics() if the user selects 1
                case "2": BookChat(); break; // Call BookChat() if the user selects 2
                case "3": ViewBookings(); break; // Call ViewBookings() if the user selects 3
                case "4": return; // Exit the program if the user selects 4
                default: Console.WriteLine("Invalid input, please try again."); break; // Handle invalid input
            }
        }
    }

    static void ShowTopics() // Method to display available chat topics
    {
        Console.WriteLine("\nOpen to the following topics!"); // Display a header
        for (int i = 0; i < topics.Count; i++) // Loop through the list of topics
        {
            Console.WriteLine($"{i + 1}. {topics[i].Title} - {topics[i].Description}"); // Display each topic with its title and description
        }
    }

    static void BookChat() // Method to book a chat
    {
        ShowTopics(); // Display the list of topics
        Console.Write("\nChoose a topic: "); // Prompt the user to choose a topic

        if (!int.TryParse(Console.ReadLine(), out int topicIndex) || topicIndex < 1 || topicIndex > topics.Count) // Validate the user's input
        {
            Console.WriteLine("Invalid input, please try again."); // Display an error message for invalid input
            return; // Exit the method
        }

        Console.Write("Please enter your name: "); // Prompt the user to enter their name
        string name = Console.ReadLine(); // Read the user's name
        Console.Write("Please enter your preferred time: "); // Prompt the user to enter their preferred time
        string time = Console.ReadLine(); // Read the user's preferred time

        var booking = new Booking(name, topics[topicIndex - 1], time); // Create a new booking object
        bookings.Add(booking); // Add the booking to the list of bookings

        Console.WriteLine($"\nBooking confirmed! {name}, you have booked a quick coffee chat on {booking.Topic.Title} at {time}."); // Confirm the booking
    }

    static void ViewBookings() // Method to view existing bookings
    {
        if (bookings.Count == 0) // Check if there are no bookings
        {
            Console.WriteLine("\nNo bookings yet. Schedule one now!"); // Display a message if there are no bookings
            return; // Exit the method
        }

        Console.WriteLine("\nYour future bookings!"); // Display a header
        foreach (var b in bookings) // Loop through the list of bookings
        {
            Console.WriteLine($"\n{b.Name} - {b.Topic.Title} - {b.Time}"); // Display each booking with the user's name, topic, and time
        }
    }
}
















