using ChatbotPart1;  // Add this to access your chatbot classes
using CybersecurityChatbotGUI;  // For MainForm

namespace CybersecurityChatbotGUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize chatbot components
            var userName = "User"; // Default or prompt for name
            var chatbot = new Bot(userName); // From ChatbotPart1 namespace

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(chatbot)); // Pass chatbot to MainForm
        }
    }
}