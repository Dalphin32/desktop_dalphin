using System;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class trnsprnt_screen : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hwnd, string text, string caption, uint type);

    [DllImport("user32.dll")]
    public static extern IntPtr GetActiveWindow();
    
    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    public struct MARGINS {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;
    
    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

    private void Start()
    {  
        #if !UNITY_EDITOR
            IntPtr hwnd = GetActiveWindow();
            MARGINS margins = new MARGINS { cxLeftWidth = -1};

            DwmExtendFrameIntoClientArea( hwnd, ref margins);
            SetWindowLong(hwnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);

            SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, 0);
        #endif
    }
    
}
