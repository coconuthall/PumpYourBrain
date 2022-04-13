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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PumpYourBrain.MVVM.View
{
    /// <summary>
    /// Interaction logic for FindTheNumberView.xaml
    /// </summary>
    public partial class FindTheNumberView : UserControl
    {
        public FindTheNumberView()
        {
            InitializeComponent();
        }
        private List<int> numbers = new List<int>();
        private int answer;
        DispatcherTimer dt = new DispatcherTimer();
        public int increment = 0;
        public int minutes = 0;
        public int seconds = 0;
        public int answers = 15;
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
        private void StartGame(object sender, RoutedEventArgs e)
        {
            increment = 0;
            minutes = 0;
            seconds = 0;
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
            Button SenderButton = sender as Button;
            SenderButton.Visibility = Visibility.Hidden;
            for(int i = 1; i <= 25; i++)
            {
                numbers.Add(i);
            }
            DrawGame();
            Next();
        }

        private void DrawGame()
        {
            int canvasTop = 165;
            int canvasLeft = 280;
            int id = 0;
            for(int i = 1; i <= 5; i++){
                canvasTop += 75;
                canvasLeft = 280;
                for (int j = 1; j <= 5; j++)
                {
                    Button b = new Button
                    {
                        Width = 50,
                        Height = 50,
                        Cursor = Cursors.Hand,
                        Tag = id,
                        Background = new SolidColorBrush(Color.FromRgb(88, 133, 175))
                    };
                    b.Click += (source, e) =>
                    {
                        CheckAnswer(source, e);
                    };
                    id++;
                    Canvas.Children.Add(b);
                    Canvas.SetLeft(b, canvasLeft);
                    Canvas.SetTop(b, canvasTop);
                    canvasLeft += 75;
                }
            }
        }

        private void Next()
        {
            Random rnd = new Random();
            var randomList = numbers.OrderBy(a => Guid.NewGuid()).ToList();
            numbers = randomList;
            foreach (var x in Canvas.Children.OfType<Button>())
            {
                if (Int32.Parse(x.Tag.ToString()) <= 25)
                {
                    x.Content = numbers[Int32.Parse(x.Tag.ToString())];
                    x.Background = new SolidColorBrush(Color.FromRgb(88, 133, 175));
                }

            }
            answer = rnd.Next(1, 25);
            Task.Text = $"Find: {answer}";
            UpdateScore();
        }
        private void UpdateScore()
        {
            Score.Text = $"Tasks Left: {answers}";
        }
        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("answer checked");
            Button senderButton = sender as Button;
            if(Int32.Parse(senderButton.Content.ToString()) == answer)
            {
                answers--;
                if (answers == 0)
                {
                    dt.Stop();
                    UpdateScore();
                    MessageBox.Show($"Your time: {minutes}:{seconds}");
                    RestartGame();
                }
                else
                {
                    Next();
                }

            }
            else
            {
                senderButton.Background = new SolidColorBrush(Colors.Red);
            }
        }
        private void RestartGame()
        {
            Start.Visibility = Visibility.Visible;
            answers = 15;
            Task.Text = "Click to start the game";
            Time.Text = "Time:";
            Score.Text = "Tasks Left:";
            foreach (var x in Canvas.Children.OfType<Button>())
            {
                if(Int32.Parse(x.Tag.ToString()) <= 25)
                {
                    x.Visibility = Visibility.Collapsed;
                }
                
            }
        }
    }
}
