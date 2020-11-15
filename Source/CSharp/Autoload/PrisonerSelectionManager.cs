using Godot;
using System;
using System.Collections.Generic;

public class PrisonerSelectionManager : Node
{
    private List<Prisoner> Prisoners = new List<Prisoner>();

    public PrisonerSelectionManager()
    {

    }

    internal void RegisterPrisoner(Prisoner value)
    {
        Prisoners.Add(value);
    }

    internal void DeRegisterPrisoner(Prisoner value)
    {
        Prisoners.Remove(value);
    }
}
