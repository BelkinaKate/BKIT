using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Microsoft.Win32;

using Lab5;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _words;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Text Files(*.txt) | *.txt"
            };

            var timer = new Stopwatch();

            if (dialog.ShowDialog() == true)
            {
                timer.Start();
                var file = File.ReadAllText(dialog.FileName);
                _words = file.Trim('.').Trim(',').Split(' ').Distinct().ToList();
                timer.Stop();

                openTimer.Content = "Время чтения: " + timer.ElapsedMilliseconds + " мс";
            }
           
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();

            var expectedWord = findWord.Text.Trim(' ');

            if (expectedWord == "")
            {
                listBox.Items.Add("Введите слово для поиска");
                return;
            }

            if (maxDist.Text.Trim(' ') == "")
            {
                listBox.Items.Add("Введите максимальное расстояние");
                return;
            }

            var dist = int.Parse(maxDist.Text.Trim(' '));
            var timer = new Stopwatch();

            timer.Start();

            foreach (var word in _words)
            {
                if (Lab5.Lab5.Dist(word, expectedWord) <= dist)
                {
                    listBox.Items.Add(word);
                }
            }

            timer.Stop();
            if (listBox.Items.Count == 0)
            {
                listBox.Items.Add("Нет совпадений");
            }

            searchTimer.Content = "Время поиска: " + timer.ElapsedMilliseconds + " мс";
        }
    }
}
