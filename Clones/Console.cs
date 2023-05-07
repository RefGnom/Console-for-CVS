using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using System.Linq;

namespace Clones;

public static class CVSConsole
{
    private static string instruction = @"Поддерживаемые команды:

learn ci pi. Обучить клона с номером ci по программе pi.
rollback ci. Откатить последнюю программу у клона с номером ci.
relearn ci. Переусвоить последний откат у клона с номером ci.
clone ci. Клонировать клона с номером ci.
check ci. Получить программу, которой клон с номером ci владеет и при этом усвоил последней.";

    private static List<string> commands = new()
    {
        "learn",
        "rollback",
        "relearn",
        "clone",
        "check"
    };

    private static Dictionary<string, Action> actions = new()
    {
        ["cls"] = () =>
        {
            Console.Clear();
            Console.WriteLine(instruction);
        },
    };

    public static readonly CloneVersionSystem cvs;

    static CVSConsole()
    {
        cvs = new CloneVersionSystem();
    }

    public static void Start()
    {
        Console.WriteLine(instruction);
        while (true)
        {
            Console.Write("\n>>> ");
            var command = Console.ReadLine();
            Parse(command.Trim());
        }
    }

    private static void Parse(string command)
    {
        if (actions.ContainsKey(command))
        {
            actions[command]();
        }
        else if (TryParse(command))
        {
            var result = cvs.Execute(command);
            if (result != null)
                Console.WriteLine(result);
        }
        else
        {
            Console.Write($"\"{command}\" не является внутренней или внешней командой.\n");
        }
    }

    private static bool TryParse(string query)
    {
        var parse = query.Split();
        if (parse.Length < 2 || parse.Length > 3)
            return false;
        if (!commands.Contains(parse[0]))
            return false;
        if (parse.Length == 2)
            return int.TryParse(parse[1], out var cloneNumber);
        return int.TryParse(parse[2], out var programmNumber);
    }
}