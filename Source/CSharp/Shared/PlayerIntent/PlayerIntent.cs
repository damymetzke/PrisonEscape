using System.Collections.Generic;

public struct PlayerIntent<T>
{
    internal enum ActionType
    {
        Pressed,
        Released
    }

    internal readonly T Action;
    internal readonly ActionType Type;
    internal readonly Dictionary<T, bool> PressedKeys;

    internal PlayerIntent(T action, ActionType type, Dictionary<T, bool> pressedKeys)
    {
        Action = action;
        Type = type;
        PressedKeys = pressedKeys;
    }
}