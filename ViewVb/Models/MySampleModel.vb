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

Imports FullColorImage = SampleWrapper.Images.FullColorImage


Namespace Global.ViewVb.Models

Public Class MySampleModel

''======================================================================
''
''    Member Variables.
''

Private  ReadOnly   m_imgBuffer As FullColorImage

Private  ReadOnly   m_imgWidth  As Integer
Private  ReadOnly   m_imgHeight As Integer


''======================================================================
''
''    Constructor(s) and Destructor.
''

Public Sub New(
        ByVal nWidth As Integer,
        ByVal nHeight As Integer,
        ByVal cbPixel As Integer,
        ByVal lStride As Integer)
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
    m_imgWidth  = nWidth
    m_imgHeight = nHeight

    m_imgBuffer = New FullColorImage()
    Me.m_imgBuffer.allocateImage(nWidth, nHeight, cbPixel, lStride)
End Sub


''======================================================================
''
''    Public Member Functions.
''

Public Overridable Sub clearImage(ByVal colBG As Integer)
''--------------------------------------------------------------------
''    画像をクリアする。
''--------------------------------------------------------------------
    Me.m_imgBuffer.fillRectangle(0, 0, Me.m_imgWidth, Me.m_imgHeight, colBG)
End Sub


Public Overridable Sub drawSampleImage()
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


''======================================================================
''
''    Properties.
''

''--------------------------------------------------------------------
''    イメージバッファを取得するプロパティ。
''--------------------------------------------------------------------
Public  ReadOnly  Property  ImageBuffer() As FullColorImage
    Get
        Return  Me.m_imgBuffer
    End Get
End Property


End Class

End Namespace
