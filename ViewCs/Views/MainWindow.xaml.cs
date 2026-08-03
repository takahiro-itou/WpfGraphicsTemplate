//  -*-  coding: utf-8-with-signature;  mode: c++  -*-  //
/*************************************************************************
**                                                                      **
**                  ---   Graphics Test Project.   ---                  **
**                                                                      **
**          Copyright (C), 2025-2026, Takahiro Itou                     **
**          All Rights Reserved.                                        **
**                                                                      **
**          License: (See COPYING or LICENSE files)                     **
**          GNU Affero General Public License (AGPL) version 3,         **
**          or (at your option) any later version.                      **
**                                                                      **
*************************************************************************/

using System;
using System.Windows;
using System.Windows.Media.Imaging;


namespace  ViewCs.Views  {

public  partial class  MainWindow : Window
{

    //----------------------------------------------------------------
    /**   デフォルトコンストラクタ。
    **
    **/
    public  MainWindow()
    {
        IntPtr  ptrBuf;
        System.Windows.Media.Imaging.WriteableBitmap    imgCanvas;

        InitializeComponent();

        imgCanvas = new WriteableBitmap(
                300, 300, 96, 96,
                System.Windows.Media.PixelFormats.Pbgra32, null);
        this.m_wrapImg = new SampleWrapper.Images.FullColorImage();

        imgCanvas.Lock();
        ptrBuf = imgCanvas.BackBuffer;
        this.m_wrapImg.createImage(
                300, 300,
                (imgCanvas.Format.BitsPerPixel + 7) / 8,
                imgCanvas.BackBufferStride, ptrBuf);
        imgCanvas.Unlock();

        this.m_imgCanvas    = imgCanvas;
        this.picView.Source = imgCanvas;
    }

    //----------------------------------------------------------------
    /**
    **
    **/
    private  void
    runCommand()
    {
        int     cAlpha;
        int     colBG, colTL, colTR, colBL, colBR;
        System.Random   rnd = new System.Random();

        //  色を適当に決める。背景はある程度明るい色
        cAlpha  = 255 << 24;
        colBG = rnd.Next(16777216) | cAlpha | 0x00808080;

        //  色を適当に決める。
        colTL = rnd.Next(256) | cAlpha | 0x00000080;
        colTR = (rnd.Next(256) <<  8) | cAlpha | 0x00008080;
        colBL = rnd.Next(256);
        colBL = (colBL | colBL <<  8) | cAlpha | 0x00008080;
        colBR = (rnd.Next(256) << 16) | cAlpha | 0x00800000;

        this.m_imgCanvas.Lock();
        this.m_wrapImg.drawSample(colBG, colTL, colTR, colBL, colBR);
        this.m_imgCanvas.AddDirtyRect(new Int32Rect(0, 0, 300, 300));
        this.m_imgCanvas.Unlock();
    }

    private  void  mnuFileExit_Click(object sender, EventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
    }

    private  void  mnuRunCommand_Click(object sender, EventArgs e)
    {
        runCommand();
    }

    private System.Windows.Media.Imaging.WriteableBitmap    m_imgCanvas;
    private SampleWrapper.Images.FullColorImage             m_wrapImg;

}

}   //  End of namespace  ViewCs.Views
