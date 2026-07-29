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
    /// Interaction logic for SubmitPage.xaml
    /// </summary>
    public partial class SubmitPage : Page
    {
        public SubmitPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuizUIPage quizUIPage = new QuizUIPage();
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            main.MoveToQuiz(quizUIPage);
        }

        public void SetScore(int score) 
        {
            if (score < 60)
            {
                GreetingLabel.Content = "❌ Oops! Better luck next time. 💔";
            }
            TotalScore.Text = score.ToString();
        }
    }
}
