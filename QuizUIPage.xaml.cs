using Quiz_Updated_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Updated_App
{
    /// <summary>
    /// Interaction logic for QuizUIPage.xaml
    /// </summary>
    public partial class QuizUIPage : Page
    {
        QuizManager QuizManager;
        
        public QuizUIPage()
        {
            InitializeComponent();
            QuizManager = new QuizManager();
            MakeQuestions();
            NumberOfQuestions.Text = QuizManager.QuestionsRepository.Count().ToString();
            LoadQuestion();
        }

        private void MakeQuestions()
        {
            QuizQuestions question1 = new QuizQuestions
            {
                Statement = "How many continents are there on Earth?",
                correctAnswer = "7",
                Options = new String[]
                {
                    "5",
                    "4",
                    "3",
                    "7"
                }
            };
            QuizManager.AddQuestion(question1);

            QuizQuestions question2 = new QuizQuestions
            {
                Statement = "Which planet is known as the Red Planet?",
                correctAnswer = "Mars",
                Options = new String[]
                {
                    "Venus",
                    "Mars",
                    "Jupiter",
                    "Saturn"
                }
            };
            QuizManager.AddQuestion(question2);

            QuizQuestions question3 = new QuizQuestions
            {
                Statement = "What is the capital of Pakistan?",
                correctAnswer = "Islamabad",
                Options = new String[]
                {
                    "Karachi",
                    "Lahore",
                    "Islamabad",
                    "Peshawar"
                }
            };
            QuizManager.AddQuestion(question3);

            QuizQuestions question4 = new QuizQuestions
            {
                Statement = "Which language is primarily used for WPF development?",
                correctAnswer = "C#",
                Options = new String[]
                {
                    "Java",
                    "Python",
                    "C#",
                    "PHP"
                }
            };
            QuizManager.AddQuestion(question4);

            QuizQuestions question5 = new QuizQuestions
            {
                Statement = "Which data structure follows the FIFO principle?",
                correctAnswer = "Queue",
                Options = new String[]
                {
                    "Stack",
                    "Queue",
                    "Tree",
                    "Graph"
                }
            };
            QuizManager.AddQuestion(question5);

            QuizQuestions question6 = new QuizQuestions
            {
                Statement = "Which company developed the C# language?",
                correctAnswer = "Microsoft",
                Options = new String[]
                {
                    "Google",
                    "Apple",
                    "Microsoft",
                    "IBM"
                }
            };
            QuizManager.AddQuestion(question6);

            QuizQuestions question7 = new QuizQuestions
            {
                Statement = "What is the largest ocean on Earth?",
                correctAnswer = "Pacific Ocean",
                Options = new String[]
                {
                    "Atlantic Ocean",
                    "Indian Ocean",
                    "Pacific Ocean",
                    "Arctic Ocean"
                }
            };
            QuizManager.AddQuestion(question7);

            QuizQuestions question8 = new QuizQuestions
            {
                Statement = "How many bits are there in one byte?",
                correctAnswer = "8",
                Options = new String[]
                {
                    "4",
                    "8",
                    "16",
                    "32"
                }
            };
            QuizManager.AddQuestion(question8);

            QuizQuestions question9 = new QuizQuestions
            {
                Statement = "Which keyword is used to create an object in C#?",
                correctAnswer = "new",
                Options = new String[]
                {
                    "class",
                    "create",
                    "new",
                    "object"
                }
            };
            QuizManager.AddQuestion(question9);

            QuizQuestions question10 = new QuizQuestions
            {
                Statement = "Which planet is the largest in our Solar System?",
                correctAnswer = "Jupiter",
                Options = new String[]
                {
                    "Earth",
                    "Mars",
                    "Saturn",
                    "Jupiter"
                }
            };
            QuizManager.AddQuestion(question10);
        }

        private void LoadQuestion()
        {
            int currentQuestion = QuizManager.CurrentQuestion();
            QuizQuestion.Text = $"{currentQuestion + 1}. {QuizManager.QuestionsRepository[currentQuestion].Statement}";
            Opt1.Content = QuizManager.QuestionsRepository[currentQuestion].Options[0];
            Opt2.Content = QuizManager.QuestionsRepository[currentQuestion].Options[1];
            Opt3.Content = QuizManager.QuestionsRepository[currentQuestion].Options[2];
            Opt4.Content = QuizManager.QuestionsRepository[currentQuestion].Options[3];
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            int TotalQuestion = QuizManager.QuestionsRepository.Count();
            int CurrentQuestion = QuizManager.CurrentQuestion();
            QuizSubmitAnswer submitAnswer = new QuizSubmitAnswer();
            submitAnswer.Statement = QuizManager.QuestionsRepository[CurrentQuestion].Statement;
            
            if (Opt1.IsChecked == true)
            {
                submitAnswer.SubmittedAnswer = Opt1.Content.ToString();
            }
            if (Opt2.IsChecked == true)
            {
                submitAnswer.SubmittedAnswer = Opt2.Content.ToString();
            }
            if (Opt3.IsChecked == true)
            {
                submitAnswer.SubmittedAnswer = Opt3.Content.ToString();
            }
            if (Opt4.IsChecked == true)
            {
                submitAnswer.SubmittedAnswer = Opt4.Content.ToString();
            }
            QuizManager.AddSubmittedAnswer(submitAnswer);

            if (NextBtn.Content.Equals("Submit"))
            {
                SubmitPage submitPage = new SubmitPage();
                int score = QuizManager.CalculateScore();
                submitPage.SetScore(score);
                MainWindow main = (MainWindow)Application.Current.MainWindow;
                main.MoveToSubmit(submitPage);
                
            }
            else
            {
                if (CurrentQuestion < TotalQuestion - 1)
                {
                    QuizManager.MoveToNextQuestion();
                    Opt1.IsChecked = false;
                    Opt2.IsChecked = false;
                    Opt3.IsChecked = false;
                    Opt4.IsChecked = false;
                    LoadQuestion();
                }

                if ((CurrentQuestion + 1) == TotalQuestion - 1)
                {
                    NextBtn.Content = "Submit";
                }
            }
        }
    }
}
