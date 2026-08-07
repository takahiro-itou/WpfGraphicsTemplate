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

/**
**      An Implementation of FullColorImage class.
**
**      @file       Images/FullColorImage.cpp
**/

#include    "PreCompile.h"

#include    "FullColorImage.h"


namespace  SampleWrapper  {
namespace  Images  {

namespace  {

}   //  End of (Unnamed) namespace


//========================================================================
//
//    FullColorImage  class.
//

//========================================================================
//
//    Constructor(s) and Destructor.
//

//----------------------------------------------------------------
//    インスタンスを初期化する
//  （デフォルトコンストラクタ）。
//

FullColorImage::FullColorImage()
    : m_ptrObj(new WrapTarget())
{
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （デストラクタ）。
//

FullColorImage::~FullColorImage()
{
    //  マネージドリソースを破棄する。              //

    //  続いて、アンマネージドリソースも破棄する。  //
    this->!FullColorImage();
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （ファイナライザ）。
//

FullColorImage::!FullColorImage()
{
    delete  this->m_ptrObj;
    this->m_ptrObj  = nullptr;
}

//========================================================================
//
//    Public Member Functions (Implement Pure Virtual).
//

//========================================================================
//
//    Public Member Functions (Overrides).
//

//========================================================================
//
//    Public Member Functions (Pure Virtual Functions).
//

//========================================================================
//
//    Public Member Functions (Virtual Functions).
//

//----------------------------------------------------------------
//    イメージを作成する。
//

void
FullColorImage::allocateImage(
        const  int  nWidth,
        const  int  nHeight,
        const  int  cbPixel,
        const  int  lStride)
{
    return  this->m_ptrObj->allocateImage(nWidth, nHeight, cbPixel, lStride);
}

//----------------------------------------------------------------
//    バッファの単純コピーができるか確認する。
//

bool
FullColorImage::canCopyBuffer(
        const  FullColorImage  &imgSrc)  const
{
    return  this->m_ptrObj->canCopyBuffer(imgSrc.m_ptrObj);
}

//----------------------------------------------------------------
//    イメージをコピーする。
//

void
FullColorImage::copyImage(
        const  FullColorImage  &imgSrc)
{
    return  this->m_ptrObj->copyImage(imgSrc.m_ptrObj);
}

//----------------------------------------------------------------
//    イメージの指定範囲をコピーする。
//

void
FullColorImage::copyRectangle(
        const  FullColorImage  &imgSrc,
        const  PosUnitType      x1,
        const  PosUnitType      y1,
        const  PosUnitType      x2,
        const  PosUnitType      y2)
{
    return  this->m_ptrObj->copyRectangle(imgSrc.m_ptrObj, x1, y1, x2, y2);
}

//----------------------------------------------------------------
//    バッファの内容を単純にコピーする。
//

void
FullColorImage::copyToBuffer(
        IntPtr      ptrDst)  const
{
    return  this->m_ptrObj->copyToBuffer(ptrDst.ToPointer());
}

//----------------------------------------------------------------
//    バッファの内容を単純にコピーする。
//

void
FullColorImage::copyToBuffer(
        void  *     ptrDst)  const
{
    return  this->m_ptrObj->copyToBuffer(ptrDst);
}

//----------------------------------------------------------------
//    イメージを作成する。
//

void
FullColorImage::createImage(
        const  int  nWidth,
        const  int  nHeight,
        const  int  cbPixel,
        const  int  lStride,
        void  *     lpBits)
{
    return  this->m_ptrObj->createImage(
                nWidth, nHeight, cbPixel, lStride, lpBits
    );
}

//----------------------------------------------------------------
//    イメージを作成する。
//

void
FullColorImage::createImage(
        const  int  nWidth,
        const  int  nHeight,
        const  int  cbPixel,
        const  int  lStride,
        IntPtr      lpBits)
{
    return  this->m_ptrObj->createImage(
                nWidth, nHeight, cbPixel, lStride, lpBits.ToPointer()
    );
}

//----------------------------------------------------------------
//    サンプル画像を描画する。
//

void
FullColorImage::drawSample(
        const  ColorArgb32  colBG,
        const  ColorArgb32  colTL,
        const  ColorArgb32  colTR,
        const  ColorArgb32  colBL,
        const  ColorArgb32  colBR)
{
    return  this->m_ptrObj->drawSample(colBG, colTL, colTR, colBL, colBR);
}

//========================================================================
//
//    Public Member Functions.
//

//----------------------------------------------------------------
//    矩形を描画する。
//

void
FullColorImage::fillRectangle(
        const  int  x1,
        const  int  y1,
        const  int  x2,
        const  int  y2,
        const  int  color)
{
    return  this->m_ptrObj->fillRectangle(x1, y1, x2, y2, color);
}

//========================================================================
//
//    Accessors.
//

//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    For Internal Use Only.
//

}   //  End of namespace  Common
}   //  End of namespace  SampleWrapper
