using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregnancyCommand : ICommand
{

    //private SnakePartComponent grandparent;
    private SnakePartComponent parent;
    private SnakePartComponent child;
    private Vector3 position;
    private bool setPregnant;

    public PregnancyCommand(SnakePartComponent parent, Vector3 position, bool setPregnant)
    {
        this.parent = parent;
        this.position = position;
        this.setPregnant =  setPregnant;
    }
    
    protected override void Execute()
    {
        Debug.Log("Execute pregnancy");
        if (setPregnant)
        {
            parent.isPregnant = true;
            if (parent.childPart == null)
            {
                var commandEvent = new CommandEvent(new BirthCommand(parent, position), 1);
                EgoEvents<CommandEvent>.AddEvent(commandEvent);
                var commandEvent2 = new CommandEvent(new PregnancyCommand(parent, position, false), 1);
                EgoEvents<CommandEvent>.AddEvent(commandEvent2);
            }
            else
            {
                if (!parent.childPart.isPregnant)
                {
                    var commandEvent = new CommandEvent(new PregnancyCommand(parent.childPart, position, true), 1);
                    EgoEvents<CommandEvent>.AddEvent(commandEvent);
                    var commandEvent2 = new CommandEvent(new PregnancyCommand(parent, position, false), 1);
                    EgoEvents<CommandEvent>.AddEvent(commandEvent2);
                }
            }
        }
        else
        {
            parent.isPregnant = false;
        }
    }

    protected override void Undo()
    {
        Debug.Log("undo pregnancy");
        parent.isPregnant = !setPregnant;
    }

    protected override bool IsExecuteValid()
    {
        return (parent != null);
    }
    protected override bool IsUndoValid()
    {
        return (parent != null);
    }
}
