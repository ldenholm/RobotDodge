/*using SplashKitSDK;
 
public class Bullet
{
    private Bitmap _bulletBitmap;
    private double _x, _y;
    //private double _locationX, _locationY;
    private bool _active = false;

    // Constructor
    public Bullet(double x, double y)
    {
        _bulletBitmap = SplashKit.LoadBitmap("bullet", "bullet.png");
        // set x and y to middle of the bitmap (hence the /2 to find centrepoint)
        _x = x - _bulletBitmap.Width / 2;
        _y = y - _bulletBitmap.Height / 2;
        //_locationX = locX;
        //_locationY = locY;
        _active = true;        
    }

    public Bullet() 
    {
        _active = false;
    }

    public void Update()
    {
        // declare + init speed const.
        //const int SPEED = 8;

       

        //_x += movement.X;
        //_y += movement.Y;

        // conditions for bullet to become inactive = out of screen range.
        if (_x > SplashKit.ScreenWidth() || _x < 0 || _y > SplashKit.ScreenHeight() || _y < 0)
        {
            _active = false;
        }
    }
        public void Draw()
        {
            //if (_active)
            //{
                // rotating when drawing
                //DrawingOptions opts = SplashKit.OptionRotateBmp(_angle);
                _bulletBitmap.Draw(_x, _y);
            //}
        }
        
}
*/