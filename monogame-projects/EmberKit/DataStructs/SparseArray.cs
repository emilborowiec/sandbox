using System;
using System.Collections.Generic;

namespace EmberKit.DataStructs;

public class SparseArray<T>
{
    private readonly T[] _array;
    private readonly Queue<int> _freeIndexQueue;

    public SparseArray(int capacity)
    {
        _array = new T[capacity];
        _freeIndexQueue = new Queue<int>(capacity);
        for (var i = 0; i < capacity; i++) _freeIndexQueue.Enqueue(i);
    }

    public T[] Elements => _array;
    public int Capacity => _array.Length;

    public int AddElement(T element)
    {
        var index = _freeIndexQueue.Dequeue();
        _array[index] = element;
        return index;
    }

    public int RemoveElement(T element)
    {
        var index = Array.IndexOf(_array, element);
        _array[index] = default;
        _freeIndexQueue.Enqueue(index);
        return index;
    }

    public void Clear()
    {
        Array.Fill(_array, default);
    }
}