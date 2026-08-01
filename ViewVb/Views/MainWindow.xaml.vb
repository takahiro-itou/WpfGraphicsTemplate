
Imports System.Windows
Imports System.Windows.Media.Imaging


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
Dim imgCanvas As System.Windows.Media.Imaging.WriteableBitmap
Dim ptrBuf As IntPtr
Dim wrapImg As SampleWrapper.Images.FullColorImage
Dim colBG As Integer
Dim colTL As Integer
Dim colTR As Integer
Dim colBL As Integer
Dim colBR As Integer
Dim rnd As New Random()

    ' 色を適当に決める。背景はある程度明るい色
    colBG = rnd.Next(16777216) OR &HFF808080

    ' 色を適当に決める。
    colTL = rnd.Next(256) OR &HFF000080
    colTR = (rnd.Next(256) * 256) OR &HFF008000
    colBL = rnd.Next(65536) OR &HFF008080
    colBR = (rnd.Next(256) * 65536) OR &HFF800000

    imgCanvas = New WriteableBitmap(
            300, 300, 96, 96, Media.PixelFormats.Pbgra32, Nothing)
    wrapImg = New SampleWrapper.Images.FullColorImage()

    imgCanvas.Lock()
    ptrBuf = imgCanvas.BackBuffer
    wrapImg.createImage(
            300, 300,
            (imgCanvas.Format.BitsPerPixel + 7) \ 8,
            imgCanvas.BackBufferStride, ptrBuf)

    wrapImg.drawSample(colBG, colTL, colTR, colBL, colBR)
    imgCanvas.AddDirtyRect(new Int32Rect(0, 0, 300, 300))
    imgCanvas.Unlock()

    picView.Source = imgCanvas
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
