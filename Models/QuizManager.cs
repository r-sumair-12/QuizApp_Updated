using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Updated_App.Models
{
    internal class QuizManager
    {
        public List<QuizQuestions> QuestionsRepository { get; set; } = new List<QuizQuestions>();
        private List<QuizSubmitAnswer> AnswersRepository { get; set; } = new List<QuizSubmitAnswer>();
        private int current = 0;

        public void AddQuestion(QuizQuestions question)
        {
            QuestionsRepository.Add(question);
        }

        public void AddSubmittedAnswer(QuizSubmitAnswer answer)
        {
            AnswersRepository.Add(answer);
        }

        public int CurrentQuestion()
        {
            return current;
        }

        public void MoveToNextQuestion()
        {
            current++;
        }

        public int CalculateScore()
        {
            int score = 0;

            for (int i = 0; i < QuestionsRepository.Count; i++)
            {
                if (QuestionsRepository[i].Statement.Equals(AnswersRepository[i].Statement))
                {
                    if (QuestionsRepository[i].correctAnswer.Equals(AnswersRepository[i].SubmittedAnswer))
                    {
                        score += 10;
                    }
                }
            }

            return score;
        }
    }
}
