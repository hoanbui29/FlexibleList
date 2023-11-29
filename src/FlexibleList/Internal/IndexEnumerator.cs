using System.Collections;

namespace FlexibleList.Internal;

public class IndexEnumerator<T> : IEnumerable<(T, int)>, IEnumerator<(T, int)>
{
    private int position = -1;
    private List<T> _internalList;

    public IndexEnumerator(List<T> list)
    {
        _internalList = list;
    }

    public IEnumerator<(T, int)> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        position++;
        return position < _internalList.Count;
    }

    public void Reset()
    {
        position = -1;
    }

    public (T, int) Current => (_internalList[position], position);

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        position = -1;
    }
}