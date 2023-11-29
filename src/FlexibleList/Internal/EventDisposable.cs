using FlexibleList.Public;

namespace FlexibleList.Internal;

public class EventDisposable<T> : IDisposable
{
    private readonly FlexibleList<T> _parent;
    private readonly Action<T> _action;

    public EventDisposable(FlexibleList<T> parent, Action<T> action)
    {
        _parent = parent;
        _action = action;
    }


    public void Dispose()
    {
        _parent.OnAddCallBack -= _action;
    }
}