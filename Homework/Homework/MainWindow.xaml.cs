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

namespace Homework
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

            if (countOfThreads.Text.Trim(' ') == "")
            {
                listBox.Items.Add("Введите количество потоков");
                return;
            }

            var dist = int.Parse(maxDist.Text);
            var tasksCount = int.Parse(countOfThreads.Text);
            var timer = new Stopwatch();
            var tasks = new Task<List<string>>[tasksCount];

            var listOfWords = new List<List<string>>();
            for (var i = 0; i < tasksCount; i++)
            {
                listOfWords.Add(new List<string>());
            }

            for (var i = 0; i < _words.Count; i += tasksCount)
            {
                for (var j = 0; j < tasksCount && i + j < _words.Count; j++)
                {
                    listOfWords[j].Add(_words[i + j]);
                }
            }

            timer.Start();

            for (var i = 0; i < tasksCount; i++)
            {
                var list = listOfWords[i];
                tasks[i] = Task.Run(() =>
                {
                    var findList = new List<string>();
                    foreach (var word in list)
                    {
                        if (Lab5.Lab5.Dist(word, expectedWord) <= dist)
                        {
                            findList.Add(word);
                        }
                    }

                    return findList;
                });
            }

            
            Task.WaitAll(tasks);
          
            foreach (var task in tasks)
            {
                foreach (var word in task.Result)
                {
                    listBox.Items.Add(word);
                }
            }

            timer.Stop();

            Console.WriteLine("Count of tasks: " + tasksCount + " has found " + listBox.Items.Count + " words");

            if (listBox.Items.Count == 0)
            {
                listBox.Items.Add("Нет совпадений");
            }

            searchTimer.Content = "Время поиска: " + timer.ElapsedMilliseconds + " мс";
        }
    }
}
