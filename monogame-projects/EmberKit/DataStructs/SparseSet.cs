using System;
using System.Collections.Generic;

namespace EmberKit.DataStructs;

public class SparseSet<T> where T : struct
{
    private T[] _dense;
    private Dictionary<int, int> _sparse;
    private int _maxItems;
    private int _capacity;
    private int _count;
        
    public SparseSet(int capacity)
    {
        _dense = new T[capacity];
        _sparse = new Dictionary<int, int>(capacity);
        _capacity = capacity;
        _count = 0;
    }

    public int Add(T item)
    {
        var newId = _count;
        Add(newId, item);
        return newId;
    }
        
    public void Add(int id, T item)
    {
        if (_count >= _capacity) throw new IndexOutOfRangeException("SparseSet at full capacity");

        _dense[_count] = item;
        _sparse[id] = _count;
        _count++;
    }

    public int IndexOf(int id)
    {
        return _sparse[id];
    }
        
    public void Set(int id, T item)
    {
        _dense[_sparse[id]] = item;
    }

    public T Get(int id)
    {
        return _dense[_sparse[id]];
    }

    public void Remove(int id)
    {
        if (_count == 0) return;
        if (!_sparse.ContainsKey(id)) return; 
        var index = _sparse[id];
        var swapIndex = _count - 1;
        var temp = _dense[swapIndex];
        for (var i = 0; i < _sparse.Count; i++)
        {
            if (_sparse[i] == swapIndex)
            {
                _sparse[i] = i;
            }
        }
        _dense[index] = temp;
        _count--;
    }

    public void Clear()
    {
        _count = 0;
    }

    public int Count => _count;
    public T[] Items => _dense;
}