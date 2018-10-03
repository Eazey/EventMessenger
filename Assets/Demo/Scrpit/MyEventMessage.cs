using EazeyFramework;

public class MyEventMessage : EventMessage
{
    public MyEventMessage(ID id,
        string title, string data, int size)
        : base(id)
    {
        EventID = id;

        Title = title;
        Data = data;
        Size = size;
    }

    public readonly string Title;
    public readonly string Data;
    public readonly int Size;
}
