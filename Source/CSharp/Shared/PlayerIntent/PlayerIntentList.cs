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
        for (int i = 0; i < size; ++i)
        {
            Handlers.Add(new NullIntent<T>());
        }
    }

    internal PlayerIntentList(List<IPlayerIntentHandler<T>> handlers)
    {
        Handlers = handlers;
    }

    internal PlayerIntentList(IEnumerable<T> handlers)
    {
        Handlers = (List<IPlayerIntentHandler<T>>)handlers;
    }

    public bool ResolveIntent(PlayerIntent<T> intent)
    {
        for (int i = 0; i < Handlers.Count; ++i)
        {
            if (Handlers[i].ResolveIntent(intent))
            {
                return true;
            }
        }

        return false;
    }
}