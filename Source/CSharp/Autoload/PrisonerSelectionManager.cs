using Godot;
using System;
using System.Collections.Generic;

public class PrisonerSelectionManager : Node
{
    private Node2D LevelRoot;
    private Node2D ContextMenuPosition;
    private ContextMenu ContextMenu;

    private List<Prisoner> Prisoners = new List<Prisoner>();
    private List<Prisoner> SelectedPrisoners = new List<Prisoner>();
    private List<Prisoner> HoveredPrisoners = new List<Prisoner>();

    public PrisonerSelectionManager()
    {
    }

    public override void _Ready()
    {
        base._Ready();

        ContextMenuPosition = new Node2D();
        ContextMenu = ContextMenu.CreateContextMenu();
        ContextMenu.Visible = false;
        ContextMenuPosition.AddChild(ContextMenu);

        if (LevelRoot != null)
        {
            LevelRoot.AddChild(ContextMenuPosition);
        }

    }

    public override void _Process(float delta)
    {
        base._Process(delta);

        if (Input.IsActionJustPressed("select_prisoner"))
        {
            if (Input.IsActionPressed("select_multiple_prisoners"))
            {
                SelectAdditionalPrisoners(HoveredPrisoners);
            }
            else
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

            ContextMenu.Visible = false;
        }

        if (Input.IsActionJustPressed("open_context_menu"))
        {
            ContextMenu.Visible = true;
            ContextMenuPosition.Position = LevelRoot.GetGlobalMousePosition();
            ContextMenu.SetItems(new List<string> { "aaa", "bbb", "ccc" });
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

    internal void RegisterLevelRoot(Node2D value)
    {
        LevelRoot = value;

        if (ContextMenuPosition != null)
        {
            LevelRoot.AddChild(ContextMenuPosition);
        }
    }

    private void SelectAdditionalPrisoners(List<Prisoner> value)
    {
        foreach (Prisoner prisoner in value)
        {
            if (SelectedPrisoners.Contains(prisoner))
            {
                continue;
            }

            SelectedPrisoners.Add(prisoner);
            prisoner.NotifySelect();
        }
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
