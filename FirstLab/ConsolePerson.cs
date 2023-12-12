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
            string firstName = string.Empty;
            string lastName = string.Empty;
            int age;
            string enteredGender;
            while (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Введите имя: ");
                firstName = VerificationWord(firstName);

                Console.WriteLine("Введите фамилию: ");
                lastName = VerificationWord(lastName);

                if (!Person.AlphabeticalControl(lastName, firstName))
                {
                    Console.WriteLine($"Фамилия и имя введены с использованием разных алфавитов");

                    firstName = string.Empty;
                    lastName = string.Empty;
                }
            }

            do
            {
                Console.WriteLine($"Введите Возраст человека: ");
                string readAge = Console.ReadLine();

                if (!int.TryParse(readAge, out age))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                    age = -1;
                    continue;
                }

                // Проверяем, если возраст отрицательный
                if (age < Person.AgeMin || age >= Person.AgeMax)
                {
                    Console.WriteLine("Возраст не может быть отрицательным. Попробуйте еще раз.");
                }
            }
            while (age < Person.AgeMin || age >= Person.AgeMax);

            Gender gender = Gender.Female;
            do
            {
                Console.WriteLine("Введите пол: ");
                enteredGender = Console.ReadLine();

                if (!Person.SymbolControl(enteredGender))
                {
                    Console.WriteLine($"При вводе использовались недопустимые символы");
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
                        gender = Gender.Male;
                    }
                    else if (enteredGender == "Female")
                    {
                        gender = Gender.Female;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода!");
                        enteredGender = string.Empty;
                    }
                }
            }
            while (string.IsNullOrEmpty(enteredGender));

            return new Person(firstName, lastName, age, gender);
        }

        /// <summary>
        /// Обрабатывает слово (до корректного ввода).
        /// </summary>
        /// <param name="word">Введенное слово.</param>
        /// <returns>Обработанное слово.</returns>
        public static string VerificationWord(string word)
        {
            while (string.IsNullOrEmpty(word))
            {
                word = Console.ReadLine();

                if (!Person.SymbolControl(word))
                {
                    Console.WriteLine($"При вводе использовались недопустимые символы");
                    word = string.Empty;
                }
                else
                {
                    word = Person.CorrectionRegister(word);
                }
            }

            return word;
        }
    }
}
