
using System.Windows;

using WpfControl.Sample;

namespace  ViewCs  {

public  class  MySampleModel : WpfControl.Sample.AbstractSampleModel
{

    //----------------------------------------------------------------
    /**   適当な動作を実行する。
    **
    **/
    public  override  void
    executeCommand()
    {
        runCount(this.InputText);
    }

    //----------------------------------------------------------------
    /**   サンプル動作。
    **
    **    入力テキスト中のアルファベットの個数を数える。
    **/
    private  void
    runCount(
            string  message)
    {
        int result;
        string  outText;
        SampleWrapper.Common.SampleDocument objWrapper;

        objWrapper = new SampleWrapper.Common.SampleDocument();
        objWrapper.setMessage(message);
        result = objWrapper.countAlphabet();

        outText = $"入力した文字列中のアルファベットの個数は {result}";
        this.setOutputText(outText);
        MessageBox.Show(
                outText, "Sample",
                MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
        return;
    }

}

}   //  End of namespace  ViewCs
