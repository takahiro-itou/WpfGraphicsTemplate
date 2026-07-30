
Namespace Global.ViewVb.Views


Public Class MainWindow

Private m_model As Models.MySampleModel

Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
    InitializeComponent()
End Sub


Private Sub runCommand()
''--------------------------------------------------------------------
''    指定したコマンドを実行する。
''--------------------------------------------------------------------
Dim imgCanvas As System.Drawing.Bitmap
Dim grpCanvas As System.Drawing.Graphics
Dim imgBuffer As System.Drawing.Bitmap
Dim grpBuffer As System.Drawing.Graphics
Dim hDisplayDC As IntPtr
Dim hDC As IntPtr
Dim brushBG As System.Drawing.SolidBrush
Dim colorBG As System.Drawing.Color
Dim hBitmap As IntPtr
Dim bmpSrc As System.Windows.Media.Imaging.BitmapSource

    hDisplayDC = GetDC(IntPtr.Zero)

    imgBuffer = New System.Drawing.Bitmap(200, 100)
    grpBuffer = System.Drawing.Graphics.FromImage(imgBuffer)

    colorBG = System.Drawing.Color.FromArgb(&HFFFEF0BA)
    brushBG = New System.Drawing.SolidBrush(colorBG)
    ' grpBuffer.FillRectangle(brushBG, grpBuffer.VisibleClipBounds)
    grpBuffer.FillRectangle(brushBG, 0, 0, 200, 100)

    hDC = grpBuffer.GetHdc()
    BitBlt(hDC, 8, 8, 184, 84, hDisplayDC,
            SystemParameters.PrimaryScreenWidth - 184,
            SystemParameters.PrimaryScreenHeight - 84,
            SRCCOPY)
    grpBuffer.ReleaseHdc(hDC)

    grpBuffer.DrawRectangle(System.Drawing.Pens.Yellow, 50, 30, 100, 60)
    grpBuffer.DrawPie(System.Drawing.Pens.Red, 60, 10, 80, 80, 30, 300)
    grpBuffer.Dispose()

    imgCanvas = New System.Drawing.Bitmap(300, 300)
    grpCanvas = System.Drawing.Graphics.FromImage(imgCanvas)

    colorBG = System.Drawing.Color.FromArgb(&H800000FF)
    brushBG = New System.Drawing.SolidBrush(colorBG)
    ' grpCanvas.FillRectangle(brushBG, grpCanvas.VisibleClipBounds)
    grpCanvas.FillRectangle(brushBG, 0, 0, 300, 300)

    hDC = grpCanvas.GetHdc()
    BitBlt(hDC, 8, 8, 284, 284, hDisplayDC, 0, 0, SRCCOPY)
    grpCanvas.ReleaseHdc(hDC)

    ReleaseDC(IntPtr.Zero, hDisplayDC)

    grpCanvas.DrawImage(imgBuffer, 50, 100, 200, 100)
    grpCanvas.Dispose()

    hBitmap = imgCanvas.GetHbitmap()
    bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            hBitmap, IntPtr.Zero, Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions())
    picView.Source = bmpSrc
End Sub


Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As EventArgs)
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------
    System.Windows.Application.Current.Shutdown()
End Sub


Private Sub mnuRunCommand_Click(sender As Object, e As EventArgs)
''--------------------------------------------------------------------
''    メニュー「実行」－「コマンドを実行」
''--------------------------------------------------------------------
    runCommand()
End Sub


End Class

End Namespace
