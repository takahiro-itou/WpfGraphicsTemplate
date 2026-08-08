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


namespace  ViewCs.Models  {

public  class  MySampleModel
{

//========================================================================
//
//    Constructor(s) and Destructor.
//

//----------------------------------------------------------------
/**   コンストラクタ。
**
**/
public
MySampleModel(
        int nWidth,
        int nHeight,
        int cbPixel,
        int lStride
{
    m_imgBuffer = new SampleWrapper.Images.FullColorImage();
    this.m_imgBuffer.allocateImage(nWidth, nHeight, cbPixel, lStride);
}

//========================================================================
//
//    Public Member Functions.
//

//----------------------------------------------------------------
/**   サンプル画像を描画する。
**
**/
public  virtual  void
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


//========================================================================
//
//    Properties.
//

//----------------------------------------------------------------
/**   イメージバッファを取得するプロパティ。
**
**/

public  SampleWrapper.Images.FullColorImage
ImageBuffer {
    get { return  this.m_imgBuffer; }
}


//========================================================================
//
//    Member Variables.
//

private  SampleWrapper.Images.FullColorImage    m_imgBuffer;


}   //  End class  MySampleModel

}   //  End of namespace  ViewCs.Models
