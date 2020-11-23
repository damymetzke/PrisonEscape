using System.Collections.Generic;

internal class PlayerIntentList<T> : IPlayerIntentHandler<T>
{
    private List<IPlayerIntentHandler<T>> Handlers;

    internal IPlayerIntentHandler<T> this[int index]
    {
        get => Handlers[index];
        set => Handlers[index] = value;
    }

    internal PlayerIntentList()
    {
        Handlers = new List<IPlayerIntentHandler<T>>();
    }

    internal PlayerIntentList(int size)
    {
        Handlers = new List<IPlayerIntentHandler<T>>(size);
    }

    internal PlayerIntentList(List<IPlayerIntentHandler<T>> handlers)
    {
        Handlers = handlers;
    }

    internal PlayerIntentList(IEnumerable<T> handlers)
    {
        Handlers = (List<IPlayerIntentHandler<T>>)handlers;
    }

    public bool HandleIntent(PlayerIntent<T> intent)
    {
        for (int i = 0; i < Handlers.Count; ++i)
        {
            if (Handlers[i].HandleIntent(intent))
            {
                return true;
            }
        }

        return false;
    }
}