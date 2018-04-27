using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace key
{
    class hookMouse
    {
        private static LowLevelMouseProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        static hookMouse()
        {
            _hookID = SetHook(_proc);
        }
        ~hookMouse()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)

            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }

        }


        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        public static event MouseEventHandler MouseDown;
        public static event MouseEventHandler MouseUp;
        public static event MouseEventHandler MouseMove;
        public static event MouseEventHandler MouseWheel;
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                if (MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam && MouseMove != null)
                {
                    MouseEventArgs e = new MouseEventArgs(MouseButtons.None, 0, hookStruct.pt.x, hookStruct.pt.y, 0);
                    MouseMove(0, e);
                }else
                if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam && MouseDown != null) // Left down set clicks = 1
                {
                    MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                    MouseDown(null, e);
                }
                else if ((MouseMessages)wParam == MouseMessages.WM_LBUTTONUP && MouseUp!= null) // Left up set clicks = 1
                {
                    MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                    MouseUp(null, e);
                }
                else if ((MouseMessages)wParam == MouseMessages.WM_RBUTTONDOWN && MouseDown != null) // mouseRight down set clicks = 0
                {
                    MouseEventArgs e = new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0);
                    MouseDown(null, e);
                }
                else if ((MouseMessages)wParam == MouseMessages.WM_RBUTTONUP && MouseUp != null)// mouseRight up set clicks = 0
                {
                    MouseEventArgs e = new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0);
                    MouseUp(null, e);
                }
                else if((MouseMessages)wParam == MouseMessages.WM_MOUSEWHEEL && MouseUp != null)// mouseWheel
                {
                    MouseWheel(null, null);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }


        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }


        #region Import
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion


    }
}
