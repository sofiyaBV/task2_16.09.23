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

namespace task2_16._09._23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private DispatcherTimer timer;
      
        private async void CreateProgressBars_Click(object sender, RoutedEventArgs e)
        {
            stackPanel_bar.Children.Clear();
            int progressBarCount = GetProgressBarCountFromUser();
            CreateAndAddProgressBars(progressBarCount);

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (ProgressBar progressBar in stackPanel_bar.Children)
            {
                if (progressBar != null)
                {
                    Random rand = new Random();
                    int value = rand.Next(0, 100);
                    progressBar.Dispatcher.Invoke(() =>
                    {
                        progressBar.Value = value;
                    });
                }
            }
        }
        private int GetProgressBarCountFromUser()
        {

            int count = Convert.ToInt32(number_TB.Text.ToString());
            return count;
        }

        private void CreateAndAddProgressBars(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ProgressBar progressBar = new ProgressBar();
                progressBar.Height = 30;
                progressBar.Margin = new Thickness(10);
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                progressBar.Foreground = new SolidColorBrush(GetRandomColor());

                stackPanel_bar.Children.Add(progressBar);
            }
        }

        private Color GetRandomColor()
        {
            Random rand = new Random();
            return Color.FromRgb((byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256));
        }
    }
}
