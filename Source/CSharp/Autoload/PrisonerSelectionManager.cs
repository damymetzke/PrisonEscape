using Godot;
using System;
using System.Collections.Generic;

public class PrisonerSelectionManager : Node
{
    private List<Prisoner> Prisoners = new List<Prisoner>();
    private List<Prisoner> SelectedPrisoners = new List<Prisoner>();
    private List<Prisoner> HoveredPrisoners = new List<Prisoner>();

    public PrisonerSelectionManager()
    {

    }

    public override void _Process(float delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("select_prisoner"))
        {
            if (HoveredPrisoners.Count != 0)
            {
                SelectSinglePrisoner(HoveredPrisoners[0]);
            }
            else
            {
                DeselectAllprisoners();
            }
        }
    }

    internal void RegisterPrisoner(Prisoner value)
    {
        Prisoners.Add(value);
    }

    internal void DeRegisterPrisoner(Prisoner value)
    {
        Prisoners.Remove(value);
    }

    private void SelectSinglePrisoner(Prisoner value)
    {
        foreach (Prisoner prisoner in SelectedPrisoners)
        {
            if (prisoner == value)
            {
                continue;
            }
            prisoner.NotifyDeSelect();
        }
        SelectedPrisoners.Clear();

        if (SelectedPrisoners.Contains(value))
        {
            return;
        }

        value.NotifySelect();
        SelectedPrisoners.Add(value);
    }

    private void DeselectAllprisoners()
    {
        foreach (Prisoner prisoner in SelectedPrisoners)
        {
            prisoner.NotifyDeSelect();
        }
        SelectedPrisoners.Clear();
    }

    internal void PrisonerHoverStart(Prisoner value)
    {
        HoveredPrisoners.Add(value);
    }

    internal void PrisonerHoverEnd(Prisoner value)
    {
        HoveredPrisoners.Remove(value);
    }
}
