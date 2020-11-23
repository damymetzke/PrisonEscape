internal interface IPlayerIntentHandler<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="intent"></param>
    /// <returns>
    ///     <c>true</c>: intent has been consumed, no further intent handling required.
    ///     <c>false</c>: intent has not been consumed, intent handling will fall througn to next handler.
    /// </returns>
    bool ResolveIntent(PlayerIntent<T> intent);
}