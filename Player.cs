using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap = new Bitmap("Player", "Player.png");
    public double X { get; private set; }
    public double Y { get; private set; }
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
        
    }

}