using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;


namespace UI
{
    public class Interfeis
    {
        private void  UserMenu(string login)
        {
            Console.Clear();
            Console.WriteLine("(1)Взять книгу\n(2)Вернуть книгу\n(3)ChangePassword\n(4)Serch Book");
            int b = int.Parse(Console.ReadLine());
            switch (b)
            {
                case 1:
                    {
                        UserService Us = new UserService();
                        Console.Clear();
                        Console.WriteLine("Введите серийный номер");
                        int s_No = int.Parse(Console.ReadLine());
                       if ( Us.Take_Book(login, s_No)==false)
                            Console.WriteLine("ошибка");
                        Console.WriteLine("Ok");
                    }
                    break;
                case 2:
                    {
                        UserService Us = new UserService();
                        Console.Clear();
                        int s_No = int.Parse(Console.ReadLine());
                        if (Us.Get_Book(login,s_No)==false)
                            Console.WriteLine("Error");
                        Console.WriteLine("OK");
                        
                    }
                    break;
                case 3:
                    {
                        UserService us = new UserService();
                        Console.Clear();
                        Console.Write("Please enter old password: ");
                        string pass = Console.ReadLine();
                        Console.Write("Please enter new password: ");
                        string newPass = Console.ReadLine();
                        Console.Write("Please repeat enter new password: ");
                        string repeatNewPass = Console.ReadLine();
                        if (newPass == repeatNewPass)
                            us.PassChangeUser(login, newPass);
                        else
                            Console.WriteLine("Error");
                    }
                    break;
                case 4:
                    {
                        UserService us = new UserService();
                        BookDetails bd = new BookDetails();
                        Console.Clear();
                        Console.Write("Enter name book: ");
                        string nameBook = Console.ReadLine();
                       bd= us.SearchBook(nameBook);
                        Console.WriteLine(bd.Name,bd.S_No,bd.Author_Name,bd.PublichDate);
                    }
                    break;
            }
        }
        private void AdminMenu(string login)
        {
            ServiseAdmin Sa = new ServiseAdmin();
            UserService Us = new UserService();
            Console.WriteLine("----Menu Administratora----");
            Console.WriteLine("(1)Search book\n(2)Add Book\n(3)Change Password\n ");
            Console.WriteLine("--Обслуживание пользователей--");
            Console.WriteLine("(4)Add User\n(5)Update User: ");
            Console.WriteLine("--Security--");
            Console.WriteLine("(6)Список Блокированных пользователей\n(7)Блокировать пользователя\n(8)Сбросить пароль пользователю");
            Console.Write("Выберите пункт меню: ");
            int a = int.Parse(Console.ReadLine());
            switch(a)
            {
                case 1:
                    {
                        BookDetails bd = new BookDetails();
                        Console.Clear();
                        Console.Write("Enter name book: ");
                        string nameBook = Console.ReadLine();
                        bd = Sa.SearchBook(nameBook);
                        Console.WriteLine(bd.Name, bd.S_No, bd.Author_Name, bd.PublichDate);

                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        BookDetails book = new BookDetails();
                        Console.Write("Please enter Name Book: ");
                        book.Name = Console.ReadLine();
                        Console.Write("Please enter Author: ");
                        book.Author_Name = Console.ReadLine();
                        Console.Write("Please enter Serial Number: ");
                        book.S_No = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter type: ");
                        book.Type = Console.ReadLine();
                        Console.Write("Please enter code book: ");
                        book.Code = int.Parse(Console.ReadLine());
                        Console.Write("Please enter publish date in format dd:mm:gggg : ");
                        string datePub = Console.ReadLine();
                        DateTime dt = new DateTime();
                        DateTime.TryParse(datePub, out dt);
                        book.PublichDate = dt;
                        Console.Write("Please enter edition books: ");
                        book.Edition = int.Parse(Console.ReadLine());
                        Console.Write("Please enter status: ");
                        book.Status = Console.ReadLine();
                        Sa.BookAdd(book);
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.Write("Please enter old password: ");
                        string pass = Console.ReadLine();
                        Console.Write("Please enter new password: ");
                        string newPass = Console.ReadLine();
                        Console.Write("Please repeat enter new password: ");
                        string repeatNewPass = Console.ReadLine();
                        Sa.PassChangeAdmin(login, pass);
                    }
                    break;
                case 4:
                    {
                        Console.Clear();
                        Readers_Details user = new Readers_Details();
                        Console.Write("Please enter Login: ");
                        user.Name = Console.ReadLine();
                        Console.Write("Please enter Password: ");
                        user.Password = Console.ReadLine();
                        Console.Write("Please enter Adress: ");
                        user.Adress = Console.ReadLine();
                        Console.Write("Please enter Phone: ");
                        user.Contact = Console.ReadLine();
                        Console.Write("Please enter E-Mail: ");
                        user.E_Mail = Console.ReadLine();
                        Sa.UserAdd(user);
                    }
                    break;
                case 5:
                    {
                        Console.Clear();
                        Console.Write("Введите имя пользователя:  ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Какой параметр хотите изменить");
                        Console.WriteLine("(1)Adress\n(2)Phone(3)E-Mail");
                        int b = int.Parse(Console.ReadLine());
                        switch (b)
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter new adress: ");
                                    string adress = Console.ReadLine();        
                                    Sa.UserUpdate(name, "Adress", adress);
                                }
                                break;
                            case 2:
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please enter new Phone: ");
                                    string phone = Console.ReadLine();
                                    Sa.UserUpdate(name, "Phone", phone);
                                }
                                break;
                            case 3:
                                {
                                    Console.Clear();

                                    Console.WriteLine("Please Enter new E-Mail");
                                    string email = Console.ReadLine();
                                    Sa.UserUpdate(name, "E-Mail", email);
                                }
                                break;
                        }
                    }
                    break;
                case 6:
                    {
                        Console.Clear();
                        //вызов метода списка блокированных пользователей
                        List<Readers_Details>BlockUsers = Sa.ListBlockUser();
                        foreach(Readers_Details res in BlockUsers)
                        {
                            Console.WriteLine(res.Name,"\n",res.Contact,"\n",res.E_Mail,"\n\n");
                        }
                    }
                    break;
                case 7:
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter login user:");
                        string logIn = Console.ReadLine();
                        Sa.BlockUser(logIn);
                        //вызов метода блокировки пользователя
                    }
                    break;
                case 8:
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter login user:");
                        string logIn = Console.ReadLine();
                        //вызов метода сброса пароля
                        Sa.ResetPassUser(logIn);
                    }
                    break;
            }
        }
        public void Input()
        {
            ServiseAdmin Sa = new ServiseAdmin();
            Administrator adm = new Administrator();
            adm.Admin_Name = "Admin";
            adm.Admin_Password = "1234";          
            Console.WriteLine("----Welcome----");           
            Sa.AdminAdd(adm);
            {
                Console.WriteLine("(1)Registration\n(2)Log In");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        {

                            Readers_Details user = new Readers_Details();
                            Console.Write("Please enter Login: ");
                            user.Name = Console.ReadLine();
                            Console.Write("Please enter Password: ");
                            user.Password = Console.ReadLine();
                            Console.Write("Please enter Adress: ");
                            user.Adress = Console.ReadLine();
                            Console.Write("Please enter Phone: ");
                            user.Contact = Console.ReadLine();
                            Console.Write("Please enter E-Mail: ");
                            user.E_Mail = Console.ReadLine();
                            Sa.UserAdd(user);

                        }
                        break;
                    case 2:
                        {
                            Console.Write("Please enter Your Login: ");
                            string login = Console.ReadLine();
                            Console.Write("Please enter Your Password: ");
                            string password = Console.ReadLine();
                            if ((login == adm.Admin_Name) && (password == adm.Admin_Password))
                                AdminMenu(login);
                            if (Sa.Correct(login, password))
                                UserMenu(login);
                            else
                            {
                                int chek = 0;
                                if (chek<3)
                                { Console.WriteLine("Не верно введен login or password"); }
                                Environment.Exit(0);
                            }    
                        }
                        break;
                }
            }
            
            
        }
    }
}
