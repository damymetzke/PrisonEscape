using Godot;
using System;

public class Prisoner : KinematicBody2D
{
    private PrisonerSelectionManager prisonerSelectionManager;

    private bool _initialized = false;
    private bool _registered = false;

    public override void _Ready()
    {
        base._Ready();

        prisonerSelectionManager = GetNode<PrisonerSelectionManager>("/root/PrisonerSelectionManager");

        prisonerSelectionManager.RegisterPrisoner(this);

        _initialized = true;
        _registered = true;
    }

    public override void _EnterTree()
    {
        base._EnterTree();

        if (_registered)
        {
            GD.PrintErr("Prisoner which is already registered, but just entered tree!");
        }

        if (!_initialized)
        {
            return;
        }

        prisonerSelectionManager.RegisterPrisoner(this);
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        if (!_registered)
        {
            return;
        }

        prisonerSelectionManager.DeRegisterPrisoner(this);

        _registered = false;
    }

    private void OnClickAreaMouseEnter()
    {
        GD.Print("Mouse Enter");
    }

    private void OnClickAreaMouseExit()
    {
        GD.Print("Mouse Exit");
    }
}
