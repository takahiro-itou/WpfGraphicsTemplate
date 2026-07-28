
Public Class MainWindow

Private m_model As MySampleModel

Public Sub New()
''--------------------------------------------------------------------
''    コンストラクタ
''--------------------------------------------------------------------
    InitializeComponent()
    Me.m_model = New MySampleModel()
    SampleControl1.ViewModel = New WpfControl.Sample.SampleViewModel(m_model)
End Sub


End Class
