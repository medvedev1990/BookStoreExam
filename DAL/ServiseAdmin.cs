using System;
using System.Collections.Generic;
using System.Text;
using BAL;
using LiteDB;

namespace DAL
{
    public class ServiseAdmin
    {
        //проверка логина и пароля
        public bool Correct(string log, string pass)
        {
            {
                using (var db = new LiteDatabase(@"BookStore.db"))
                {
                    var col = db.GetCollection<Readers_Details>("Users");
                    var result = col.FindAll();
                    foreach (Readers_Details adm in result)
                    {
                        if ((adm.Name == log)&&(adm.Password == pass))
                        {
                            return true;
                        } 
                    }
                    return false;
                }
            }
        }
        //Добавление Администратора
        public void  AdminAdd(Administrator admin)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Administrator>("Administators");
                var result = col.FindAll();

                if (result == null)
                { 
                    col.Insert(admin);
                }
            }
        }
        //Добавление Пользователя
        public bool UserAdd(Readers_Details User)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (User.Name == adm.Name)
                        return false;
                }
                col.Insert(User);
                return true;
            }
        }
        //Изминение пользователя
        public bool UserUpdate(string Name, string parametr, string newParams)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Name == Name)
                    {
                        if (parametr == "Adress")
                            adm.Adress = newParams;
                        else if (parametr == "Phone")
                            adm.Contact = newParams;
                        else if (parametr == "E-Mail")
                            adm.E_Mail = newParams;
                        col.Update(adm);
                        return true;
                    }
                }
                return false;
            }
        }
        //Добавление книги
        public bool BookAdd(BookDetails book)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<BookDetails>("Books");
                var result = col.FindAll();
                foreach (BookDetails boking in result)
                {
                    if (book.S_No == boking.S_No)
                        return false;
                }
                col.Insert(book);
                return true;
            }
        }
        //Поиск книги
        public BookDetails SearchBook(string Name)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<BookDetails>("Books");
                var result = col.FindAll();
                foreach (BookDetails boking in result)
                {
                    if (boking.Name == Name)
                        return boking;
                }
            }
            return null;
        }

        //Изминение пароля Админа
        public bool PassChangeAdmin(string log, string pass)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Administrator>("Administators");
                var result = col.FindAll();
                foreach (Administrator adm in result)
                {
                    if (adm.Admin_Name == log)
                    {
                        adm.Admin_Password = pass;
                        col.Update(adm);
                        return true;
                    }
                }
                return false;
            }
        }
        //посмотреть список Заблокированных пользователей
        public List<Readers_Details> ListBlockUser()
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                List<Readers_Details> Users = new List<Readers_Details>();
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Status == Status.No)
                    {
                        Users.Add(adm);
                    }
                }
                return Users;
            }
        }
        //Заблокировать пользователя
        public bool BlockUser(string Name)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Name == Name)
                    {
                        adm.Status = Status.No;
                        col.Update(adm);
                        return true;
                    }
                }
                return false;
            }
        }
        //сбросить пароль пользователю
        public bool ResetPassUser(string Name)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Name == Name)
                    {
                        adm.Password = "123";
                        col.Update(adm);
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
