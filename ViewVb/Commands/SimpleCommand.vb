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

Imports System
Imports System.Windows.Input


Namespace Global.ViewVb.Commands

Public Class SimpleCommand(Of T)
        Implements ICommand

''========================================================================
''
''    Member Variables.
''

Private  ReadOnly  m_execute    As Action(Of T)
Private  ReadOnly  m_canExecute As Predicate(Of Object)


''========================================================================
''
''    Constructor(s) and Destructor.
''

Public Sub New(
        execute As Action(Of T),
        Optional canExecute As Predicate(Of Object) = Nothing)
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
    Me.m_execute    = execute
    Me.m_canExecute = canExecute
End Sub


''========================================================================
''
''    Public Member Functions (Implement Interface).
''

Public Function CanExecute(parameter As Object) As Boolean _
        Implements ICommand.CanExecute
    Return If(m_canExecute Is Nothing, True, m_canExecute(parameter))
End Function


Public Sub Execute(parameter As Object) Implements ICommand.Execute
    Me.m_execute(CType(parameter, T))
End Sub


''========================================================================
''
''    Public Events (Implement Interface).
''

Public Event CanExecuteChanged As EventHandler _
        Implements ICommand.CanExecuteChanged


''========================================================================
''
''    Public Member Functions.
''

Public Sub raiseCanExecuteChanged()
    RaiseEvent CanExecuteChanged(Me, EventArgs.Empty)
End Sub


End Class

End Namespace
