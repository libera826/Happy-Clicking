/* 
 *  author: craighan - (HanKwanYeop)
 */


using System.Windows;
using DesktopWPFAppLowLevelKeyboardHook;
using System.Media;

namespace Happy_Clicking
{
    public partial class MainWindow : Window
    {
        private LowLevelKeyboardListener _listener;

        public MainWindow()
        {
            InitializeComponent();
            titleBar.MouseLeftButtonDown += (o, e) => DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += KeyPressed;

            _listener.HookKeyboard();
        }

        void KeyPressed(object sender, KeyPressedArgs e)
        {
            SoundPlayer ReturnSound = new SoundPlayer(Happy_Clicking.Properties.Resources.CherryBlueReturn);
            SoundPlayer SpaceSound = new SoundPlayer(Happy_Clicking.Properties.Resources.CherryBlueSpace);
            SoundPlayer BackspaceSound = new SoundPlayer(Happy_Clicking.Properties.Resources.CherryBlueBackspace);
            SoundPlayer DefaultSound = new SoundPlayer(Happy_Clicking.Properties.Resources.CherryBlueDefault);

            if (e.KeyPressed.ToString() == "Return")
                ReturnSound.Play();
            else if (e.KeyPressed.ToString() == "Space")
                SpaceSound.Play();
            else if (e.KeyPressed.ToString() == "Back")
                BackspaceSound.Play();
            else
                DefaultSound.Play();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        private void ProgramExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
