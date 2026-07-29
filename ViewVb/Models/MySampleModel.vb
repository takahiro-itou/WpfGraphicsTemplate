
Imports WpfControl.Sample

Public Class MySampleModel
        Inherits WpfControl.Sample.AbstractSampleModel

Public Overrides Sub executeCommand()
''--------------------------------------------------------------------
''    適当な動作を実行する
''--------------------------------------------------------------------
    RunCount(Me.InputText)
End Sub


Private Sub runCount(ByVal message As String)
''--------------------------------------------------------------------
''    サンプル動作
''
''    入力テキスト中のアルファベットの個数を数える
''--------------------------------------------------------------------
Dim result As Integer
Dim outText As String
Dim objWrapper As SampleWrapper.Common.SampleDocument

    objWrapper = New SampleWrapper.Common.SampleDocument()
    objWrapper.setMessage(message)
    result = objWrapper.countAlphabet()

    outText = "入力した文字列中のアルファベットの個数は " & result
    Me.setOutputText(outText)
    MsgBox(outText, MsgBoxStyle.OkOnly)
End Sub


End Class
