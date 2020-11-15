using Godot;
using System;
using System.Collections.Generic;

public class PrisonerSelectionManager : Node
{
    private List<Prisoner> Prisoners = new List<Prisoner>();
    private List<Prisoner> SelectedPrisoners = new List<Prisoner>();

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

    internal void SelectSinglePrisoner(Prisoner value)
    {
        foreach (Prisoner prisoner in SelectedPrisoners)
        {
            if (prisoner == value)
            {
                continue;
            }
            // TODO: notify prisoner it has been deselected.
        }
        SelectedPrisoners.Clear();

        if (SelectedPrisoners.Contains(value))
        {
            return;
        }

        // TODO: notify prisoner it has been seleced.
        SelectedPrisoners.Add(value);
    }
}
