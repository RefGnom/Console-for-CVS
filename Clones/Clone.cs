namespace Clones;

public class Clone
{
    private readonly Stack<int> programms;
    private readonly Stack<int> rollbacks;

    public Clone()
    {
        programms = new Stack<int>();
        rollbacks = new Stack<int>();
    }

    Clone(Stack<int> programms, Stack<int> rollbacks)
    {
        this.programms = programms;
        this.rollbacks = rollbacks;
    }

    public void AddProgramm(int programm)
    {
        programms.Push(programm);
    }

    public void Rollback()
    {
        if (programms.Count != 0)
        {
            rollbacks.Push(programms.Pop());
        }
    }

    public void Relearn()
    {
        if (rollbacks.Count != 0)
        {
            programms.Push(rollbacks.Pop());
        }
    }

    public Clone Copy()
    {
        return new Clone(programms.Copy(), rollbacks.Copy());
    }

    public string GetLastProgramm()
    {
        if (programms.Count == 0)
            return "basic";
        else
            return programms.Peek().ToString();
    }
}