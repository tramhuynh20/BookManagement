using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyBookLibrary;

namespace Assignment02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Assignment02";

            ManageBook mb = new ManageBook();

            mb.listBooks.Add(new Book("120", "Dac Nhan Tam", "NXB Tong Hop TPHCM", 76.440f));
            mb.listBooks.Add(new Book("121", "Doi Thay Doi Khi Chung Ta Thay Doi", "NXB Tre", 39.950f));
            mb.listBooks.Add(new Book("122", "Nha Lanh Doo Khong Chuc Danh", "NXB Tre", 68.000f));
            mb.listBooks.Add(new Book("123", "Cho Toi Xin Mot Ve Di Tuoi Tho", "NXB Tre", 140.000f));

            string choice;
            Boolean checkChoice;
            do
            {
                Console.WriteLine("1.Add new book.");
                Console.WriteLine("2.Update a book.");
                Console.WriteLine("3.Delete a book.");
                Console.WriteLine("4.List all book.");
                Console.WriteLine("5.Quit.");
                do
                {
                    Console.Write("Choose one option to continue: ");
                    choice = Console.ReadLine();
                    checkChoice = Regex.Match(choice, @"^[1-5]{1}$").Success;
                    if (choice.Equals("5"))
                    {
                        Environment.Exit(0);
                    }
                    if (checkChoice == false)
                    {
                        Console.WriteLine("Choice must be a digit (1->5)!!! Try again.");
                        checkChoice = false;
                    }
                } while (checkChoice == false);

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("----Add new book----");

                        Boolean checkID;
                        string ID;
                        do
                        {
                            Console.Write("Input ID: ");
                            ID = Console.ReadLine();
                            if (mb.Find(ID) == null)
                            {

                                checkID = Regex.Match(ID, @"^[0-9]{3}$").Success;

                                if (checkID == false)
                                {
                                    Console.WriteLine("ID must have 3 digits!!! Try again.");
                                }
                            }
                            else
                            {
                                checkID = false;
                                Console.WriteLine("ID was existed!!! Try again.");
                            }
                        } while (checkID == false);

                        Boolean checkName;
                        string name;
                        do
                        {
                            Console.Write("Input name: ");
                            name = Console.ReadLine();
                            checkName = Regex.Match(name, @"^([a-zA-Z0-9 ]{1,50}[^(\s)])$").Success;
                            if (checkName == false)
                            {
                                Console.WriteLine("Invalid name!!! Try again.");
                            }
                        } while (checkName == false);

                        Boolean checkProducer;
                        string producer;
                        do
                        {
                            Console.Write("Input producer: ");
                            producer = Console.ReadLine();
                            checkProducer = Regex.Match(producer, @"^([a-zA-Z ]{1,50}[^(\s)])$").Success;
                            if (checkProducer == false)
                            {
                                Console.WriteLine("Invalid producer!!! Try again.");
                            }
                        } while (checkProducer == false);

                        float price=0;
                        bool check = false;
                        do
                        {
                            try
                            {
                                Console.Write("Input price: ");
                                price = float.Parse(Console.ReadLine());

                                check = true;
                            }catch(Exception e) {
                                Console.WriteLine("Invalid price!!! Try agian.");
                            }
                        } while (check == false);

                        Book book = new Book(ID, name, producer, price);
                        mb.listBooks.Add(book);
                        break;
                    case "2":
                        Console.WriteLine("----Update a book----");
                        Console.Write("Input ID: ");
                        ID = Console.ReadLine();

                        if (mb.Find(ID) != null)
                        {
                            do
                            {
                                Console.Write("Input name: ");
                                name = Console.ReadLine();
                                checkName = Regex.Match(name, @"^([a-zA-Z ]{1,50}[^(\s)])$").Success;
                                if (checkName == false)
                                {
                                    Console.WriteLine("Invalid name!!! Try again.");
                                }
                            } while (checkName == false);

                            do
                            {
                                Console.Write("Input producer: ");
                                producer = Console.ReadLine();
                                checkProducer = Regex.Match(producer, @"^([a-zA-Z ]{1,50}[^(\s)])$").Success;
                                if (checkProducer == false)
                                {
                                    Console.WriteLine("Invalid producer!!! Try again.");
                                }
                            } while (checkProducer == false);

                            price = 0;
                            check = false;
                            do
                            {
                                try
                                {
                                    Console.Write("Input price: ");
                                    price = float.Parse(Console.ReadLine());

                                    check = true;
                                }
                                catch (Exception e)
                                {
                                    e.ToString();
                                }
                            } while (check == false);

                            book = new Book(ID, name, producer, price);

                            mb.updateBook(book);

                            Console.WriteLine("Update successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Not found!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("----Delete a book----");
                        Console.Write("Input ID: ");
                        ID = Console.ReadLine();
                        mb.deleteBook(ID);
                        break;
                    case "4":
                        Console.WriteLine("----List all book----");
                        mb.PrintAll();
                        break;
                }
            } while (choice.Equals("1") || choice.Equals("2") || choice.Equals("3") || choice.Equals("4"));
        }
    }
}
