using Godot;
using System;
using System.Collections.Generic;

public class ContextMenu : PanelContainer
{
    private VBoxContainer ContextItems;

    public override void _Ready()
    {
        base._Ready();

        ContextItems = GetNode<VBoxContainer>("ContextItems");
    }

    internal void AddItems(List<string> items)
    {
        foreach (string item in items)
        {
            var newLabel = new Label();
            newLabel.Text = item;
            ContextItems.AddChild(newLabel);
        }
    }

    internal void ClearItems()
    {
        foreach (Node child in ContextItems.GetChildren())
        {
            ContextItems.RemoveChild(child);
        }
    }

    internal void SetItems(List<string> items)
    {
        ClearItems();
        AddItems(items);
    }

    internal static ContextMenu CreateContextMenu()
    {
        PackedScene contextMenuScene = GD.Load<PackedScene>("res://Scene/Control/Component/ContextMenu.tscn");

        ContextMenu result = (ContextMenu)contextMenuScene.Instance();

        return result;
    }
}
