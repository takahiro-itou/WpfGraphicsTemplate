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
**      An Interface of BitmapRenderer class.
**
**      @file       Images/BitmapRenderer.h
**/

#pragma once

#include    "Sample/Images/BitmapRenderer.h"

#include    "FullColorImage.h"


using namespace System;

namespace  SampleWrapper  {
namespace  Images  {

//========================================================================
//
//    BitmapRenderer  class.
//

public ref  class  BitmapRenderer
{

//========================================================================
//
//    Internal Type Definitions.
//

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
    BitmapRenderer();

    //----------------------------------------------------------------
    /**   インスタンスを破棄する
    **  （デストラクタ）。
    **
    **/
    virtual  ~BitmapRenderer();

    //----------------------------------------------------------------
    /**   インスタンスを破棄する
    **  （ファイナライザ）。
    **
    **/
    !BitmapRenderer();

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
    **/
    virtual  FullColorImage ^
    createImage(
            IntPtr      hDC,
            const  int  nWidth,
            const  int  nHeight);

    //----------------------------------------------------------------
    /**   イメージをデバイスに表示する。
    **
    **/
    virtual  int
    drawImage(
            IntPtr      hDC,
            const  int  dx,
            const  int  dy,
            const  int  w,
            const  int  h,
            const  int  sx,
            const  int  sy);

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
public:

    //----------------------------------------------------------------
    /**   イメージオブジェクトを取得する。
    **
    **/
    property    FullColorImage ^
    Image
    {
        FullColorImage^ get();
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
    typedef     Sample::Images::BitmapRenderer  WrapTarget;

    WrapTarget  *   m_ptrObj;

    FullColorImage^ m_wImage;
};

}   //  End of namespace  Images
}   //  End of namespace  SampleWrapper
