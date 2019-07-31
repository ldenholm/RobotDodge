using System;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap = new Bitmap("Player", "Player.png");
    public double X { get; set; }
    public double Y { get; set; }
    public bool Quit { get; private set; }
    
    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }

    public Player(Window w)
    {
        X = (w.Width - Width) / 2;
        //Y = ((w.Height - _PlayerBitmap.Height) / 2);
        Y = (w.Height - Height) / 2;
        Quit = false;
    }

    public void Draw()
    {
        SplashKit.DrawBitmap(_PlayerBitmap, X, Y);
    }

    public void HandleInput()
    {
        const int SPEED = 5;

        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X -= SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X += SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

    public void StayOnWindow(Window limit)
    {
        const int GAP = 10;

        if (X < GAP)
        {
            X = GAP;
        }

        //creating local variable to store maximum right-side value of X.
        if (X + Width > limit.Width - GAP)
        {
            X = (limit.Width - GAP) - Width;
        }

        if ((X + Width) > limit.Width - GAP)
        {
            X = (limit.Width - GAP) - Width;
        }

        if (Y < GAP)
        {
            Y = GAP;
        }

        if ((Y + Height) > limit.Height - GAP)
        {
            Y = (limit.Height - GAP) - Height;
        }
    }

}