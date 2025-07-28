using System;
using WebSocketSharp;
using WebSocketSharp.Server;

public class Laputa : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        var msg = e.Data == "BALUS"
        ? "I've been balused already..."
        : "I'm not available now.";

        Send(msg);
    }
}