using System;  // Brings in the System namespace, which contains basic tools like Console
using System.Collections.Generic; // Brings in tools for working with lists and collections
using System.Runtime.CompilerServices;
using CoffeeChatCalendar;

class Program
{
    static List<ChatTopic> topics = new List<ChatTopic>() // List to store available chat topics
    {
        new ChatTopic("Interview Prep.", "Sharing tips on how I landed my current job."), // Add a topic about interview preparation
        new ChatTopic("Tech Trends", "Open to discuss the latest trends since Mindful AI's new release."), // Add a topic about tech trends
        new ChatTopic("Internship Experience Sharing", "Happy to share experiences and insights from my previous internship."), // Add a topic about internships
    };

    static List<Booking> bookings = new List<Booking>(); // List to store user bookings

    static List<User> users = new List<User>(); //List to store user profiles. Should be put here instead of DataModels.cs because it runs the logic, not just define what the data looks like 

    static string GetValidatedInput(string prompt) //GetValidatedInput = keeps asking the user for input until they follow format.
    {
        Console.Write(prompt);
        string input = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input. Please try again.");
            return GetValidatedInput(prompt);
        }
        return input;
    }

    static List<string> GetValidatedTimeInput(string prompt)
    {
        Console.WriteLine(prompt);
        string timesInput = Console.ReadLine() ?? string.Empty;
        List<string> availableTimes = timesInput.Split(',').Select(t => t.Trim()).ToList();
        if (availableTimes.Count == 0 || availableTimes.Any(string.IsNullOrWhiteSpace))
        {
            Console.WriteLine("Invalid time input. Please try again.");
            return GetValidatedTimeInput(prompt);
        }
        return availableTimes;
    }

    // Refactor Main method to use helper methods
    static void Main()
    {
        Console.WriteLine("Welcome to the Coffee Chat Booking System!");
        Console.WriteLine("=======================================");

        users.AddRange(MockData.getMockUsers()); //add mock users to the users list; AddRange vs. Add = AddRange adds multiple items at once, while Add only adds one item at a time;

        string name = GetValidatedInput("Please enter your name here: ");
        List<string> availableTimes = GetValidatedTimeInput("Please enter your available times in the following format: 9:00 AM, 10:00 AM, 4:00 PM");

        User newUser = new User(name, availableTimes);
        foreach (var time in newUser.AvailableTimes)
        {
            string topicInput = GetValidatedInput($"What topic are you open to at {time}?\n");
            newUser.TimeTopics[time] = topicInput;
        }

        users.Add(newUser);

        Console.WriteLine($"Welcome {name}!");
        Console.WriteLine("Times and topics you're open to: ");
        foreach (var entry in newUser.TimeTopics)
        {
            Console.WriteLine($"{entry.Key} - {entry.Value}");
        }

        while (true)
        {
            Console.WriteLine("Book a Quick Coffee Chat");
            Console.WriteLine("=============================");
            Console.WriteLine("1. View Topics");
            Console.WriteLine("2. Book a Chat");
            Console.WriteLine("3. View Bookings");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1": ShowTopics(); break;
                case "2": BookChat(name); break; // Pass 'name' to BookChat
                case "3": ViewBookings(); break;
                case "4": return;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
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

    static void BookChat(string name) // Add 'name' as a parameter
    {
        Console.WriteLine("\nAvailable Chats!: ");
        int i = 1; //number the available chats 
        Dictionary<int, (User, string)> options = new Dictionary<int, (User, string)>(); //Create a dict. to store the available chats. User = key. String = value.
        foreach (var user in users) //Loop through the users
        {
           if (user.Name == name) 
                continue; //Skip the loop to prevent self-booking

            foreach (var entry in user.TimeTopics) //Loop through time-topic pairs 
            {
                string time = entry.Key;
                string topic = entry.Value;
                bool alreadyBooked = bookings.Exists(b => b.Time == time && b.selectedUser.Name == user.Name); //bool = boolean expression. b = booking. b,Time = accesses the time property of the booking. time = the time slot the user is trying to book. Exists() = check if there is at least one element in the list and if the element matches the condition. && = short circuit evaluation, only evaluates the second condition if the first one is true.
                if (alreadyBooked) continue; //continue = skip it, don't show.

                Console.WriteLine($"{i}. {user.Name} - {time} - {topic}"); //Display the available chats
                options[i] = (user, time); //save the user and time in the dict.
                i++; //plus one 
            }
        }

        if (options.Count == 0) //No available options
        {
            Console.WriteLine("No available chats at the moment. Please check back later!");
            return;
        }

        Console.Write("\nBook a chat by entering the corresponding number: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || !options.ContainsKey(choice))//validate if the user's input can be parsed as an int. then validate if the input is one of the keys in the dict. 
        {
            Console.WriteLine("Invalid input, please try again."); //Error message
            return;
        }

        var (selectedUser, selectedTime) = options[choice]; //Unpack the tuple. selectedUser = host. 
        var selectedTopic = new ChatTopic(selectedUser.TimeTopics[selectedTime], ""); // Create a ChatTopic object from the selected time topic
        var booking = new Booking(name, selectedUser, selectedTopic, selectedTime); // Create a new booking object
        bookings.Add(booking); // Add the booking to the list of bookings

        Console.WriteLine($"\nBooking confirmed! {name}, you have booked a quick coffee chat with {selectedUser.Name} on {selectedTopic.Title} at {selectedTime}."); //Confirm booking message 
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
            Console.WriteLine($"\n{b.Name} - {b.selectedUser.Name} - {b.Topic.Title} - {b.Time}"); // Display each booking with the user's name, topic, and time; call the Name propoerty of the selectedUser object instead of the object itself to print out the host's name;
        }
    }
}
















