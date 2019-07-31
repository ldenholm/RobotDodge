using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window w = new Window("Robot Dodge", 600, 600);
        //Player player = new Player(w);
        RobotDodge robo = new RobotDodge(w);

        while (!w.CloseRequested && !robo.Quit)
        {
            SplashKit.ProcessEvents();
            robo.HandleInput();
            robo.Update();
            robo.Draw();
            //w.Clear(Color.White);
            //player.Draw();
            //w.Refresh(60);
            //player.HandleInput();
            //player.StayOnWindow(w);
            //w.Refresh(60);
        }
        //SplashKit.Delay(5000);
    }
}
