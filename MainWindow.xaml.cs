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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            QuizUIPage quizUI = new QuizUIPage();
            MainFrame.Navigate(quizUI);
        }

        private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CrossBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void MoveToSubmit(SubmitPage submitPage)
        {
            MainFrame.Navigate(submitPage);
        }

        public void MoveToQuiz(QuizUIPage quizUIPage)
        {
            MainFrame.Navigate(quizUIPage);
        }
    }
}
