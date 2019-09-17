using SplashKitSDK;
using System;
public abstract class Robot
{
    public double X { get; set; }
    public double Y { get; set; }
    public Color MainColor { get; set; } 
    private Vector2D Velocity { get; set; }

    public int Width
    {
        get { return 50; }
    }

    public int Height
    {
        get { return 50; }
    }

//public property returns a circle at using geometry docs was able to
//clarify how to do this. Note the task sheet is misleading for properties and
//fields in this task as it contradicts itself by interchanging public/private access
//modifiers. Same goes for the Vector2D property, in the task notes it details a public
//property in the UML, however in the code snipped it says private... I have gone with
// private...
    public Circle CollisionCircle
    {
         get { return SplashKit.CircleAt(X, Y, 20); }
    }

    public Robot(Window gameWindow, Player player)
    {

        // Random pick top / bot / left / right
        if (SplashKit.Rnd() < 0.5)
        {
            //we have picked Top / Bottom

            // pick a random position left to right (X)
            X = SplashKit.Rnd(gameWindow.Width);

            // Determine if we are at top or bottom.
            if (SplashKit.Rnd() < 0.5)
            {
                Y = -Height;
            } else
            {
                Y = gameWindow.Height;
            }
         } else 
         {
             // We have picked Left / Right
                // pick a random position top to bottom (y)
            Y = SplashKit.Rnd(gameWindow.Height);
            if (SplashKit.Rnd() < 0.5)
            {
                X = -Width; // left
            } else
            {
                X = gameWindow.Width; // right
            }
         }


        const int SPEED = 4;

        //Get a point for the robot
        Point2D fromPt = new Point2D()
        {
            X = X, Y = Y
        };

        //Get a point for the player
        Point2D toPt = new Point2D()
        {
            X = player.X, Y = player.Y
        };

        // Calculate the direction to move to.
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        // Set speed + assign to the velocity
        Velocity = SplashKit.VectorMultiply(dir, SPEED);
        // Generate a rnd colour:
        MainColor = Color.RandomRGB(200);
    }

    public abstract void Draw();

    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    public bool isOffScreen(Window screen)
    {
        // returns true or false for result of any of the following statements. 
        return (X < -Width) || (X > screen.Width) || (Y < -Height) || (Y > screen.Height);
    }
}

public class Boxy : Robot
{
    public Boxy(Window w, Player p) : base (w, p)
    {
        
    }
    public override void Draw()
    {
        double leftX, rightX;
        double eyeY, mouthY;

        leftX = X + 12;
        rightX = X + 27;
        eyeY = Y + 10;
        mouthY = Y + 30;

        SplashKit.FillRectangle(Color.Gray, X, Y, 50, 50);
        SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);
    }
}

public class Roundy : Robot
{
    public Roundy(Window w, Player p) : base (w, p)
    {
        
    }

    public override void Draw()
        {
            double leftX, midX, rightX;
            double midY, eyeY, mouthY;

            leftX = X + 17;
            midX = X + 25;
            rightX = X + 33;

            midY = Y + 25;
            eyeY = Y + 20;
            mouthY = Y + 35;

            SplashKit.FillCircle(Color.White, midX, midY, 25);
            SplashKit.DrawCircle(Color.Gray, midX, midY, 25);
            SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
            SplashKit.FillCircle(Color.White, rightX, eyeY, 5);
            SplashKit.FillEllipse(Color.Gray, X, eyeY, 50, 30);
            SplashKit.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
        }
}

public class Flippy : Robot
{
    public Flippy(Window w, Player p) : base (w, p)
    {
        
    }
    public override void Draw()
        {
            double leftX, midX, rightX;
            double midY, eyeY, mouthY;

            leftX = X + 17;
            midX = X + 25;
            rightX = X + 33;

            midY = Y + 25;
            eyeY = Y + 20;
            mouthY = Y + 35;

            SplashKit.FillCircle(Color.White, midX, midY, 15);
            SplashKit.DrawCircle(Color.Gray, midX, midY, 5);
            SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
            SplashKit.FillCircle(Color.White, rightX, eyeY, 5);
            SplashKit.FillEllipse(Color.Gray, X, eyeY, 10, 5);
            SplashKit.DrawLine(Color.Black, X, mouthY, X + 15, Y + 15);
        }
}