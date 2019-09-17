using SplashKitSDK;
using System;
using System.Collections.Generic;

public class RobotDodge
{
    private Player _Player;
    private Window _GameWindow;
    private List<Robot> _Robots = new List<Robot>();
    
    // Loading Roboto font. 
    private Font roboto = SplashKit.LoadFont("Roboto", "Roboto-Black.ttf");

    // Creating timer for scoring
    public Timer scoreTimer = new Timer("Score Timer");

    // create bullet object.
    public Bullet b = new Bullet();
    public int Alive
    {
        get
        {
            return _Player.lives;
        }
    }

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
        _Player = new Player(_GameWindow);
        
        
        
    }

    public void HandleInput()
    {
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
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
        _Player.DrawLives();

        SplashKit.DrawTextOnWindow(_GameWindow, "Score: " + Convert.ToString(scoreTimer.Ticks / 1000), Color.Black, roboto, 18, 500, 10);

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
        float whichBot = SplashKit.Rnd();
        if (whichBot > 0.7)
        {
            Roundy r = new Roundy(w, p);
            return r;
        }
        else if (whichBot < 0.4)
        {
            Boxy b = new Boxy(w, p);
            return b;
        }
        else
        {
            Flippy f = new Flippy(w, p);
            return f;
        }    
        
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
            if (_Player.CollidedWith(r))
            {
                _Player.lives--;
            }
        }

        // loop over new robots to be removed list:
        foreach (Robot r in removeTheseRobots)
        {
            // telling _Robots to remove the current robot
            _Robots.Remove(r);
        }
    }
}