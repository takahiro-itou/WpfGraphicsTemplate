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
Imports System.Windows.Input
Imports System.Windows.Media

Imports ViewVb.Commands
Imports ViewVb.Models


Namespace Global.ViewVb.ViewModels

Public Class SampleViewModel
        Implements INotifyPropertyChanged

Private m_wrapImage As SampleWrapper.Images.FullColorImage
Private m_imgCanvas As Imaging.WriteableBitmap

Private ReadOnly m_progress As System.IProgress(Of Integer)

Private ReadOnly m_runModelTaskCommand As SimpleCommand

Private m_isRunning As Boolean


Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
Dim ptrBuf As IntPtr
Dim imgCanvas As Imaging.WriteableBitmap

    imgCanvas = New Imaging.WriteableBitmap(
            300, 300, 96, 96, PixelFormats.Pbgra32, Nothing)
    Me.m_wrapImage  = New Sample.Wrapper.Images.FullColorImage()

    imgCanvas.Lock()
    ptrBuf = imgCanvas.BackBuffer
    Me.m_wrapImage.createImage(
            300, 300,
            (imgCanvas.Format.BitsPerPixel + 7) \ 8,
            imgCanvas.BackBufferStride, ptrBuf)
    imgCanvas.Unlock()
    Me.m_imgCanvas = imgCanvas

    Me.m_progress = New System.Progress(Of Integer)(AddressOf updateProgress)

    Me.m_runModelTaskCommand = New SimpleCommand(
        Sub(ByVal parameter As Object)
            Me.runModelTaskAsync
        End Sub,
        Function(ByVal parameter As Object) As Boolean
            Return  Me.canRunTask()
        End Function
    )

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
''
''--------------------------------------------------------------------

End Sub


Public Overridable Function executeCommand(
        ByVal progress As IProgress(Of Integer) ) As Integer
''--------------------------------------------------------------------
''    モデルのタスクを実行する。
''--------------------------------------------------------------------
    progress.Report(100)
    executeCommand = 0
End Function


End Class

End Namespace
