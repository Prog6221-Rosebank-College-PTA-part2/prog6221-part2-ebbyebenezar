using System.Collections.Generic;

namespace ChatbotPart1
{
    public static class QuizLogic
    {
        public class QuizQuestion
        {
            public string Text { get; set; }
            public List<string> Options { get; set; }
            public string CorrectAnswer { get; set; }
            public string Explanation { get; set; }

            public QuizQuestion(string text, List<string> options, string correctAnswer, string explanation)
            {
                Text = text;
                Options = options;
                CorrectAnswer = correctAnswer;
                Explanation = explanation;
            }
        }

        public static List<QuizQuestion> Questions { get; private set; } = new List<QuizQuestion>();
        private static int currentIndex = 0;
        public static int Score { get; private set; }

        public static void ResetQuiz()
        {
            Score = 0;
            currentIndex = 0;
            LoadQuestions();
            ChatLogic.LogActivity($"Quiz started - Current score: {Score}/{Questions.Count}");
        }

        private static void LoadQuestions()
        {
            Questions = new List<QuizQuestion>
            {
                new QuizQuestion(
                    "What should you do if you receive an email asking for your password?",
                    new List<string> { "A) Reply with your password", "B) Delete the email", "C) Report the email as phishing", "D) Ignore it" },
                    "C",
                    "Correct! Reporting phishing emails helps prevent scams."
                ),
                new QuizQuestion(
                    "True or False: Public Wi-Fi is always safe if it doesn’t require a password.",
                    new List<string> { "A) True", "B) False" },
                    "B",
                    "False! Public Wi-Fi can be risky even if it looks harmless."
                ),
                new QuizQuestion(
                    "Which of the following is a strong password?",
                    new List<string> { "A) 123456", "B) password123", "C) T1m3$Square#9!", "D) qwerty" },
                    "C",
                    "Strong passwords mix symbols, numbers, and letters."
                ),
                new QuizQuestion(
                    "What is phishing?",
                    new List<string> { "A) An online shopping trick", "B) A fake login attempt", "C) An email scam", "D) A social media trend" },
                    "C",
                    "Phishing typically uses email to trick you into revealing sensitive info."
                ),
                new QuizQuestion(
                    "What does 2FA stand for?",
                    new List<string> { "A) Two-Factor Authentication", "B) Fast Access", "C) File Agreement", "D) Firewall Approval" },
                    "A",
                    "2FA adds a second layer of security to logins."
                ),
                new QuizQuestion(
                    "Which of the following is a common malware type?",
                    new List<string> { "A) Trojan", "B) Cookie", "C) Widget", "D) Firewall" },
                    "A",
                    "A Trojan disguises itself as legitimate software."
                ),
                new QuizQuestion(
                    "What’s the best way to secure your online accounts?",
                    new List<string> { "A) Use the same password everywhere", "B) Enable 2FA", "C) Share your passwords", "D) Avoid logging out" },
                    "B",
                    "2FA is one of the most effective ways to secure your accounts."
                ),
                new QuizQuestion(
                    "What does a padlock symbol in the browser address bar mean?",
                    new List<string> { "A) Connection is secure", "B) Battery is low", "C) Computer is locked", "D) Unsafe website" },
                    "A",
                    "The padlock means the website uses HTTPS and is encrypted."
                ),
                new QuizQuestion(
                    "Why should you avoid clicking unknown links?",
                    new List<string> { "A) They take time", "B) Could be malware", "C) They are boring", "D) They require login" },
                    "B",
                    "Links from untrusted sources may install malware or phish you."
                ),
                new QuizQuestion(
                    "What’s a good cybersecurity habit?",
                    new List<string> { "A) Ignore updates", "B) Use public Wi-Fi for banking", "C) Click ads", "D) Update software regularly" },
                    "D",
                    "Keeping software updated patches security vulnerabilities."
                )
            };
        }

        public static QuizQuestion GetCurrentQuestion()
        {
            return currentIndex < Questions.Count ? Questions[currentIndex] : null;
        }

        public static string SubmitAnswer(string selected)
        {
            if (currentIndex >= Questions.Count) 
                return "Quiz is already finished.";

            var question = Questions[currentIndex];
            string feedback;


            if (selected.ToUpper() == question.CorrectAnswer.ToUpper())
            {
                Score++;
                feedback = "✅ " + question.Explanation;
            }
            else
            {
                feedback = "❌ Incorrect. " + question.Explanation;
            }

            currentIndex++;


            // Log completion when the quiz ends
            if (currentIndex == Questions.Count)
            {
                ChatLogic.LogActivity($"Quiz completed - Final score: {Score}/{Questions.Count}");

                string summary = $"🎓 Quiz Complete! You got {Score} out of {Questions.Count}.\n";
                if (Score == Questions.Count)
                    summary += "Excellent! You're a cybersecurity pro!";
                else if (Score >= Questions.Count / 2)
                    summary += "Good job! Keep learning!";
                else
                    summary += "Keep practicing. Cybersecurity is important!";

                ChatLogic.LogActivity($"Quiz completed: {Score}/{Questions.Count} correct");
                return feedback + "\n\n" + summary;
            }

            return feedback;
        }
    }
}
