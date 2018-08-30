using EazeyFramework;

public class MyEventMessage : EventMessage
{
    public MyEventMessage(ID id)
        : base(id)
    {
        EventID = id;
    }

    public string Title;
    public string Data;
    public int Size;
}
