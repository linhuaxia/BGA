using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace Lin.BGA.HDL
{
    public class SoundHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);
       public const uint WM_APPCOMMAND = 0x319;
        public const uint APPCOMMAND_VOLUME_UP = 0x0a;
        public const uint APPCOMMAND_VOLUME_DOWN = 0x09;
        public const uint APPCOMMAND_VOLUME_MUTE = 0x08;
    }
}
