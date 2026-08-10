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

Imports FullColorImage = SampleWrapper.Images.FullColorImage

Imports ViewVb.Commands
Imports ViewVb.Models


Namespace Global.ViewVb.ViewModels

Public Class SampleViewModel
        Implements INotifyPropertyChanged

''======================================================================
''
''    Member Variables.
''

Private  ReadOnly   m_trgModel As MySampleModel

Private  ReadOnly   m_mainImage As FullColorImage

Private  ReadOnly   m_progress As System.IProgress(Of Integer)

Private  ReadOnly   m_runModelTaskCommand As SimpleCommand(Of Integer)
Private  ReadOnly   m_clearImageCommand   As SimpleCommand(Of Integer)

Private m_bmpCanvas As WriteableBitmap

Private m_isRunning As Boolean


''======================================================================
''
''    Constructor(s) and Destructor.
''

Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
Dim nWidth  As Integer = 300
Dim nHeight As Integer = 300
Dim cbPixel As Integer = 4
Dim lStride As Integer

Dim ptrBuf As IntPtr
Dim bmpCanvas As WriteableBitmap

    bmpCanvas = New WriteableBitmap(
            nWidth, nHeight, 96, 96, Media.PixelFormats.Pbgra32, Nothing)
    Me.m_mainImage  = New FullColorImage()

    With bmpCanvas
        .Lock()
        cbPixel = (.Format.BitsPerPixel + 7) \ 8
        lStride = .BackBufferStride

        ptrBuf = .BackBuffer
        Me.m_mainImage.createImage(nWidth, nHeight, cbPixel, lStride, ptrBuf)
        .Unlock()
    End With

    Me.m_bmpCanvas  = bmpCanvas
    Me.m_trgModel   = New MySampleModel(nWidth, nHeight, cbPixel, lStride)

    Me.m_runModelTaskCommand = New SimpleCommand(Of Integer)(
        Sub(ByVal parameter As Integer)
            Me.runModelTaskAsync(parameter)
        End Sub,
        Function(ByVal parameter As Object) As Boolean
            Return  Me.canRunTask()
        End Function
    )
    Me.m_clearImageCommand  = New SimpleCommand(Of Integer)(
        Sub(ByVal parameter As Integer)
            Me.m_trgModel.clearImage(parameter)
        End Sub
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


Public Overridable ReadOnly Property ClearImageCommand() As ICommand
    Get
        Return  Me.m_clearImageCommand
    End Get
End Property


Public Overridable ReadOnly Property RunModelTaskCommand() As ICommand
    Get
        Return  Me.m_runModelTaskCommand
    End Get
End Property


Public Overridable Readonly Property SourceBitmap() As WriteableBitmap
    Get
        Return  Me.m_bmpCanvas
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


Public Overridable Async Sub runModelTaskAsync(ByVal parameter As Integer)
''--------------------------------------------------------------------
''    モデルのタスクを非同期で実行する。
''--------------------------------------------------------------------
Dim result As Integer
Dim myTask As Task(Of Integer)

    Me.IsRunning  = True

    mytask = Task.Run(Of Integer)(
        Function() As Integer
            Return  executeCommand(Me.m_progress, parameter)
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

    With Me.m_bmpCanvas
        .Lock()
        Me.m_mainImage.copyImage(Me.m_trgModel.ImageBuffer)
        .AddDirtyRect(New Int32Rect(0, 0, 300, 300))
        .Unlock()
    End With
End Sub


Public Overridable Function executeCommand(
        ByVal progress As IProgress(Of Integer),
        ByVal parameter As Integer) As Integer
''--------------------------------------------------------------------
''    モデルのタスクを実行する。
''--------------------------------------------------------------------
Dim i As Integer
Dim interval As Integer
Dim count As Integer

    interval = 2000 / parameter
    count    = parameter

    For i = 1 To count
        Me.m_trgModel.drawSampleImage()
        progress.Report(i)
        System.Threading.Thread.Sleep(interval)
    Next i

    executeCommand = 0
End Function


End Class

End Namespace
