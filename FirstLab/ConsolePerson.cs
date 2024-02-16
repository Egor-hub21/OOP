using People;

namespace FirstLab
{
    /// <summary>
    /// Клас реализующий взаимодействие <see cref="Person"/>
    /// с пользователем.
    /// </summary>
    public class ConsolePerson
    {
        /// <summary>
        /// Чтения <see cref="Person"/> с клавиатуры.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Person"/>.</returns>
        public static Person ConsoleReadPerson()
        {
            Person сonsolePerson = new Person();

            string enteredGender;

            bool test;

            do
            {
                Console.WriteLine("Введите имя: ");
                test = false;
                try
                {
                    сonsolePerson.FirstName = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Возникло исключение {ex.Message}");
                    test = true;
                }
            }
            while (test);

            do
            {
                Console.WriteLine("Введите фамилию: ");
                test = false;
                try
                {
                    сonsolePerson.LastName = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Возникло исключение {ex.Message}");
                    test = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Возникло исключение {ex.Message}");
                    test = true;
                }
            }
            while (test);

            do
            {
                Console.WriteLine($"Введите Возраст человека: ");
                test = false;
                try
                {
                    сonsolePerson.Age = Convert.ToInt32(Console.ReadLine());
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Возникло исключение {ex.Message}");
                    test = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Возникло исключение {ex.Message}");
                    test = true;
                }

            }
            while (test);

            do
            {
                Console.WriteLine("Введите пол (Male/Female): ");
                enteredGender = Console.ReadLine();

                if (!Person.WordStyleСompliance(enteredGender))
                {
                    Console.WriteLine($"\n!При вводе использовались " +
                                      $"недопустимые символы!\n " +
                                      $"Попробуйте снова:");
                    if (!string.IsNullOrEmpty(enteredGender))
                    {
                        enteredGender = string.Empty;
                    }
                }
                else
                {
                    enteredGender = Person.CorrectionRegister(enteredGender);
                    if (enteredGender == "Male")
                    {
                        сonsolePerson.Gender = Gender.Male;
                    }
                    else if (enteredGender == "Female")
                    {
                        сonsolePerson.Gender = Gender.Female;
                    }
                    else
                    {
                        Console.WriteLine("\n!Ошибка ввода!" +
                                          "\nПопробуйте снова:");
                        enteredGender = string.Empty;
                    }
                }
            }
            while (string.IsNullOrEmpty(enteredGender));

            return сonsolePerson;
        }
    }
}
