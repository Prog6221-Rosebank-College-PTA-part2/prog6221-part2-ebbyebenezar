namespace CybersecurityChatbotGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPageChat = new TabPage();
            panel1 = new Panel();
            button1 = new Button();
            txtUserInput = new TextBox();
            btnSend = new Button();
            txtChatOutput = new RichTextBox();
            tabPageTasks = new TabPage();
            listTasks = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            panel2 = new Panel();
            btnDeleteTask = new Button();
            btnCompleteTask = new Button();
            btnAddTask = new Button();
            dateTimeReminder = new DateTimePicker();
            label2 = new Label();
            txtTaskDescription = new TextBox();
            label1 = new Label();
            txtTaskTitle = new TextBox();
            tabPageQuiz = new TabPage();
            lblQuestion = new Label();
            btnOptionA = new Button();
            btnOptionB = new Button();
            btnOptionC = new Button();
            btnOptionD = new Button();
            lblFeedback = new Label();
            lblScore = new Label();
            btnNextQuestion = new Button();
            tabControl1.SuspendLayout();
            tabPageChat.SuspendLayout();
            panel1.SuspendLayout();
            tabPageTasks.SuspendLayout();
            panel2.SuspendLayout();
            tabPageQuiz.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageChat);
            tabControl1.Controls.Add(tabPageTasks);
            tabControl1.Controls.Add(tabPageQuiz);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPageChat
            // 
            tabPageChat.Controls.Add(button1);
            tabPageChat.Controls.Add(panel1);
            tabPageChat.Controls.Add(txtChatOutput);
            tabPageChat.Location = new Point(4, 29);
            tabPageChat.Name = "tabPageChat";
            tabPageChat.Padding = new Padding(3);
            tabPageChat.Size = new Size(792, 417);
            tabPageChat.TabIndex = 0;
            tabPageChat.Text = "Chat";
            tabPageChat.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(txtUserInput);
            panel1.Controls.Add(btnSend);
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = SystemColors.InactiveCaptionText;
            panel1.Location = new Point(3, 369);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(786, 45);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(6, 6);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "send";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtUserInput
            // 
            txtUserInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUserInput.BackColor = SystemColors.ScrollBar;
            txtUserInput.Location = new Point(378, 12);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(395, 27);
            txtUserInput.TabIndex = 0;
            txtUserInput.Text = "type your message.....";
            txtUserInput.TextChanged += txtUserInput_TextChanged;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.Location = new Point(1266, 10);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 25);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;
            // 
            // txtChatOutput
            // 
            txtChatOutput.BackColor = Color.FromArgb(192, 255, 255);
            txtChatOutput.Dock = DockStyle.Fill;
            txtChatOutput.Font = new Font("Consolas", 10F);
            txtChatOutput.ForeColor = Color.White;
            txtChatOutput.Location = new Point(3, 3);
            txtChatOutput.Name = "txtChatOutput";
            txtChatOutput.ReadOnly = true;
            txtChatOutput.Size = new Size(786, 411);
            txtChatOutput.TabIndex = 0;
            txtChatOutput.Text = "";
            txtChatOutput.TextChanged += txtChatOutput_TextChanged;
            // 
            // tabPageTasks
            // 
            tabPageTasks.Controls.Add(listTasks);
            tabPageTasks.Controls.Add(panel2);
            tabPageTasks.Location = new Point(4, 29);
            tabPageTasks.Name = "tabPageTasks";
            tabPageTasks.Size = new Size(792, 417);
            tabPageTasks.TabIndex = 1;
            tabPageTasks.Text = "Tasks";
            tabPageTasks.UseVisualStyleBackColor = true;
            // 
            // listTasks
            // 
            listTasks.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listTasks.Dock = DockStyle.Fill;
            listTasks.FullRowSelect = true;
            listTasks.Location = new Point(0, 0);
            listTasks.Name = "listTasks";
            listTasks.Size = new Size(792, 335);
            listTasks.TabIndex = 0;
            listTasks.UseCompatibleStateImageBehavior = false;
            listTasks.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Task";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Description";
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Due Date";
            columnHeader3.Width = 150;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDeleteTask);
            panel2.Controls.Add(btnCompleteTask);
            panel2.Controls.Add(btnAddTask);
            panel2.Controls.Add(dateTimeReminder);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtTaskDescription);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtTaskTitle);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(792, 82);
            panel2.TabIndex = 1;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(600, 45);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(120, 30);
            btnDeleteTask.TabIndex = 0;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // btnCompleteTask
            // 
            btnCompleteTask.Location = new Point(600, 9);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(120, 30);
            btnCompleteTask.TabIndex = 1;
            btnCompleteTask.Text = "Mark Complete";
            btnCompleteTask.Click += btnCompleteTask_Click;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(450, 45);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(120, 30);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Add Task";
            btnAddTask.Click += btnAddTask_Click;
            // 
            // dateTimeReminder
            // 
            dateTimeReminder.Format = DateTimePickerFormat.Short;
            dateTimeReminder.Location = new Point(450, 11);
            dateTimeReminder.Name = "dateTimeReminder";
            dateTimeReminder.Size = new Size(120, 27);
            dateTimeReminder.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 15);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 4;
            label2.Text = "Description";
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(150, 45);
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(280, 27);
            txtTaskDescription.TabIndex = 5;
            txtTaskDescription.Text = "type here.....";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 6;
            label1.Text = "Title";
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(15, 45);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(120, 27);
            txtTaskTitle.TabIndex = 7;
            txtTaskTitle.Text = "type here...";
            txtTaskTitle.TextChanged += txtTaskTitle_TextChanged;
            // 
            // tabPageQuiz
            // 
            tabPageQuiz.Controls.Add(lblQuestion);
            tabPageQuiz.Controls.Add(btnOptionA);
            tabPageQuiz.Controls.Add(btnOptionB);
            tabPageQuiz.Controls.Add(btnOptionC);
            tabPageQuiz.Controls.Add(btnOptionD);
            tabPageQuiz.Controls.Add(lblFeedback);
            tabPageQuiz.Controls.Add(lblScore);
            tabPageQuiz.Controls.Add(btnNextQuestion);
            tabPageQuiz.Location = new Point(4, 29);
            tabPageQuiz.Name = "tabPageQuiz";
            tabPageQuiz.Size = new Size(792, 417);
            tabPageQuiz.TabIndex = 2;
            tabPageQuiz.Text = "Quiz";
            tabPageQuiz.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuestion.Location = new Point(20, 20);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(256, 28);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question will appear here";
            // 
            // btnOptionA
            // 
            btnOptionA.Location = new Point(20, 80);
            btnOptionA.Name = "btnOptionA";
            btnOptionA.Size = new Size(350, 40);
            btnOptionA.TabIndex = 1;
            btnOptionA.Text = "Option A";
            btnOptionA.Click += btnOptionA_Click;
            // 
            // btnOptionB
            // 
            btnOptionB.Location = new Point(400, 80);
            btnOptionB.Name = "btnOptionB";
            btnOptionB.Size = new Size(350, 40);
            btnOptionB.TabIndex = 2;
            btnOptionB.Text = "Option B";
            btnOptionB.Click += btnOptionB_Click;
            // 
            // btnOptionC
            // 
            btnOptionC.Location = new Point(20, 130);
            btnOptionC.Name = "btnOptionC";
            btnOptionC.Size = new Size(350, 40);
            btnOptionC.TabIndex = 3;
            btnOptionC.Text = "Option C";
            btnOptionC.Click += btnOptionC_Click;
            // 
            // btnOptionD
            // 
            btnOptionD.Location = new Point(400, 130);
            btnOptionD.Name = "btnOptionD";
            btnOptionD.Size = new Size(350, 40);
            btnOptionD.TabIndex = 4;
            btnOptionD.Text = "Option D";
            btnOptionD.Click += btnOptionD_Click;
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Font = new Font("Segoe UI", 10F);
            lblFeedback.Location = new Point(20, 190);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(207, 23);
            lblFeedback.TabIndex = 5;
            lblFeedback.Text = "Feedback will appear here";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 10F);
            lblScore.Location = new Point(20, 230);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(70, 23);
            lblScore.TabIndex = 6;
            lblScore.Text = "Score: 0";
            // 
            // btnNextQuestion
            // 
            btnNextQuestion.Location = new Point(600, 230);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(150, 40);
            btnNextQuestion.TabIndex = 7;
            btnNextQuestion.Text = "Next Question";
            btnNextQuestion.Click += btnNextQuestion_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Cybersecurity Chatbot";
            Load += MainForm_Load_1;
            tabControl1.ResumeLayout(false);
            tabPageChat.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPageTasks.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPageQuiz.ResumeLayout(false);
            tabPageQuiz.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageChat;
        private TabPage tabPageTasks;
        private TabPage tabPageQuiz;
        private RichTextBox txtChatOutput;
        private Panel panel1;
        private Button btnSend;
        private TextBox txtUserInput;
        private ListView listTasks;
        private Panel panel2;
        private Button btnDeleteTask;
        private Button btnCompleteTask;
        private Button btnAddTask;
        private DateTimePicker dateTimeReminder;
        private Label label2;
        private TextBox txtTaskDescription;
        private Label label1;
        private TextBox txtTaskTitle;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;

        private Label lblQuestion;
        private Button btnOptionA;
        private Button btnOptionB;
        private Button btnOptionC;
        private Button btnOptionD;
        private Label lblFeedback;
        private Label lblScore;
        private Button btnNextQuestion;
        private Button button1;
    }
}
