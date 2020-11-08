using System.Collections;
using System.Collections.Generic;

public class NavigationList<T> : List<T>
{
    private int _currentIndex = 0;

    public NavigationList(IEnumerable<T> collection) : base(collection)
    {
    }

    public T Current => this[_currentIndex];

    public T FindIndex(int index)
    {
        _currentIndex = index;
        return this[_currentIndex];
    }

    public T MoveNext()
    {
        _currentIndex = _currentIndex == Count - 1 ? 0 : _currentIndex + 1;
        return this[_currentIndex];
    }

    public T MovePrevious()
    {
        _currentIndex = _currentIndex == 0 ? Count - 1 : _currentIndex - 1;
        return this[_currentIndex];
    }
}
