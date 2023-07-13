namespace Ui.SampleDesktopApp;

using System.Diagnostics;
using System.Drawing.Imaging;

using Logic.Core.Utils;
using Logic.Shared.Factories;
using Logic.Shared.Models;

using Timer = System.Windows.Forms.Timer;

public partial class MainWindows : Form
{
    #region member vars

    private readonly HashSet<DisplayModel> _displays;
    private readonly Timer _timer1 = new();
    private int _selectedMonitor = -1;

    #endregion

    #region constructors and destructors

    public MainWindows()
    {
        InitializeComponent();


        //get all displays and add them to the combobox
        _displays = DisplayFactory.Instance().GetAllDisplays().ToHashSet();
        foreach (var display in _displays)
        {
            cbx_displays.Items.Add($@"Name: {display.Name} - Primary: {display.IsPrimary}");
        }
    }

    #endregion

    #region methods

    private void btn_off_Click(object sender, EventArgs e)
    {
        if (_selectedMonitor < 0)
        {
            return;
        }
        // get the display of a selected monitor in the combobox
        var display = _displays.FirstOrDefault(x => x.Id.Equals(_selectedMonitor));
        if (display != null)
        {
            // try to turn the display off
            DisplayFactory.Instance().TurnOff(display);
        }
    }

    private void btn_on_Click(object sender, EventArgs e)
    {
        if (_selectedMonitor < 0)
        {
            return;
        }
        // get the display of a selected monitor in the combobox
        var display = _displays.FirstOrDefault(x => x.Id.Equals(_selectedMonitor));
        if (display != null)
        {
            // try to turn the monitor on.
            DisplayFactory.Instance().TurnOn(display);
        }
    }

    private void cbx_displays_SelectedIndexChanged(object sender, EventArgs e)
    {
        _selectedMonitor = cbx_displays.SelectedIndex;
        _timer1.Interval = 500;
        _timer1.Tick += TimerTick;
        _timer1.Start();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        try
        {
            Graphics captureGraphics = null;
            if (captureGraphics == null)
            {
                //Creating a new Bitmap object
                if (Screen.AllScreens.Any() && _selectedMonitor < Screen.AllScreens.Length)
                {
                    if (Screen.AllScreens.GetValue(_selectedMonitor) != null)
                    {
                        var devMode = Utility.GetDevMode(Screen.AllScreens[_selectedMonitor].DeviceName);
                        var captureBitmap = new Bitmap(devMode.dmPelsWidth, devMode.dmPelsHeight, PixelFormat.Format24bppRgb);
                        var captureRectangle = new Rectangle(devMode.dmPositionX, devMode.dmPositionY, devMode.dmPelsWidth, devMode.dmPelsHeight);
                        captureGraphics = Graphics.FromImage(captureBitmap);
                        if (captureRectangle is { IsEmpty: false })
                        {
                            //Copying Image from The Screen
                            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                            picBox_preview.Image = captureBitmap;
                        }
                        captureBitmap = null;
                    }
                }
                else if (_selectedMonitor >= Screen.AllScreens.Length)
                {
                    picBox_preview.BackColor = Color.Black;
                    picBox_preview.Image = null;
                }


            }
            captureGraphics = null;
        }
        catch (Exception exception)
        {
            Trace.WriteLine(exception);
        }
    }

    #endregion
}