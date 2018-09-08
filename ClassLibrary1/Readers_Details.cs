using System;
using System.Collections.Generic;
using System.Text;

namespace BAL
{
    public enum Status { No, Yes};
    public class Readers_Details
    {
        //id читателя
        public int ReaderId { get; set; }
        //Имя
        public string Name { get; set; }
        //Пароль
        public string Password { get; set; }
        //Адресс
        public string Adress { get; set; }
        //Номер телефона
        public string Contact { get; set; }
        //E-Mail
        public string E_Mail { get; set; }
        public Status Status { get; set; }
        public List<BookDetails> ListBook { get; set; }
    }
}
