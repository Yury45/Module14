namespace Task1
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            //  создаём список с типом данных Contact
            var phoneBook = new List<Contact>()
                {
                    new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                    new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                    new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                    new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                    new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                    new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
                }
                .OrderBy(s => s.Name)
                .ThenBy(s => s.LastName);

            while (true)
            {
                // Читаем введенный с консоли символ
                var input = Console.ReadKey().KeyChar;

                // проверяем, число ли это
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                    Console.WriteLine();
                }
                // если соответствует - запускаем вывод
                else
                {
                    // пропускаем нужное количество элементов и берем 2 для показа на странице
                    var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    // выводим результат
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }   
        }
    }
}
