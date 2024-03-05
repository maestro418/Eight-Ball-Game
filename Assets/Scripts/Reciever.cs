using System;

public class Reciever
{
    public string Action<string> onDataSent;

    public void SendData(string data)
    {
        onDataSent?.Invoke(data);
    }
}