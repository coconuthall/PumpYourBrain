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
using System.Windows.Threading;

namespace PumpYourBrain.MVVM.View
{
    /// <summary>
    /// Interaction logic for CountGameView.xaml
    /// </summary>
    public partial class CountGameView : UserControl
    {
        public CountGameView()
        {
            InitializeComponent();
            DataContext = this;
            NextTask();
            Update();
        }
        DispatcherTimer dt = new DispatcherTimer();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }
        public int increment = 0;
        public int minutes = 0;
        public int seconds = 0;
        private void dtTicker(object sender, EventArgs e)
        {
            increment++;
            seconds = increment - minutes * 60;
            if (seconds % 60 == 0)
            {
                minutes++;
                seconds = 0;
            }
            Time.Text = $"Time: {minutes}:{seconds}";
        }
        public int firstOperand = 3;
        public int secondOperand = 2;
        public int correctAnswers;
        public int wrongAnswers;
        public int operation;
        public int totalTasks;

        private void NumberEnter(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            switch (senderButton.Content)
            {
                case "1":
                    Answer.Text += "1";
                    break;
                case "2":
                    Answer.Text += "2";
                    break;
                case "3":
                    Answer.Text += "3";
                    break;
                case "4":
                    Answer.Text += "4";
                    break;
                case "5":
                    Answer.Text += "5";
                    break;
                case "6":
                    Answer.Text += "6";
                    break;
                case "7":
                    Answer.Text += "7";
                    break;
                case "8":
                    Answer.Text += "8";
                    break;
                case "9":
                    Answer.Text += "9";
                    break;
                case "0":
                    Answer.Text += "0";
                    break;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Answer.Text = "";
        }
        private void NextTask()
        {
            Random rand = new Random();
            operation = rand.Next(1, 5);
            switch (operation)
            {
                case 1:
                    firstOperand = rand.Next(1, 150);
                    secondOperand = rand.Next(1, 150);
                    Task.Text = $"{firstOperand} + {secondOperand}";
                    break;
                case 2:
                    firstOperand = rand.Next(20, 150);
                    secondOperand= rand.Next(1, firstOperand - 5);
                    Task.Text = $"{firstOperand} - {secondOperand}";
                    break;
                case 3:
                    firstOperand = rand.Next(10, 20);
                    secondOperand = rand.Next(2, 9);
                    Task.Text = $"{firstOperand} * {secondOperand}";
                    break;
                case 4:
                    while (firstOperand % secondOperand != 0)
                    {
                        firstOperand = rand.Next(20, 100);
                        secondOperand = rand.Next(2, 20);
                    }
                    Task.Text = $"{firstOperand} / {secondOperand}";
                    break;

            }

        }
        private int GetResult()
        {
            switch (operation)
            {
                case 1:
                    return firstOperand + secondOperand;
                case 2:
                    return firstOperand - secondOperand;
                case 3:
                    return firstOperand * secondOperand;
                case 4: 
                    return firstOperand / secondOperand;
                default: return 0;
            }
            
        }
        private void Update()
        {
            CorrectAnswers.Text = $"Correct answers: {correctAnswers}";
            WrongAnswers.Text = $"Wrong answers: {wrongAnswers}";
        }
        private int CountScore()
        {
            if(increment < 15)
            {
                return 0;
            }
            double score = correctAnswers * 350;
            return (int)Math.Round(score / increment);
        }
        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            totalTasks++;
            if(Answer.Text == GetResult().ToString())
            {
                correctAnswers++;
                Update();
            }
            else
            {
                wrongAnswers++;
                Update();
            }
            if (totalTasks == 10)
            {
                Update();
                dt.Stop();
                MessageBox.Show($"Your score: {CountScore()}, Time: {minutes} : {seconds}");
                RestartGame();
            }
            else
            {
                firstOperand = 3;
                secondOperand = 2;
                NextTask();
                Clear(sender, e);
            }
        }
        private void RestartGame()
        {
            correctAnswers = 0;
            wrongAnswers = 0;
            firstOperand = 3;
            secondOperand = 2;
            increment = 0;
            minutes = 0;
            NextTask();
            Answer.Text = "";
            Time.Text = "Time: 0:0";
            totalTasks = 0;
            dt.Start();
            Update();
        }


    }
}
