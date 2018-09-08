using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public class BookDetails
    {
        //Серийный номер
        public int S_No { get; set; }
        //Название книги
        public string  Name { get; set; }
        //Код
        public int Code { get; set; }
        //Тип
        public string Type { get; set; }
        //Имя Автора
        public string Author_Name { get; set; }
        //Дата Публикации
        public DateTime PublichDate { get; set; }
        //тираж
        public int Edition { get; set; }
        //статус
        public string Status { get; set; }
    }
}
