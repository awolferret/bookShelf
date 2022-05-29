using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.Working();
        }
    }

    class BookShelf
    {
        private bool _isWorking = true;
        private List<Book> _books = new List<Book>();
        private int noMatchCode = 1;
        private int wrongInputCode = 2;

        public void Working()
        {
            string input = " ";

            while (_isWorking)
            {
                Console.WriteLine("\n1. Добавить книгу");
                Console.WriteLine("2. Показать все книги");
                Console.WriteLine("3. Убрать Книгу");
                Console.WriteLine("4. Поиск книги");
                Console.WriteLine("5. Выход");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ShowBookShelf();
                        break;
                    case "3":
                        RemoveBook();
                        break;
                    case "4":
                        SearchBook();
                        break;
                    case "5":
                        Exit();
                        break;
                    default:
                        ShowWarningMessage(wrongInputCode);
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Введите название");
            string name = Console.ReadLine();
            Console.WriteLine("Ведите автора");
            string author = Console.ReadLine();
            Console.WriteLine("Ведите год");
            string input = Console.ReadLine();
            int year;

            if (int.TryParse(input, out year))
            {
               _books.Add(new Book(name, author, year));
            }
            else
            {
                ShowWarningMessage(wrongInputCode);
            }
        }

        private void ShowBookShelf()
        {
            Console.Clear();

            if (_books.Count > 0)
            {
                Console.WriteLine("Список");

                for (int i = 0; i < _books.Count; i++)
                {
                    Console.Write($"{i + 1}.");
                    _books[i].ShowBookInfo();
                }
            }
            else 
            {
                Console.WriteLine("В списке еще нет книг");
            }
        }

        private void RemoveBook()
        {
            Console.Clear();

            if (_books.Count > 0)
            {
                Console.WriteLine("Введите номер книги которую хотите убрать");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number) && number <= _books.Count)
                {
                    _books.RemoveAt(number - 1);
                }
                else
                {
                    ShowWarningMessage(wrongInputCode);
                }
            }
            else
            {
                Console.WriteLine("В списке еще нет книг");
            }
        }

        public void SearchBook()
        {
            Console.Clear();
            Console.WriteLine("1.Искать по названию");
            Console.WriteLine("2.Искать по автору");
            Console.WriteLine("3.Искать по году");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SearchName();
                    break;
                case "2":
                    SearchAuthor();
                    break;
                case "3":
                    SearchYear();
                    break;
                default:
                    ShowWarningMessage(2);
                    break;
            }
        }

        public void SearchName()
        {
            Console.Clear();
            Console.WriteLine("Введите искомое название");
            string input = Console.ReadLine();
            int index = 0;

            foreach (var book in _books)
            {
                if (input.ToLower() == book.Name.ToLower())
                {
                    index++;
                    _books[index-1].ShowBookInfo();
                }
                else
                {
                    ShowWarningMessage(noMatchCode);
                }
            }
        }

        public void SearchAuthor()
        {
            Console.Clear();
            Console.WriteLine("Введите искомого автора");
            string input = Console.ReadLine();
            int index = 0;
            foreach (var book in _books)
            {
                if (input.ToLower() == book.Author.ToLower())
                {
                    index++;
                    _books[index-1].ShowBookInfo();
                }
                else
                {
                    ShowWarningMessage(noMatchCode);
                }
            }
        }
        public void SearchYear()
        {
            Console.Clear();
            Console.WriteLine("Введите нужный год");
            string input = Console.ReadLine();
            int number;
            int index = 0;
            if (int.TryParse(input, out number))
            {
                foreach (var book in _books)
                {
                    if (number == book.ReleaseYear)
                    {
                        index++;
                        _books[index - 1].ShowBookInfo();
                    }
                    else
                    {
                        ShowWarningMessage(noMatchCode);
                    }
                }
            }
            else
            {
                ShowWarningMessage(wrongInputCode);
            }
        }

        private string ShowWarningMessage(int warningCode)
        {
            string message = " ";

            switch (warningCode)
            {
                case 1:
                    Console.WriteLine("Ничего не найденно, что бы продожить нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("Некоректный ввод, что бы продожить нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
            return message;
        }

        public void Exit()
        {
            _isWorking = false;
        }
    }

    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int ReleaseYear{ get; private set; }

        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public void ShowBookInfo()
        {
            Console.WriteLine($"Название {Name}, автор {Author}, год выпуска {ReleaseYear}");
        }
    }
}