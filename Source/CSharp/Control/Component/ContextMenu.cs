using Godot;
using System;
using System.Collections.Generic;

public class ContextMenu : PanelContainer
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

    private VBoxContainer ContextItems;

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

    internal void SetItems(List<Item> items)
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
