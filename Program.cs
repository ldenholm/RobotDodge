using SplashKitSDK;
using System;

public class Program
{
    public static void Main()
    {
        Window w = new Window("Robot Dodge", 600, 600);
        //Player player = new Player(w);
        RobotDodge r = new RobotDodge(w);

        while ((!w.CloseRequested && !r.Quit) && r.Alive > 0)
        {
            SplashKit.ProcessEvents();
            r.HandleInput();
            r.Update();
            r.Draw();
        }
        //SplashKit.Delay(5000);
    }
}
