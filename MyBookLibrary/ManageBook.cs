using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
    public class Book
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public float price { get; set; }

        public Book()
        {
        }

        public Book(string iD, string name, string publisher, float price)
        {
            ID = iD;
            this.name = name;
            this.publisher = publisher;
            this.price = price;
        }

        public string viewInformation => $"ID: {ID}, Name: {name}, Publisher: {publisher}, Price: {price}";
    }
    public class ManageBook
    {
        public ArrayList listBooks = new ArrayList();

        public Book Find(string ID)
        {
            foreach (Book book in listBooks)
            {
                if (book.ID.Equals(ID))
                {
                    return book;
                }
            }
            return null;
        }

        public void PrintAll()
        {
            foreach (Book book in listBooks)
            {
                Console.WriteLine(book.viewInformation);
            }
        }

        public void updateBook(Book book1)
        {
            int i = 0;
            foreach (Book book2 in listBooks)
            {
                if (book2.ID.Equals(book1.ID))
                {
                    listBooks[i] = book1;
                    return;
                }
                i++;
            }
        }
        public void deleteBook(String bookID)
        {
            Book b = Find(bookID);
            if (b != null)
            {
                listBooks.Remove(b);
            } 
        }
    }
}
