using SplashKitSDK;
using System;

public class Program
{
    public static void Main()
    {
        // Initializing game window
        Window w = new Window("Robot Dodge", 600, 600);
        
        RobotDodge r = new RobotDodge(w);

        // Initializing timer
        r.scoreTimer.Start();

        while ((!w.CloseRequested && !r.Quit) && r.Alive > 0)
        {
            SplashKit.ProcessEvents();
            r.HandleInput();
            r.Update();
            r.Draw();
        }
    }
}
