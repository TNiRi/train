using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Комнаты
        Location hall = new Location("Холл", "Тёмный холл. Видны две таблички: 'откройся' и 'наружу'.");
        Location secret = new Location("Тайник", "Секретная комната с сундуком.");
        Location exit = new Location("Выход", "Ты спасся! Игра пройдена.");

        // 2. Переходы
        hall.AddExit("откройся", secret);
        hall.AddExit("наружу", exit);
        secret.AddExit("назад", hall);

        // 3. Состояние игры
        GameState state = new GameState(hall);

        // 4. Простейший ввод
        Console.WriteLine("=== ТЕСТ КОДОВЫХ ПЕРЕХОДОВ ===");
        Console.WriteLine(hall.Description);
        Console.WriteLine("Команда: go <слово>");

        while (true)
        {
            Console.Write("\n> ");
            string input = Console.ReadLine();
            if (input == "exit") break;

            if (input.StartsWith("go "))
            {
                string word = input.Substring(3);
                GoCommand go = new GoCommand(word);
                go.Execute(state);
            }
            else
            {
                Console.WriteLine("Пока работает только 'go <слово>'");
            }
        }
    }
}