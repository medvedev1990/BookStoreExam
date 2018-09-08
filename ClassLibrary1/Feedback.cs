using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public class Feedback
    {
        //выпуск
        public int Issue_No { get; set; }
        //Серийный номер
        public int S_No { get; set; }
        //название книги
        public string Name { get; set; }
        //код
        public int Code { get; set; }
        //тип (жанр)
        public string Type { get; set; }
        //Кому Выдана
        public Readers_Details Borrow_Name { get; set; }
        //Автор
        public string Author { get; set; }
        //Дата Выдачи
        public DateTime Issue_Date { get; set; }
        //Дата возврата
        public DateTime Return_Date { get; set; }

    }
}
