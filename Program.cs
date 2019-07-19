using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window w = new Window("Robot Dodge", 600, 600);
        Player player = new Player(w);

        while (!w.CloseRequested)
        {
            SplashKit.ProcessEvents();
            w.Clear(Color.White);
            player.Draw();
            w.Refresh(60);
        }
        //SplashKit.Delay(5000);
    }
}
