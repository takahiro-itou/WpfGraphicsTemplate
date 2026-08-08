''  -*-  coding: utf-8-with-signature  -*-  ''
''************************************************************************
''                                                                      ''
''                  ---   Graphics Test Project.   ---                  ''
''                                                                      ''
''          Copyright (C), 2025-2026, Takahiro Itou                     ''
''          All Rights Reserved.                                        ''
''                                                                      ''
''          License: (See COPYING or LICENSE files)                     ''
''          GNU Affero General Public License (AGPL) version 3,         ''
''          or (at your option) any later version.                      ''
''                                                                      ''
''************************************************************************

Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media.Imaging

Imports ViewVb.Commands
Imports ViewVb.Models


Namespace Global.ViewVb.ViewModels

Public Class SampleViewModel
        Implements INotifyPropertyChanged

Privare m_imgBuffer As SampleWrapper.Images.FullColorImage
Private m_wrapImage As SampleWrapper.Images.FullColorImage
Private m_imgCanvas As WriteableBitmap

Private ReadOnly m_progress As System.IProgress(Of Integer)

Private ReadOnly m_runModelTaskCommand As SimpleCommand

Private m_isRunning As Boolean


Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
Dim ptrBuf As IntPtr
Dim imgCanvas As WriteableBitmap

    imgCanvas = New WriteableBitmap(
            300, 300, 96, 96, Media.PixelFormats.Pbgra32, Nothing)
    Me.m_wrapImage  = New SampleWrapper.Images.FullColorImage()
    Me.m_imgBuffer  = New SampleWrapper.Images.FullColorImage()

    imgCanvas.Lock()
    ptrBuf = imgCanvas.BackBuffer
    Me.m_wrapImage.createImage(
            300, 300,
            (imgCanvas.Format.BitsPerPixel + 7) \ 8,
            imgCanvas.BackBufferStride, ptrBuf)
    imgCanvas.Unlock()
    Me.m_imgCanvas = imgCanvas

    Me.m_imgBuffer.allocateImage(
            300, 300,
            (imgCanvas.Format.BitsPerPixel + 7) \ 8,
            imgCanvas.BackBufferStride)

    Me.m_runModelTaskCommand = New SimpleCommand(
        Sub(ByVal parameter As Object)
            Me.runModelTaskAsync
        End Sub,
        Function(ByVal parameter As Object) As Boolean
            Return  Me.canRunTask()
        End Function
    )

    Me.m_progress = New System.Progress(Of Integer)(AddressOf updateProgress)
    Me.m_isRunning  = False
End Sub


''======================================================================
''
''    Properties.
''

Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged


Public Property IsRunning() As Boolean
    Get
        Return  Me.m_isRunning
    End Get
    Private Set(ByVal value As Boolean)
        Me.m_isRunning = value
        raisePropertyChanged()
        raiseCanExecuteChanged()
    End Set
End Property


Public Overridable ReadOnly Property RunModelTaskCommand() As ICommand
    Get
        Return  Me.m_runModelTaskCommand
    End Get
End Property


Public Overridable Readonly Property SourceBitmap() As WriteableBitmap
    Get
        Return  Me.m_imgCanvas
    End Get
End Property


''======================================================================
''
''    Public Member Functions.
''

Public Overridable Function canRunTask() As Boolean
''--------------------------------------------------------------------
''    タスクを実行可能か判定する。
''--------------------------------------------------------------------
    Return  Not Me.IsRunning
End Function


Public Overridable Async Sub runModelTaskAsync()
''--------------------------------------------------------------------
''    モデルのタスクを非同期で実行する。
''--------------------------------------------------------------------
Dim result As Integer
Dim myTask As Task(Of Integer)

    Me.IsRunning  = True

    mytask = Task.Run(Of Integer)(
        Function() As Integer
            Return  executeCommand(Me.m_progress)
        End Function
    )
    result  = await mytask

    Me.IsRunning  = False
End Sub


''======================================================================
''
''    Protected Member Functions.
''

Protected Overridable Sub raiseCanExecuteChanged()
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------

End Sub


Protected Overridable Sub raisePropertyChanged(
        <CallerMemberName> Optional propertyName As String = Nothing)
''--------------------------------------------------------------------
''
''--------------------------------------------------------------------
    RaiseEvent  PropertyChanged(
            Me, New PropertyChangedEventArgs(propertyName)
    )
End Sub


Protected Overridable Sub updateProgress(
        ByVal progressValue As Integer)
''--------------------------------------------------------------------
''    バッファにある画像を画面上に転送する。
''--------------------------------------------------------------------

    With Me.m_imgCanvas
        .Lock()
        Me.m_wrapImage.copyImage(Me.m_imgBuffer)
        .AddDirtyRect(new Int32Rect(0, 0, 300, 300))
        .Unlock()
    End With
End Sub


Protected Overridable Sub drawSampleImage()
''--------------------------------------------------------------------
''    サンプル画像を描画する。
''--------------------------------------------------------------------
Dim colBG As Integer
Dim colTL As Integer
Dim colTR As Integer
Dim colBL As Integer
Dim colBR As Integer
Dim rnd As New Random()

    ' 色を適当に決める。背景はある程度明るい色
    colBG = rnd.Next(16777216) Or &HFF808080

    ' 色を適当に決める。
    colTL = rnd.Next(256) Or &HFF000080
    colTR = (rnd.Next(256) * 256) OR &HFF008000
    colBL = rnd.Next(256)
    colBL = (colBL * 257) Or &HFF008080
    colBR = (rnd.Next(256) * 65536) OR &HFF800000

    Me.m_imgBuffer.drawSample(colBG, colTL, colTR, colBL, colBR)
End Sub


Public Overridable Function executeCommand(
        ByVal progress As IProgress(Of Integer) ) As Integer
''--------------------------------------------------------------------
''    モデルのタスクを実行する。
''--------------------------------------------------------------------
Dim i As Integer

    For i = 1 To 100
        drawSampleImage()
        progress.Report(i)
        System.Threading.Thread.Sleep(10)
    Next i

    executeCommand = 0
End Function


End Class

End Namespace
