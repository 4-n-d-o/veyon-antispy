using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace antispy_lol
{
    public static class hide
    {
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        public static void Hide(IntPtr handle, uint n)
        {
            SetWindowDisplayAffinity(handle, n);
        }
    }
}
