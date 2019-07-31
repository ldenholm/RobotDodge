using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window w = new Window("Robot Dodge", 600, 600);
        RobotDodge robo = new RobotDodge(w);

        while (!w.CloseRequested && !robo.Quit)
        {
            SplashKit.ProcessEvents();
            robo.HandleInput();
            robo.Update();
            robo.Draw();
            
        }
    }
}
