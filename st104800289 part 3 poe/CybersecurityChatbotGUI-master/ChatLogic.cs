using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChatbotPart1
{
    public static class ChatLogic
    {
        private static Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private static List<string> userInterests = new List<string>();
        private static string currentTopic = "";
        private static List<string> activityLog = new List<string>();

        public static List<TaskItem> Tasks = new List<TaskItem>();
        private static string _pendingTaskDescription = null;

        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? ReminderDate { get; set; }
            public bool IsCompleted { get; set; }

            public TaskItem(string title, string description, DateTime? reminderDate = null)
            {
                Title = title;
                Description = description;
                ReminderDate = reminderDate;
                IsCompleted = false;
            }
        }

        public static string ProcessTaskCommand(string input)
        {
            input = input.ToLower().Trim();

            if (input.Contains("add task") || input.Contains("create task") ||
                input.Contains("remind me to") || input.Contains("set reminder") ||
                input.Contains("i want to add") || input.Contains("enable") || input.Contains("review"))
            {
                return HandleTaskCreation(input);
            }
            else if (input.Contains("list tasks") || input.Contains("show tasks") || input.Contains("my tasks"))
            {
                return GetTaskListResponse();
            }
            else if (input.Contains("yes") && _pendingTaskDescription != null)
            {
                return "How many days from now should I remind you? (e.g., '3 days')";
            }
            else if (input.Contains("days") && _pendingTaskDescription != null)
            {
                return HandleReminderConfirmation(input);
            }

            return null;
        }

        private static string HandleTaskCreation(string input)
        {
            try
            {
                string taskTitle = ExtractTaskTitle(input);
                if (string.IsNullOrWhiteSpace(taskTitle))
                    return "Please specify a task after the command (e.g., 'add task Enable 2FA')";

                AddTask(taskTitle, $"Added via chat: {input}");
                _pendingTaskDescription = taskTitle;
                LogActivity($"Task added: '{taskTitle}'");

                if (input.Contains("in") && input.Contains("days"))
                {
                    return ProcessReminderRequest(input, taskTitle);
                }

                return $"Task '{taskTitle}' added. Would you like to set a reminder? (Yes/No)";
            }
            catch
            {
                return "I couldn't understand the task. Try: 'Remind me to [task] in [X] days'";
            }
        }

        private static string ProcessReminderRequest(string input, string taskTitle)
        {
            try
            {
                int days = ExtractDays(input);
                var task = Tasks.Last();
                task.ReminderDate = DateTime.Now.AddDays(days);
                _pendingTaskDescription = null;

                LogActivity($"Reminder set: '{taskTitle}' in {days} days");
                return $"Task '{taskTitle}' added with reminder in {days} days.";
            }
            catch
            {
                return $"Task '{taskTitle}' added. How many days from now should I remind you? (e.g., '3 days')";
            }
        }

        private static int ExtractDays(string input)
        {
            Match match = Regex.Match(input, @"(\d+)\s*days?");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int days))
                return days;

            throw new FormatException("Invalid number of days.");
        }

        private static string HandleReminderConfirmation(string input)
        {
            if (_pendingTaskDescription == null)
                return "I'm not sure what task you're referring to.";

            var task = Tasks.FirstOrDefault(t => t.Title == _pendingTaskDescription);
            if (task == null)
                return "Task not found.";

            try
            {
                int days = ExtractDays(input);
                task.ReminderDate = DateTime.Now.AddDays(days);
                _pendingTaskDescription = null;

                LogActivity($"Reminder set: '{task.Title}' in {days} days");
                return $"Reminder set for '{task.Title}' in {days} days!";
            }
            catch
            {
                return "I didn't understand the number of days. Please try again (e.g., '3 days')";
            }
        }

        private static string ExtractTaskTitle(string input)
        {
            string[] patterns = new[] {
                "add task", "create task", "remind me to", "set reminder to", 
                "i want to add", "task to", "enable", "review", "remember to", "todo"
            };

            foreach (string p in patterns)
            {
                if (input.Contains(p))
                {
                    string title = input.Substring(input.IndexOf(p) + p.Length).Trim();
                    if (title.StartsWith("to"))
                        title = title.Substring(2).Trim();
                    return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title);
                }
            }

            return null;
        }

        public static string GetTaskListResponse()
        {
            if (Tasks.Count == 0)
                return "You have no active tasks.";

            var response = new System.Text.StringBuilder("Your tasks:\n");
            foreach (var task in Tasks.OrderBy(t => t.ReminderDate ?? DateTime.MaxValue))
            {
                response.AppendLine($"- {task.Title}");
                if (task.ReminderDate.HasValue)
                    response.AppendLine($"  Due: {task.ReminderDate.Value.ToString("d")}");
                if (task.IsCompleted)
                    response.AppendLine("  Status: Completed");
            }
            return response.ToString();
        }

        // NLP Detection Routing
        public static string DetectIntentAndRespond(string input)
        {
            input = input.ToLower().Trim();

            //quiz intent
            if (input.Contains("quiz") || input.Contains("test") || input.Contains("questions"))

                return "Starting the cybersecurity quiz...";

            // Task/Reminder intent (expanded keyword detection)
            if (input.Contains("task") || input.Contains("remind") || input.Contains("set") ||
                input.Contains("add") || input.Contains("enable") || input.Contains("review") ||
                input.Contains("remember") || input.Contains("todo"))
            {
                var taskResponse = ProcessTaskCommand(input);
                return !string.IsNullOrEmpty(taskResponse) ? taskResponse : "Could not understand the task.";
            }

            // Activity log intent
            if (input.Contains("activity log") || input.Contains("what have you done") || 
                input.Contains("history"))
                return GetActivityLog();

            // Default responses for cybersecurity topics
            return RespondToUser(input);
        }

        public static void LogActivity(string entry)
        {
            activityLog.Add($"[{DateTime.Now:HH:mm}] {entry}");
            if (activityLog.Count > 10) // Keep last 10 entries
                activityLog.RemoveAt(0);
        }

        public static string GetActivityLog()
        {
            if (activityLog.Count == 0)
                return "No recent activity.";

            return "Here’s a summary of recent actions:\n" + string.Join("\n", activityLog.TakeLast(10));
        }

        public static void AddTask(string title, string description, DateTime? reminderDate = null)
        {
            Tasks.Add(new TaskItem(title, description, reminderDate));
            LogActivity($"Task added: '{title}' {(reminderDate.HasValue ? $"(Due: {reminderDate.Value:d})" : "")}");

        }

        public static string RespondToUser(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please enter a valid command or question.";

            input = input.ToLower();

            // Basic topic detection
            if (input.Contains("phishing"))
                return "Phishing is a scam where attackers trick you into revealing personal info. Be cautious with suspicious emails.";
            if (input.Contains("malware"))
                return "Malware is malicious software like viruses or spyware. Keep your antivirus updated!";
            if (input.Contains("password"))
                return "Use strong, unique passwords for each account and enable two-factor authentication.";
            if (input.Contains("2fa") || input.Contains("two-factor"))
                return "Two-factor authentication adds a second layer of security. Enable it on all your accounts.";
            if (input.Contains("social engineering"))
                return "Social engineering involves manipulating people into giving up sensitive info. Always verify identities.";
            if (input.Contains("data privacy") || input.Contains("privacy settings"))
                return "Regularly check your app and account privacy settings to limit data exposure.";
            if (input.Contains("public wifi"))
                return "Avoid entering passwords or sensitive info when connected to public Wi-Fi. Use a VPN if possible.";
            if (input.Contains("secure browsing") || input.Contains("https"))
                return "Use websites with HTTPS encryption and keep your browser updated for safe browsing.";

            return "I'm still learning! Try asking about phishing, malware, passwords, or social engineering.";
        }

    }
}
