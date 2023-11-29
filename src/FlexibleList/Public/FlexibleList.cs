using System.Collections;
using FlexibleList.Internal;

namespace FlexibleList.Public;

public class FlexibleList<T> : IEnumerable<T>
{
    private readonly List<T> _list = new();

    //NOTE: event keyword is used to prevent invoking the event outside of this class
    public event Action<T>? OnAddCallBack;
    public event Action<T>? OnRemoveCallBack;

    public T this[int idx] => _list[idx];

    public void Add(T item)
    {
        _list.Add(item);
        OnAddCallBack?.Invoke(item);
    }

    public void Remove(T item)
    {
        _list.Remove(item);
        OnRemoveCallBack?.Invoke(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<(T, int)> GetIndexEnumerator()
    {
        return new IndexEnumerator<T>(_list);
    }

    public IDisposable OnAdd(Action<T> callBack)
    {
        OnAddCallBack += callBack;
        return new EventDisposable<T>(this, callBack);
    }

    public IDisposable OnRemove(Action<T> callBack)
    {
        OnRemoveCallBack += callBack;
        return new EventDisposable<T>(this, callBack);
    }
}