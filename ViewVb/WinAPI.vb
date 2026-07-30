
Imports System.Runtime.InteropServices

Module WinAPI

Public Const SRCAND As Integer = &H8800C6
Public Const SRCCOPY As Integer = &HCC0020
Public Const SRCPAINT As Integer = &HEE0086

<DllImport("gdi32.dll")> _
Public Function BitBlt(ByVal hDestDC As IntPtr, _
    ByVal X As Integer, ByVal Y As Integer, _
    ByVal nWidth As Integer, ByVal nHeight As Integer, _
    ByVal hSrcDC As IntPtr, _
    ByVal xSrc As Integer, ByVal ySrc As Integer, _
    ByVal dwRop As Integer) As Integer
End Function

<DllImport("gdi32.dll")> _
Public Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
End Function

<DllImport("gdi32.dll")> _
Public Function DeleteDC(ByVal hDC As IntPtr) As Integer
End Function

<DllImport("user32.dll")> _
Public Function GetDC(ByVal hWnd As IntPtr) As IntPtr
End Function

<DllImport("user32.dll")> _
Public Function ReleaseDC(ByVal hWnd As IntPtr, _
    ByVal hDC As IntPtr) As IntPtr
End Function

<DllImport("gdi32.dll")> _
Public Function SelectObject( _
    ByVal hDC As IntPtr, ByVal hGdiObj As IntPtr) As IntPtr
End Function

End Module
