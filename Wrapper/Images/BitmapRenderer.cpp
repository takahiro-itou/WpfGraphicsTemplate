//  -*-  coding: utf-8-with-signature;  mode: c++  -*-  //
/*************************************************************************
**                                                                      **
**                  ---   Graphics Test Project.   ---                  **
**                                                                      **
**          Copyright (C), 2025-2025, Takahiro Itou                     **
**          All Rights Reserved.                                        **
**                                                                      **
**          License: (See COPYING or LICENSE files)                     **
**          GNU Affero General Public License (AGPL) version 3,         **
**          or (at your option) any later version.                      **
**                                                                      **
*************************************************************************/

/**
**      An Implementation of BitmapRenderer class.
**
**      @file       Images/BitmapRenderer.cpp
**/

#include "StdAfx.h"

#include "BitmapRenderer.h"


namespace  SampleWrapper  {
namespace  Images  {

namespace  {

}   //  End of (Unnamed) namespace


//========================================================================
//
//    BitmapRenderer  class.
//

//========================================================================
//
//    Constructor(s) and Destructor.
//

//----------------------------------------------------------------
//    インスタンスを初期化する
//  （デフォルトコンストラクタ）。
//

BitmapRenderer::BitmapRenderer()
    : m_ptrObj(new WrapTarget())
{
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （デストラクタ）。
//

BitmapRenderer::~BitmapRenderer()
{
    //  マネージドリソースを破棄する。              //
    delete  this->m_wImage;
    this->m_wImage  = nullptr;

    //  続いて、アンマネージドリソースも破棄する。  //
    this->!BitmapRenderer();
}

//----------------------------------------------------------------
//    インスタンスを破棄する
//  （ファイナライザ）。
//

BitmapRenderer::!BitmapRenderer()
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

FullColorImage ^
BitmapRenderer::createImage(
        IntPtr      hDC,
        const  int  nWidth,
        const  int  nHeight)
{
    int ret;

    ret = this->m_ptrObj->createImage(
                static_cast<HDC>(hDC.ToPointer()),
                nWidth, nHeight
    );

    const  unsigned cbPixel = this->m_ptrObj->getBytesPerPixel();
    const  unsigned lStride = this->m_ptrObj->getBytesPerLine();

    this->m_wImage  = gcnew FullColorImage();
    this->m_wImage->createImage(
            nWidth,
            nHeight,
            cbPixel,
            lStride,
            this->m_ptrObj->getImage()
    );

    return ( this->m_wImage );
}

//----------------------------------------------------------------
//    イメージをデバイスに表示する。
//

int
BitmapRenderer::drawImage(
        IntPtr      hDC,
        const  int  dx,
        const  int  dy,
        const  int  w,
        const  int  h,
        const  int  sx,
        const  int  sy)
{
    return  this->m_ptrObj->drawImage(
                static_cast<HDC>(hDC.ToPointer()),
                dx, dy, w, h, sx, sy
    );
}

//========================================================================
//
//    Public Member Functions.
//

//========================================================================
//
//    Accessors.
//

//========================================================================
//
//    Properties.
//

//----------------------------------------------------------------
//    イメージオブジェクトを取得する。
//

FullColorImage ^
BitmapRenderer::Image::get()
{
    return ( this->m_wImage );
}

//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    For Internal Use Only.
//

}   //  End of namespace  Images
}   //  End of namespace  SampleWrapper
