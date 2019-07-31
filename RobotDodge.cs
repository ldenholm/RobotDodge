using System;
using SplashKitSDK;

public class RobotDodge 
{
Player _Player;
Window _GameWindow;

Robot _TestRobot;

public bool Quit 
{
    get
    {
        return _Player.Quit;
    }
}

public RobotDodge(Window w)
{
    _GameWindow = w;
    _TestRobot = RandomRobot(_GameWindow);
    Player p = new Player(_GameWindow);

    _Player = p;
}

public void HandleInput()
{
    _Player.HandleInput();
    _Player.StayOnWindow(_GameWindow);
}

public void Draw()
{
    _GameWindow.Clear(Color.White);
    _TestRobot.Draw();
    _Player.Draw();
    _GameWindow.Refresh(60);
}

public void Update()
{

}

public Robot RandomRobot(Window w)
{
    _GameWindow = w;
    Robot r = new Robot(_GameWindow);
    return r;
}

}

