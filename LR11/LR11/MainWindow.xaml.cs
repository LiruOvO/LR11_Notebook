using System;
using System.IO;
using System.Windows;

namespace LR11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextRecord records = new TextRecord();
        TaskList tasks = new TaskList();
        public MainWindow()
        {
            InitializeComponent();
            AllTasks();
        }

        //Виведення інформації
        public void AllTasks()
        {
            string filePath = @"D:\Урочки\ООП\ЛР11\TaskList.txt";
            string[] allLines = File.ReadAllLines(filePath);
            foreach (string line in allLines)
            {
                string[] parts = line.Split('$');
                tasks.TaskText = parts[0];
                taskList.Items.Add(tasks.TaskText);
            }

            filePath = @"D:\Урочки\ООП\ЛР11\TextRecord.txt";
            allLines = File.ReadAllLines(filePath);
            foreach (string line in allLines)
            {
                string[] parts = line.Split('$');
                records.RecordText = parts[0];
                textRecords.Items.Add(records.RecordText);
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //Додавання завдання
            if (myComboBox.Text == "Додати завдання" && newInfo.Text !="")
            {
                tasks.TaskText = newInfo.Text;
                string filePath = @"D:\Урочки\ООП\ЛР11\TaskList.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{tasks.TaskText}$");
                }
                taskList.Items.Clear();
                textRecords.Items.Clear();
                AllTasks();
                newInfo.Clear();
                tasks.CreationDate = DateTime.Now;
                date.Content = "Остання зміна: " + tasks.CreationDate;
            }
            //Додавання запису
            else if (myComboBox.Text == "Додати запис" && newInfo.Text != "")
            {
                records.RecordText = newInfo.Text;
                string filePath = @"D:\Урочки\ООП\ЛР11\Textrecord.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{records.RecordText}$");
                }
                taskList.Items.Clear();
                textRecords.Items.Clear();
                AllTasks();
                newInfo.Clear();
                tasks.CreationDate = DateTime.Now;
                date.Content = "Остання зміна: " + tasks.CreationDate;
            }
            //Нагадування
            else if (myComboBox.Text == "Додати нагадування" && newInfo.Text != "")
            {
                notification.Content = newInfo.Text;
                tasks.CreationDate = DateTime.Now;
                date.Content = "Остання зміна: " + tasks.CreationDate;
            }
            
        }

        //Видалення
        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (textRecords.SelectedItem != null)
            {
                // Видалення обраного елемента з ListView
                textRecords.Items.Remove(textRecords.SelectedItem);
            }
            if (taskList.SelectedItem != null)
            {
                // Видалення обраного елемента з ListView
                taskList.Items.Remove(taskList.SelectedItem);
            }
        }
    }
}
