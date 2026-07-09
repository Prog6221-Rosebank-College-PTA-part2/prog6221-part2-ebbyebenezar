# Cybersecurity Awareness Chatbot (GUI)

Youtube video link: 

A Windows Forms-based Cybersecurity Awareness Chatbot built in C#. This application provides an interactive chatbot, task management tools, and a cybersecurity quiz to educate users about safe online practices.

---

## 🚀 Features

- 💬 **Chatbot**: Interact with a cybersecurity-aware bot that responds to user queries.
- ✅ **Task Manager**: Add, complete, and delete tasks with optional reminders.
- 🧠 **Cybersecurity Quiz**: Test your cybersecurity knowledge with multiple-choice questions.
- 💾 **Reminder System**: Periodic reminders for due tasks.
- 🖥️ **User Interface**: Built with Windows Forms for an intuitive GUI.

---

## 🛠️ Setup Instructions

### ✅ Prerequisites
- [.NET 6.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- Git (optional, for cloning)

### 📦 Clone the Repository

If you haven't cloned it yet:
bash
git clone https://github.com/Nkosi-Mmasebotsana/CybersecurityChatbotGUI/.git

🧩 Project Structure
/CybersecurityChatbotGUI
│
├── ChatbotPart1/              # Core chatbot logic and models
├── CybersecurityChatbotGUI/   # GUI code (MainForm, designer)
├── Program.cs                 # Entry point
├── README.md                  # This file
└── .gitignore


🖥️ How to Run the Application

(1) Open CybersecurityChatbotGUI.sln in Visual Studio.
(2) Build the solution (Ctrl+Shift+B).
(3) Run the app (F5 or the green Run button).

The application will launch with a GUI featuring:

- A Chat tab with a text box and send button.
- A Tasks tab for task management.
- A Quiz tab for cybersecurity questions.


✏️ Usage Instructions

💬 Chatbot
- Type into the input box and click Send.

-Commands:

- help — View available commands.
- history — View chat history.
- clear — Clear the chat window.
- tasks — Switch to the Tasks tab.
- start quiz — Switch to the Quiz tab and begin.


✅ Task Management
Switch to the Tasks tab.

- Fill in the Title, optional Description, and optional Reminder Date.
- Click Add Task.
  
- Select a task in the list:
- Click Mark Complete to toggle completion.
- Click Delete Task to remove it.

⚠️ If a task has a reminder date, you'll get a popup-style reminder when it's due.


🧠 Quiz Feature
- Type start quiz in chat or navigate to the Quiz tab.
- The question and multiple-choice buttons (A–D) will appear.
- Click an option — feedback will appear.
- Click Next Question to move forward.
- Your score will update live.

💡 Example Conversation

You: help
Bot: Available commands include: help, history, clear, tasks, start quiz

You: What is phishing?
Bot: Phishing is a type of cyberattack...

You: start quiz
Bot: Cybersecurity Quiz started. Good luck!
