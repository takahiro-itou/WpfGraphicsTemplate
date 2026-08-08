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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using ViewCs.Commands;
using ViewCs.Models;


namespace  ViewCs.ViewModels  {

public  class  SampleViewModel : INotifyPropertyChanged
{

//========================================================================
//
//    Constructor(s) and Destructor.
//

//----------------------------------------------------------------
/**   コンストラクタ。
**
**/
public SampleViewModel()
{
    const  int  nWidth  = 300;
    const  int  nHeight = 300;
    int         cbPixel = 4;
    int         lStride = 0;

    System.IntPtr       ptrBuf;
    WriteableBitmap     bmpCanvas;

    bmpCanvas = new WriteableBitmap(
            nWidth, nHeight, 96, 96,
            PixelFormats.Pbgra32, null);
    m_wrapImage = new SampleWrapper.Images.FullColorImage();

    bmpCanvas.Lock();
    cbPixel = (bmpCanvas.Format.BitsPerPixel + 7) >> 3;
    lStride = bmpCanvas.BackBufferStride;

    ptrBuf  = bmpCanvas.BackBuffer;
    this.m_wrapImage.createImage(nWidth, nHeight, cbPixel, lStride, ptrBuf);
    bmpCanvas.Unlock();

    this.m_bmpCanvas = bmpCanvas;
    this.m_trgModel = new MySampleModel(nWidth, nHeight, cbPixel, lStride);

    this.m_runModelTaskCommand = new SimpleCommand(
        _ => this.runModelTaskAsync(),
        _ => this.canRunTask()
    );

    this.m_progress  = new System.Progress<int>(updateProgress);
    this.m_isRunning = false;
}

//========================================================================
//
//    Properties.
//

//----------------------------------------------------------------
/**
**
**/
public  event PropertyChangedEventHandler?  PropertyChanged;


//----------------------------------------------------------------
/**
**
**/
public  bool
IsRunning  {
    get { return  this.m_isRunning; }
    private set {
        this.m_isRunning = value;
        raisePropertyChanged();
        raiseCanExecuteChanged();
    }
}

//----------------------------------------------------------------
/**   タスクを実行するコマンドを取得するプロパティ。
**
**/
public  virtual  ICommand
RunModelTaskCommand {
    get { return  this.m_runModelTaskCommand; }
}


//----------------------------------------------------------------
/**
**
**/
public  virtual  WriteableBitmap
SourceBitmap {
    get { return  this.m_bmpCanvas; }
}


//========================================================================
//
//    Public Member Functions.
//

//----------------------------------------------------------------
/**   タスクを実行可能か判定する。
**
**/
public  virtual  bool
canRunTask()
{
    return ( ! this.IsRunning );
}

//----------------------------------------------------------------
/**   モデルのタスクを非同期で実行する。
**
**/
public  virtual  async  void
runModelTaskAsync()
{
    this.IsRunning  = true;

    Task<int>  task = Task.Run<int>(
        () => this.executeCommand(this.m_progress));
    int  result = await task;

    this.IsRunning  = false;
}


//========================================================================
//
//    Protected Member Functions.
//

//----------------------------------------------------------------
/**
**
**/
protected  virtual  void
raiseCanExecuteChanged()
{
}

//----------------------------------------------------------------
/**
**
**/
protected  virtual  void
raisePropertyChanged(
        [CallerMemberName]  System.String?  propertyName = null)
{
    PropertyChanged?.Invoke(
            this, new PropertyChangedEventArgs(propertyName));
}

//----------------------------------------------------------------
/**
**
**/
protected  virtual  void
updateProgress(int progressValue)
{
    this.m_bmpCanvas.Lock();
    this.m_wrapImage.copyImage(this.m_trgModel.ImageBuffer);
    this.m_bmpCanvas.AddDirtyRect(new Int32Rect(0, 0, 300, 300));
    this.m_bmpCanvas.Unlock();
}

//----------------------------------------------------------------
/**   サンプル画像を描画する。
**
**/
protected  virtual  void
drawSampleImage()
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

    this.m_imgBuffer.drawSample(colBG, colTL, colTR, colBL, colBR);
}

//----------------------------------------------------------------
/**   モデルのタスクを実行する。
**
**/

public  virtual  int
executeCommand(
        System.IProgress<int>   progress)
{
    for ( int i = 1; i <= 100; ++ i ) {
        this.m_trgModel.drawSampleImage();
        progress.Report(i);
        System.Threading.Thread.Sleep(10);
    }

    return ( 0 );
}


//========================================================================
//
//    Member Variables.
//

private  readonly   MySampleModel               m_trgModel;

private  SampleWrapper.Images.FullColorImage    m_wrapImage;

private  WriteableBitmap                        m_bmpCanvas;

private  readonly   System.IProgress<int>       m_progress;

private  readonly   SimpleCommand               m_runModelTaskCommand;

private  bool   m_isRunning;


}   //  End class  SampleViewModel

}   //  End of namespace  ViewCs.ViewModels
