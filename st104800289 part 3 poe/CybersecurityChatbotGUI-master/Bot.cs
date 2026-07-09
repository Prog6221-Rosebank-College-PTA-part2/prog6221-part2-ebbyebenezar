using System;
using System.Collections.Generic;

namespace ChatbotPart1
{
    public class Bot
    {
        private string userName;
        private static Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private static List<string> conversationHistory = new List<string>();

        public Bot(string name)
        {
            userName = string.IsNullOrWhiteSpace(name) ? "friend" : name;
            StoreUserInfo("name", userName);
            conversationHistory.Add($"Session started for {userName} at {DateTime.Now}");
        }

        private void StoreUserInfo(string key, string value)
        {
            userMemory[key] = value;
            conversationHistory.Add($"Stored user info: {key}={value}");
        }

        public string ProcessInput(string input)
        {
            input = input.ToLower().Trim();
            conversationHistory.Add($"User: {input}");

            if (string.IsNullOrWhiteSpace(input))
                return "Please enter a valid question or command.";

            // Pass through NLP detector
            string intentResponse = ChatLogic.DetectIntentAndRespond(input);
            if (!string.IsNullOrEmpty(intentResponse))
            {
                conversationHistory.Add($"Bot: {intentResponse}");
                return intentResponse;
            }

            // Handle general questions
            if (input.Contains("how are you"))
                return "I'm functioning optimally and ready to help you stay safe online!";

            if (input.Contains("your purpose"))
                return "I'm here to educate you about cybersecurity and help you avoid online threats.";

            // Default response handler
            string response = ChatLogic.RespondToUser(input);
            conversationHistory.Add($"Bot: {response}");
            return response;


        }

        public string GetHelpResponse()
        {
            return @"I can help with:
================================
    Cybersecurity Topics:
- Password safety
- Phishing attacks
- Malware protection
- Social engineering
- Data privacy settings
- Secure browsing tips
- Two-factor authentication
- Public WiFi risks
- Ransomware protection
- IoT device security

    Task Management Commands:
- 'tasks' - Manage security tasks
- 'add task [description]' - Create new task
- 'show tasks' - View your tasks

    Other Commands:
- 'help' - Show this message
- 'history' - View conversation history
- 'clear' - Clear history
- 'exit' - End the session
- 'show activity log' - View recent actions
================================";
        }

        public string GetConversationHistory()
        {
            if (conversationHistory.Count == 0)
                return "No conversation history available.";

            return "Conversation History:\n" + string.Join("\n", conversationHistory);
        }

        public void GreetUser()
        {
            string greeting = $"\nWelcome, {userName}! I'm your Cybersecurity Awareness Assistant.\n";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(greeting);
            Console.ResetColor();
            conversationHistory.Add($"Bot: {greeting.Trim()}");
        }

        public void StartConversation()
        {
            GreetUser();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(GetHelpResponse());
            Console.ResetColor();
        }
    }
}
