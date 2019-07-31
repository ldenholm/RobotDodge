using System;
using SplashKitSDK;

public class RobotDodge 
{
Player _Player;
Window _GameWindow;

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
    _Player.Draw();
    _GameWindow.Refresh(60);
}

public void Update()
{

}

}

