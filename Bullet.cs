using SplashKitSDK;
public class Bullet
{
    private Bitmap _bulletBitmap;
    private double _x, _y, _angle;
    private bool _active = false;

    // Constructor
    public Bullet(double x, double y, double angle)
    {
        _bulletBitmap = SplashKit.LoadBitmap("bullet", "bullet.png");
        // set x and y to middle of the bitmap (hence the /2 to find centrepoint)
        _x = x - _bulletBitmap.Width / 2;
        _y = y - _bulletBitmap.Height / 2;
        _angle = angle;
        _active = true;        
    }

    public Bullet() 
    {
        _active = false;
    }

    public void Update()
    {
        // declare + init speed const.
        const int SPEED = 8;

        // Creating vector
        // vectors represent direction and distance and
        // 'can be visualised as an arrow from one point to another in 2 dimensional space'.
        Vector2D movement = new Vector2D();

        // Matrix:
        //You can translate, rotate and scale, and combine these together into a
        //single matrix that can then be applied to vectors and points.

        // Here rotation rotation is created and will rotate 2d points by _angle value.
        Matrix2D rotation = SplashKit.RotationMatrix(_angle);
        
        movement.X += SPEED;

        movement = SplashKit.MatrixMultiply(rotation, movement);

        _x += movement.X;
        _y += movement.Y;

        // conditions for bullet to become inactive = out of screen range.
        if (_x > SplashKit.ScreenWidth() || _x < 0 || _y > SplashKit.ScreenHeight() || _y < 0)
        {
            _active = false;
        }
    }
        public void Draw()
        {
            if (_active)
            {
                // rotating when drawing
                DrawingOptions opts = SplashKit.OptionRotateBmp(_angle);
                _bulletBitmap.Draw(_x, _y, opts);
            }
        }
        
}