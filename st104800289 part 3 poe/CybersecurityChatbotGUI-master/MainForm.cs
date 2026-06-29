using ChatbotPart1;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CybersecurityChatbotGUI
{
    public partial class MainForm : Form
    {
        private readonly Bot _chatbot;
        private readonly System.Windows.Forms.Timer _reminderTimer;

        public MainForm(Bot chatbot)
        {
            _chatbot = chatbot;
            _reminderTimer = new System.Windows.Forms.Timer { Interval = 60000 };

            InitializeComponent();

            // Wire up Load event here to ensure MainForm_Load runs
            this.Load += MainForm_Load;

            InitializeInterface();
            SetupTaskListView();
            InitializeReminderTimer();
            LoadFirstQuestion();
        }

        private void InitializeInterface()
        {
            txtChatOutput.BackColor = Color.FromArgb(30, 30, 30);
            txtChatOutput.ForeColor = Color.White;
            txtChatOutput.Font = new Font("Consolas", 10);

            AppendToChat(_chatbot.ProcessInput("welcome"));
            AppendToChat("Type 'help' for available commands");
        }

        private void SetupTaskListView()
        {
            listTasks.View = View.Details;
            listTasks.FullRowSelect = true;
            listTasks.Columns.Add("Task", 200);
            listTasks.Columns.Add("Description", 300);
            listTasks.Columns.Add("Due Date", 150);
            listTasks.Columns.Add("Status", 100);
        }

        private void InitializeReminderTimer()
        {
            _reminderTimer.Tick += (s, e) => CheckDueTasks();
            _reminderTimer.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshTaskList();
            txtUserInput.Focus();  // Set focus to input box on form load
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AppendToChat($"You: {input}");
            txtUserInput.Clear();

            switch (input.ToLower())
            {
                case "history":
                    AppendToChat(_chatbot.GetConversationHistory());
                    return;
                case "clear":
                    txtChatOutput.Clear();
                    AppendToChat("Chat history cleared.");
                    return;
                case "tasks":
                    tabControl1.SelectedTab = tabPageTasks;
                    AppendToChat("Switched to Task Management");
                    return;
                case "start quiz":
                    tabControl1.SelectedTab = tabPageQuiz;
                    AppendToChat("Cybersecurity Quiz started. Good luck!");
                    LoadFirstQuestion();
                    return;
            }

            string response = _chatbot.ProcessInput(input);
            AppendToChat($"Bot: {response}");
        }

        // ========== TASK MANAGEMENT ==========
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Text))
            {
                MessageBox.Show("Please enter a task title!");
                return;
            }

            ChatLogic.AddTask(
                txtTaskTitle.Text,
                txtTaskDescription.Text,
                dateTimeReminder.Checked ? dateTimeReminder.Value : null
            );

            RefreshTaskList();
            ClearTaskInputs();
            AppendToChat($"Added task: {txtTaskTitle.Text}");
        }

        private void RefreshTaskList()
        {
            listTasks.Items.Clear();
            foreach (var task in ChatLogic.Tasks.OrderBy(t => t.ReminderDate ?? DateTime.MaxValue))
            {
                var item = new ListViewItem(task.Title);
                item.SubItems.Add(task.Description);
                item.SubItems.Add(task.ReminderDate?.ToString("yyyy-MM-dd") ?? "None");
                item.SubItems.Add(task.IsCompleted ? "Completed" : "Pending");

                if (task.IsCompleted)
                    item.BackColor = Color.LightGreen;
                else if (task.ReminderDate.HasValue && task.ReminderDate < DateTime.Now)
                    item.BackColor = Color.LightPink;

                item.Tag = task;
                listTasks.Items.Add(item);
            }
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0) return;

            var selectedTask = (ChatLogic.TaskItem)listTasks.SelectedItems[0].Tag;
            selectedTask.IsCompleted = !selectedTask.IsCompleted;
            RefreshTaskList();
            AppendToChat($"Task '{selectedTask.Title}' marked as {(selectedTask.IsCompleted ? "completed" : "pending")}");
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItems.Count == 0) return;

            var selectedTask = (ChatLogic.TaskItem)listTasks.SelectedItems[0].Tag;
            ChatLogic.Tasks.Remove(selectedTask);
            RefreshTaskList();
            AppendToChat($"Deleted task: {selectedTask.Title}");
        }

        private void CheckDueTasks()
        {
            var dueTasks = ChatLogic.Tasks
                .Where(t => !t.IsCompleted && t.ReminderDate.HasValue && t.ReminderDate <= DateTime.Now)
                .ToList();

            foreach (var task in dueTasks)
            {
                AppendToChat($"🔔 REMINDER: Task '{task.Title}' is due now!");
            }
        }

        private void ClearTaskInputs()
        {
            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            dateTimeReminder.Checked = false;
        }

        // ========== QUIZ MANAGEMENT ==========
        private void LoadFirstQuestion()
        {
            QuizLogic.ResetQuiz();
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            var question = QuizLogic.GetCurrentQuestion();
            if (question == null)
            {
                lblQuestion.Text = $"Quiz complete! Final Score: {QuizLogic.Score} / {QuizLogic.Questions.Count}";
                btnOptionA.Visible = btnOptionB.Visible = btnOptionC.Visible = btnOptionD.Visible = btnNextQuestion.Visible = false;
                return;
            }

            lblQuestion.Text = question.Text;
            btnOptionA.Text = question.Options.Count > 0 ? question.Options[0] : "";
            btnOptionB.Text = question.Options.Count > 1 ? question.Options[1] : "";
            btnOptionC.Text = question.Options.Count > 2 ? question.Options[2] : "";
            btnOptionD.Text = question.Options.Count > 3 ? question.Options[3] : "";

            lblFeedback.Text = "";
            lblScore.Text = $"Score: {QuizLogic.Score}";
        }

        private void btnOptionA_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = QuizLogic.SubmitAnswer("A");
            lblScore.Text = $"Score: {QuizLogic.Score}";
        }

        private void btnOptionB_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = QuizLogic.SubmitAnswer("B");
            lblScore.Text = $"Score: {QuizLogic.Score}";
        }

        private void btnOptionC_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = QuizLogic.SubmitAnswer("C");
            lblScore.Text = $"Score: {QuizLogic.Score}";
        }

        private void btnOptionD_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = QuizLogic.SubmitAnswer("D");
            lblScore.Text = $"Score: {QuizLogic.Score}";
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            ShowQuestion();
        }

        // ========== HELPERS ==========
        private void AppendToChat(string message)
        {
            if (txtChatOutput.InvokeRequired)
            {
                Invoke(new Action(() => AppendToChat(message)));
            }
            else
            {
                txtChatOutput.AppendText(message + Environment.NewLine);
                txtChatOutput.ScrollToCaret();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e) => AppendToChat(_chatbot.GetHelpResponse());
        private void btnClearChat_Click(object sender, EventArgs e) => txtChatOutput.Clear();
        private void btnShowHistory_Click(object sender, EventArgs e) => AppendToChat(_chatbot.GetConversationHistory());

        private void txtUserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void txtTaskTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChatOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
