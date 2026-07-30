
Namespace Global.ViewVb.Views


Public Class MainWindow

Private m_model As Models.MySampleModel

Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
    InitializeComponent()
    Me.m_model = New Models.MySampleModel()
    SampleControl1.ViewModel = New WpfControl.Sample.SampleViewModel(m_model)
End Sub


End Class

End Namespace
