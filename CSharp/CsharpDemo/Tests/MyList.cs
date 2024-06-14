namespace MyList;

public class MyList<T>
{
    /*
    字段
    */
    const int DefaultCapacity = 4;
    T[] _items; // 底层数组
    int _count; // 当前列表元素个数

    /*
    事件。
    声明方式是：event 委托类型
    */
    public event EventHandler Changed; // 事件回调函数（可能有多个）

    /*
    属性
    */
    public int Count => _count;

    // 查看和调整底层数组的长度
    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _count) value = _count;
            if (value != _items.Length)
            {
                T[] newItems = new T[value];
                Array.Copy(_items, 0, newItems, 0, _count);
                _items = newItems;
            }
        }
    }

    // 带默认值参数的构造方法
    public MyList(int capacity = DefaultCapacity)
    {
        _items = new T[capacity];
    }

    // 索引器。通过[]语法查询和修改列表指定下标的元素
    public T this[int index]
    {
        get => _items[index];
        set
        {
            _items[index] = value;
            OnChanged();
        }
    }

    // 添加新的元素
    public void Add(T item)
    {
        if (_count == Capacity) Capacity = _count * 2;
        _items[_count] = item;
        _count++;
        OnChanged();
    }

    // 触发回调函数
    protected virtual void OnChanged() =>
        Changed?.Invoke(this, EventArgs.Empty);

    // 重写Equals方法
    public override bool Equals(object other) =>
        Equals(this, other);

    static bool Equals(MyList<T> a, MyList<T> b)
    {
        if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
        if (Object.ReferenceEquals(b, null) || a._count != b._count)
            return false;
        for (int i = 0; i < a._count; i++)
        {
            if (!object.Equals(a._items[i], b._items[i]))
                return false;
        }
        return true;
    }

    // 定义==和!=操作
    public static bool operator ==(MyList<T> a, MyList<T> b) =>
        Equals(a, b);
    
    public static bool operator !=(MyList<T> a, MyList<T> b) =>
        !Equals(a, b);
}