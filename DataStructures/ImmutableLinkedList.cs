using System.Text;



using System.Collections.Generic;

namespace ImmutableSequenceLab.DataStructures;

public sealed record ImmutableLinkedList<T>(
    T? Value,
    ImmutableLinkedList<T>? Tail
)
{
    public static ImmutableLinkedList<T> Empty =
        new(default, null);

    public bool IsEmpty =>
        Tail == null;

    public ImmutableLinkedList<T> Push(T value)
    {
        return new ImmutableLinkedList<T>(value, this);
    }

    public int Count()
    {
        int count = 0;

        for (var list = this; !list.IsEmpty; list = list.Tail!)
        {
            count++;
        }

        return count;
    }

    public bool Contains(T value)
    {
        for (var list = this; !list.IsEmpty; list = list.Tail!)
        {
            if (EqualityComparer<T>.Default.Equals(list.Value, value))
            {
                return true;
            }
        }

        return false;
    }
    public ImmutableLinkedList<T> Reverse()
{
    var result = Empty;

    for (var list = this; !list.IsEmpty; list = list.Tail!)
    {
        result = result.Push(list.Value!);
    }

    return result;
}
public string ToNaiveString()
{
    var s = "";

    for (var list = this; !list.IsEmpty; list = list.Tail!)
    {
        s += list.Value + " ";
    }

    return s;
}public string ToBuilderString()
{
    var builder = new StringBuilder();

    for (var list = this; !list.IsEmpty; list = list.Tail!)
    {
        builder.Append(list.Value);
        builder.Append(" ");
    }

    return builder.ToString();
}}