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

namespace PumpYourBrain.MVVM.View
{
    /// <summary>
    /// Interaction logic for QuizGame2View.xaml
    /// </summary>
    public partial class QuizGame2View : UserControl
    {
        public QuizGame2View()
        {
            InitializeComponent();
            StartGame();
            NextQuestion();
        }
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        int qNum = 0;
        int i;
        int score;

        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            // this is the check answer event, this event is linked to each button on the canvas
            // when either of the buttons will be pressed we will run this event

            Button senderButton = sender as Button; // first check which button sent this event and link it to a local button inside of this event

            // in the if statement below we will check if the button clicked on has a 1 tag inside of it, if it does then we will add 1 to the score
            if (senderButton.Tag.ToString() == "1")
            {
                score++;
            }

            // if the qnum is less than 0 then we will reset the qnum integer to 0
            if (qNum < 0)
            {
                qNum = 0;
            }
            else
            {
                // if the qnum is greater than 0 then we will add 1 to the qnum integer
                qNum++;
            }

            // update the score text label each time the buttons are pressed
            scoreText.Content = "Answered Correctly " + score + "/" + questionNumbers.Count;

            // run the next question function
            NextQuestion();

        }

        public void RestartGame()
        {
            // restart game function will load all of the default values for this game
            score = 0; // set score to 0
            qNum = -1; // set qnum to -1
            i = 0; // set i to 0
            StartGame(); // run the start game function
        }

        private void NextQuestion()
        {
            // this function will check which question to show next and it will have all of the question and answer definitions

            // in the if statement below it will checking if the qnum integer is less than the total number of questions if it then we will set the value of i to the value of qnum

            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];

            }
            else
            {
                MessageBox.Show($"You completed the quiz! Your score: {score}/10");
                RestartGame();
            }

            // below we are running a foreach loop where will check for each button inside of the canvas and when we find them we will set their tag to 0 and background to dakr salmon colour
            foreach (var x in myCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";

            }


            // below you have all of the question and answers template
            // you can add your own questions to the txtQuestion section
            // and add your own answers inside of the ans1, ans2, ans3 content and so. 


            // this switch statement will check what value is inside of i integer and show the questions based on that value

            switch (i)
            {
                case 1:

                    txtQuestion.Text = "Choose correct solution"; // this the question for the quiz

                    ans1.Content = "63+128=183"; // each of the buttons can have their own answers in this game
                    ans2.Content = "45/9=5";
                    ans3.Content = "126*3=321";
                    ans4.Content = "54*7=780";

                    ans2.Tag = "1"; // here we tell the program which one of the answers above is the right answer by adding the 1 inside of the tag for the button. 
                                    // in this example we adding 1 inside of ans2 or button 2
                                    // so when the button is clicked the game will know which is the correct answer and it add 1 to the score for the game



                    break; // when this condition is met the program will break the switch statement here and wait for the next one
                           // rest of the condition will follow the same principle as this one

                case 2:

                    txtQuestion.Text = "Choose correct solution";

                    ans1.Content = "86/4=21,5";
                    ans2.Content = "22+34=30";
                    ans3.Content = "90/84=0,1";
                    ans4.Content = "72+3,4=75";

                    ans1.Tag = "1";



                    break;

                case 3:

                    txtQuestion.Text = "What color do you get when you mix red and blue";

                    ans1.Content = "Purple";
                    ans2.Content = "Blue";
                    ans3.Content = "Violet";
                    ans4.Content = "Green";

                    ans3.Tag = "1";



                    break;

                case 4:

                    txtQuestion.Text = "The sum of the angles of a square?";

                    ans1.Content = "240";
                    ans2.Content = "90";
                    ans3.Content = "180";
                    ans4.Content = "360";

                    ans4.Tag = "1";



                    break;

                case 5:

                    txtQuestion.Text = "What fraction of an hour is 20 minutes?";

                    ans1.Content = "1/3";
                    ans2.Content = "1/2";
                    ans3.Content = "1/5";
                    ans4.Content = "1/4";

                    ans1.Tag = "1";



                    break;
                case 6:

                    txtQuestion.Text = "Insert the missing number. 2 5 8 11 _";

                    ans1.Content = "12";
                    ans2.Content = "15";
                    ans3.Content = "14";
                    ans4.Content = "18";

                    ans3.Tag = "1";



                    break;
                case 7:

                    txtQuestion.Text = "Insert the missing number. 8 10 14 18 _ 34 50 66";

                    ans1.Content = "20";
                    ans2.Content = "26";
                    ans3.Content = "24";
                    ans4.Content = "30";

                    ans2.Tag = "1";



                    break;
                case 8:

                    txtQuestion.Text = "In which sport do you need to earn the fewest points to win?";

                    ans1.Content = "Football";
                    ans2.Content = "Tennis";
                    ans3.Content = "Curling";
                    ans4.Content = "Golf";

                    ans4.Tag = "1";



                    break;
                case 9:

                    txtQuestion.Text = "How many dots are there on two dice?";

                    ans1.Content = "21";
                    ans2.Content = "30";
                    ans3.Content = "42";
                    ans4.Content = "54";

                    ans3.Tag = "1";



                    break;

                case 10:

                    txtQuestion.Text = "Choose correct statement";

                    ans1.Content = "There are three false statements here";
                    ans2.Content = "There are two false statements here";
                    ans3.Content = "There are four false statements here";
                    ans4.Content = "There are one false statement here";

                    ans1.Tag = "1";



                    break;
            }
        }

        public void StartGame()
        {
            // this is the start game function
            // inside of this function we will randomise the questions list and save it back into the list 

            // create a new randomlist variable and use the line below to randomise the order of the content
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();

            // save the random list to the question numbers list again
            questionNumbers = randomList;

            // empty the question order label on the canvas


        }
    }
}
