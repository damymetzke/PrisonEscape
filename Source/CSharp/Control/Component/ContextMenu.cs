using Godot;
using System;
using System.Collections.Generic;

public class ContextMenu : PanelContainer, IPlayerIntentHandler<GameplayIntent>
{
    internal struct Item
    {
        internal string Title;
        internal Action OnClick;

        internal Item(string title, Action onClick)
        {
            Title = title;
            OnClick = onClick;
        }
    }

    private List<Action> Callbacks = new List<Action>();

    private VBoxContainer ContextItems;

    private int HoveredItem = -1;

    public override void _Ready()
    {
        base._Ready();

        ContextItems = GetNode<VBoxContainer>("ContextItems");
    }

    internal void AddItems(List<Item> items)
    {
        foreach (Item item in items)
        {
            var newLabel = new Label();
            newLabel.Text = item.Title;

            newLabel.MouseFilter = MouseFilterEnum.Stop;

            ContextItems.AddChild(newLabel);

            Godot.Collections.Array bindArray = new Godot.Collections.Array { Callbacks.Count };

            newLabel.Connect(
                "mouse_entered",
                this,
                "OnItemHoverStart",
                bindArray
                );
            newLabel.Connect(
                "mouse_exited",
                this,
                "OnItemHoverEnd",
                bindArray
                );

            Callbacks.Add(item.OnClick);
        }
    }

    internal void ClearItems()
    {
        foreach (Node child in ContextItems.GetChildren())
        {
            ContextItems.RemoveChild(child);
        }

        Callbacks.Clear();
        HoveredItem = -1;
    }

    internal void SetItems(List<Item> items)
    {
        ClearItems();
        AddItems(items);
    }

    internal bool HandleInput()
    {
        if (HoveredItem == -1)
        {
            return false;
        }

        Callbacks[HoveredItem]();

        return true;
    }

    public bool ResolveIntent(PlayerIntent<GameplayIntent> intent)
    {
        if (intent.Action != GameplayIntent.PrimaryAction || HoveredItem == -1)
        {
            return false;
        }

        Callbacks[HoveredItem]();

        return true;
    }

    internal static ContextMenu CreateContextMenu()
    {
        PackedScene contextMenuScene = GD.Load<PackedScene>("res://Scene/Control/Component/ContextMenu.tscn");

        ContextMenu result = (ContextMenu)contextMenuScene.Instance();

        return result;
    }

    private void OnItemHoverStart(int index)
    {
        HoveredItem = index;
    }

    private void OnItemHoverEnd(int index)
    {
        if (HoveredItem == index)
        {
            HoveredItem = -1;
        }
    }
}
