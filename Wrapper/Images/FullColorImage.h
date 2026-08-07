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
**      An Interface of FullColorImage class.
**
**      @file       Images/FullColorImage.h
**/

#pragma once

#include    "Sample/Images/FullColorImage.h"


using namespace System;

namespace  SampleWrapper  {
namespace  Images  {

//========================================================================
//
//    FullColorImage  class.
//

public ref  class  FullColorImage
{

//========================================================================
//
//    Internal Type Definitions.
//
private:

    typedef     Sample::Images::FullColorImage  WrapTarget;

public:

    typedef     WrapTarget::ColorArgb32         ColorArgb32;


//========================================================================
//
//    Constructor(s) and Destructor.
//
public:

    //----------------------------------------------------------------
    /**   インスタンスを初期化する
    **  （デフォルトコンストラクタ）。
    **
    **/
    FullColorImage();

    //----------------------------------------------------------------
    /**   インスタンスを破棄する
    **  （デストラクタ）。
    **
    **/
    virtual  ~FullColorImage();

    //----------------------------------------------------------------
    /**   インスタンスを破棄する
    **  （ファイナライザ）。
    **
    **/
    !FullColorImage();

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
public:

    //----------------------------------------------------------------
    /**   イメージを作成する。
    **
    **  @param [in] nWidth    イメージの幅
    **  @param [in] nHeight   イメージの高さ
    **  @param [in] cbPixel   ピクセル当たりのバイト数。
    **  @param [in] lStride   行当たりのバイト数。
    **/
    virtual  void
    allocateImage(
            const  int  nWidth,
            const  int  nHeight,
            const  int  cbPixel,
            const  int  lStride);

    //----------------------------------------------------------------
    /**   バッファの単純コピーができるか確認する。
    **
    **/
    virtual  bool
    canCopyBuffer(
            const  FullColorImage  &imgSrc)  const;

    //----------------------------------------------------------------
    /**   イメージをコピーする。
    **
    **/
    virtual  void
    copyImage(
            const  FullColorImage  &imgSrc);

    //----------------------------------------------------------------
    /**   イメージの指定範囲をコピーする。
    **
    **/
    virtual  void
    copyRectangle(
            const  FullColorImage  &imgSrc,
            const  PosUnitType      x1,
            const  PosUnitType      y1,
            const  PosUnitType      x2,
            const  PosUnitType      y2);

    //----------------------------------------------------------------
    /**   バッファの内容を単純にコピーする。
    **
    **/
    virtual  void
    copyToBuffer(
            LpWriteBuf  ptrDst)  const;

    //----------------------------------------------------------------
    /**   イメージを作成する。
    **
    **  @param [in] nWidth    イメージの幅
    **  @param [in] nHeight   イメージの高さ
    **  @param [in] cbPixel   ピクセル当たりのバイト数。
    **  @param [in] lStride   行当たりのバイト数。
    **  @param [in] lpBits    イメージデータ。
    **/
    virtual  void
    createImage(
            const  int  nWidth,
            const  int  nHeight,
            const  int  cbPixel,
            const  int  lStride,
            void  *     lpBits);

    //----------------------------------------------------------------
    /**   イメージを作成する。
    **
    **  @param [in] nWidth    イメージの幅
    **  @param [in] nHeight   イメージの高さ
    **  @param [in] cbPixel   ピクセル当たりのバイト数。
    **  @param [in] lStride   行当たりのバイト数。
    **  @param [in] lpBits    イメージデータ。
    **/
    virtual  void
    createImage(
            const  int  nWidth,
            const  int  nHeight,
            const  int  cbPixel,
            const  int  lStride,
            IntPtr      lpBits);

    //----------------------------------------------------------------
    /**   サンプル画像を描画する。
    **
    **/
    virtual  void
    drawSample(
            const  ColorArgb32  colBG,
            const  ColorArgb32  colTL,
            const  ColorArgb32  colTR,
            const  ColorArgb32  colBL,
            const  ColorArgb32  colBR);

    //----------------------------------------------------------------
    /**   確保したバッファを解放する。
    **
    **/
    virtual  void
    freeImageBuffer();


//========================================================================
//
//    Public Member Functions.
//
public:

    //----------------------------------------------------------------
    /**   矩形を描画する。
    **
    **/
    void
    fillRectangle(
            const  int  x1,
            const  int  y1,
            const  int  x2,
            const  int  y2,
            const  int  color);

//========================================================================
//
//    Accessors.
//
public:

    //----------------------------------------------------------------
    /**   ピクセル当たりのバイト数を取得する。
    **
    **/
    inline  int
    getBytesPerPixel()  const
    {
        return  this->m_ptrObj->getBytesPerPixel();
    }

    //----------------------------------------------------------------
    /**   画像の高さを取得する。
    **
    **/
    inline  int
    getHeight()  const
    {
        return  this->m_ptrObj->getHeight();
    }

    //----------------------------------------------------------------
    /**   行当たりのバイト数（ストライド）を取得する。
    **
    **/
    inline  int
    getStride()  const
    {
        return  this->m_ptrObj->getStride();
    }

    //----------------------------------------------------------------
    /**   画像の幅を取得する。
    **
    **/
    inline  int
    getWidth()  const
    {
        return  this->m_ptrObj->getWidth();
    }


//========================================================================
//
//    Protected Member Functions.
//

//========================================================================
//
//    For Internal Use Only.
//

//========================================================================
//
//    Member Variables.
//
private:
    WrapTarget  *   m_ptrObj;

};

}   //  End of namespace  Common
}   //  End of namespace  SampleWrapper
