using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrueFalseApp
{
    public partial class MainPage : ContentPage
    {

        private List<Question> questions = new List<Question>();
        private int currentQuestion = 0;
        private int score = 0;

        public MainPage()
        {
            questions.Add(new Question { Text = "An ant can lift 1,000 times its body weight.", Answer = false });
            questions.Add(new Question { Text = "Greenland is the largest island in the world.", Answer = true });
            questions.Add(new Question { Text = "Vatican City is the smallest country in the world.", Answer = true });
            questions.Add(new Question { Text = "Cheesecake comes from Italy.", Answer = false });
            questions.Add(new Question { Text = "An astronaut has played golf on the moon.", Answer = true });
            InitializeComponent();

            DisplayQuestion(currentQuestion);
        }

        private void DisplayQuestion(int index)
        {
            if(index >= questions.Count)
            {
                RevealScore();
            } else
            {
                Question q = questions.ElementAt(index);
                QuestionHeader.Text = $"Question #{currentQuestion + 1}";
                QuestionText.Text = q.Text;
            }
        }

        private void RevealScore()
        {
            QuestionHeader.Text = "Results";
            QuestionText.Text = $"You scored a {score}/{questions.Count}!";
            TrueBtn.IsVisible = false;
            FalseBtn.IsVisible = false;
        }

        private void TrueBtn_Clicked(object sender, EventArgs e)
        {
            if (questions.ElementAt(currentQuestion).Answer) score++;
            DisplayQuestion(++currentQuestion);
        }

        private void FalseBtn_Clicked(object sender, EventArgs e)
        {
            if (!questions.ElementAt(currentQuestion).Answer) score++;
            DisplayQuestion(++currentQuestion);
        }

    }
}
