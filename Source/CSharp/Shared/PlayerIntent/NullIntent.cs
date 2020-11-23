internal class NullIntent<T>: IPlayerIntentHandler<T>
{
    public bool ResolveIntent(PlayerIntent<T> intent)
    {
        return false;
    }
}