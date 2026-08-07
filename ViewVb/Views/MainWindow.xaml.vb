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

Imports System.Windows
Imports System.Windows.Media.Imaging


Namespace Global.ViewVb.Views

Public Class MainWindow

Private m_model As Models.MySampleModel
Private m_viewModel As ViewModels.SampleViewModel


Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
Dim ptrBuf As IntPtr
Dim imgCanvas As System.Windows.Media.Imaging.WriteableBitmap

    InitializeComponent()

    Me.m_viewModel  = New ViewModels.SampleViewModel()
    Me.DataContext  = Me.m_viewModel
    Me.picView.Source = Me.m_viewModel.SourceBitmap
End Sub


Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As EventArgs)
''--------------------------------------------------------------------
''    メニュー「ファイル」－「終了」
''--------------------------------------------------------------------
    System.Windows.Application.Current.Shutdown()
End Sub


End Class

End Namespace
