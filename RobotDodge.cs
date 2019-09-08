using System;
using SplashKitSDK;
using System.Collections.Generic;
public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private List<Robot> _Robots = new List<Robot>();
    private List<Bitmap> _Lives = new List<Bitmap>();

    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }

    public bool Alive
    {
        get { return _Lives.Count > 0; }
    }
    public RobotDodge(Window w)
    {
        _GameWindow = w;
        _Player = new Player(_GameWindow);
        // Calling the lives method which populates the _Lives list with bitmaps.
        createLives();
        DrawLives();
    }

    public void HandleInput()
    {
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
    }

    public void DrawLives()
    {
                // drawing the lives.
        SplashKit.DrawBitmap(_Lives[0], 10, 10);
        SplashKit.DrawBitmap(_Lives[1], 50, 10);
        SplashKit.DrawBitmap(_Lives[2], 90, 10);
        SplashKit.DrawBitmap(_Lives[3], 130, 10);
        SplashKit.DrawBitmap(_Lives[4], 170, 10);
    }

    public void Draw()
    {
        _GameWindow.Clear(Color.White);
        
        // foreach loop to draw all robots.
        foreach (Robot r in _Robots)
        {
            r.Draw();
        }

        _Player.Draw();
        _GameWindow.Refresh(60);
    }


//Tests if player collides with robot
    public void Update()
    {

        // Iterating through robots to update each object in list
        foreach (Robot r in _Robots)
        {
            r.Update();
        }
        
        // if statement which checks if robot list is empty, and if so creates a new robot.
        // uses Splashkit.Rnd(min, max) to generate number, if greater than 98 spawns new robot.
        if (SplashKit.Rnd(0, 100) > 98)
        {
            _Robots.Add(RandomRobot(_GameWindow, _Player));
        }

        CheckCollisions();

        /* if (_Player.CollidedWith(_Robots) || _TestRobot.isOffScreen(_GameWindow))
        {
            _TestRobot = RandomRobot(_GameWindow, _Player);
        }
        */
    }

    public Robot RandomRobot(Window w, Player p)
    {
        Robot r = new Robot(w, p);
        return r;
    }

    private void CheckCollisions()
    {
        // create new list of robots to be removed
        List<Robot> removeTheseRobots = new List<Robot>();

        // loop over main robots list
        foreach (Robot r in _Robots)
        {
            // check if player collided with or robot is off screen.
            if (_Player.CollidedWith(r) || r.isOffScreen(_GameWindow))
            {
                // add robot to removeRobotList
                removeTheseRobots.Add(r);                
            }

            // R E M O V I N G  L I V E S
            // if the player collides with a robot
            // remove one life from the list.
            for (var i = 0; i < _Lives.Count; i++)
            {
                if (_Player.CollidedWith(r))
                {
                    _Lives.RemoveAt(i);
                }
            }
        }

        // loop over new robots to be removed list:
        foreach (Robot r in removeTheseRobots)
        {
            // telling _Robots to remove the current robot
            _Robots.Remove(r);
        }
    }


    // This method creates the live bitmaps and adds them to the
    // _Lives field.
    public void createLives()
    {
        Bitmap hp1 = new Bitmap("hp1", "heart.png");
        Bitmap hp2 = new Bitmap("hp2", "heart.png");
        Bitmap hp3 = new Bitmap("hp3", "heart.png");
        Bitmap hp4 = new Bitmap("hp4", "heart.png");
        Bitmap hp5 = new Bitmap("hp5", "heart.png");

        _Lives.Add(hp1);
        _Lives.Add(hp2);
        _Lives.Add(hp3);
        _Lives.Add(hp4);
        _Lives.Add(hp5);
    }
}