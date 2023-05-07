using System;
using System.Collections.Generic;

namespace Clones;

public class CloneVersionSystem : ICloneVersionSystem
{
    private readonly List<Clone> clones;

    public CloneVersionSystem()
    {
        clones = new List<Clone>() { new Clone() };
    }

    public string Execute(string query)
    {
        var parse = query.Split();
        var command = parse[0];
        var cloneNumber = int.Parse(parse[1]);
        var programmNumber = 0;
        if (command == "learn")
        {
            if (parse.Length == 3)
                programmNumber = int.Parse(parse[2]);
            else
                throw new ArgumentException("Command \"learn\" must have two arguments");
        }
        return ChoiceCommand(command, cloneNumber, programmNumber);
    }

    public string ChoiceCommand(string command, int cloneNumber, int programmNumber)
    {
        switch (command)
        {
            case "learn":
                clones[cloneNumber - 1].AddProgramm(programmNumber);
                break;
            case "rollback":
                clones[cloneNumber - 1].Rollback();
                break;
            case "relearn":
                clones[cloneNumber - 1].Relearn();
                break;
            case "clone":
                clones.Add(clones[cloneNumber - 1].Copy());
                break;
            case "check":
                return clones[cloneNumber - 1].GetLastProgramm();
        }
        return null;
    }
}