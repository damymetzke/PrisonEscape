using Godot;
using System;

public class Gym : Node2D
{
    private PrisonerSelectionManager PrisonerSelectionManager;

    public override void _Ready()
    {
        base._Ready();

        PrisonerSelectionManager = GetNode<PrisonerSelectionManager>("/root/PrisonerSelectionManager");

        PrisonerSelectionManager.RegisterLevelRoot(this);
    }
}
