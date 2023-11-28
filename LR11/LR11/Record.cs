using System;

namespace LR11
{
    public abstract class Record
    {
        public DateTime CreationDate { get; set; }
    }

    public class TextRecord : Record//текстові записи
    {
        public string RecordText { get; set; }
    }
    public class TaskList : Record//списки справ
    {
        public string TaskText { get; set; }
    }

    public class Reminder : Record//нагадування
    {
        public string ReminderText { get; set; }
    }
}
