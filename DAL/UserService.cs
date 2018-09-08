using System;
using System.Collections.Generic;
using System.Text;
using BAL;
using LiteDB;

namespace DAL
{
   public class UserService
    {
        //Взять книгу
        public bool Take_Book(string Name, int serialNumber)
        {
            Feedback fb = new Feedback();
            BookDetails bd = new BookDetails();
            Readers_Details User = new Readers_Details();

            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Name == Name)
                    {
                        User = adm;
                        bd = SearchBook(serialNumber);
                        adm.ListBook.Add(bd);
                        col.Update(adm);
                    }
                }
            }
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Feedback>("FeedBack");
                fb.Author = bd.Author_Name;
                fb.Borrow_Name = User;
                fb.Code = bd.Code;
                fb.Issue_Date = DateTime.Now;
                fb.S_No = bd.S_No;
                fb.Name = bd.Name;
                col.Insert(fb);
                return true;
            }
        }
        //веруть книгу
        public bool Get_Book(string Name, int serialNumber)
        {
            Feedback fb = new Feedback();
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Name == Name)
                    {
                        adm.ListBook.Remove(SearchBook(serialNumber));
                        col.Update(adm);
                    }
                }
            }
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Feedback>("FeedBack");
                var result = col.FindAll();
                foreach (Feedback adm in result)
                {
                    if (adm.S_No == serialNumber)
                    {
                        col.Delete(adm.S_No);
                    }
                }
                return true;
            }
        }
        //Извинение пароля
        public bool PassChangeUser(string log, string pass)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<Readers_Details>("Users");
                var result = col.FindAll();
                foreach (Readers_Details adm in result)
                {
                    if (adm.Name == log)
                    {
                        adm.Password = pass;
                        col.Update(adm);
                        return true;
                    }
                }
                return false;
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
        public BookDetails SearchBook(int Serial_Number)
        {
            using (var db = new LiteDatabase(@"BookStore.db"))
            {
                var col = db.GetCollection<BookDetails>("Books");
                var result = col.FindAll();
                foreach (BookDetails boking in result)
                {
                    if (boking.S_No == Serial_Number)
                        return boking;
                }
            }
            return null;
        }
    }
}
  
