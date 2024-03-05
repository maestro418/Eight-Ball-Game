using System;

public class Sender
{
    public string Action<string> onDataSent;

    public void SendData(string data)
    {
        onDataSent?.Invoke(data);
    }
}