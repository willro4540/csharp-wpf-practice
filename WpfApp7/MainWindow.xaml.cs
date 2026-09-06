using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // object sender, RoutedEventArgs e : WPF의 모든 이벤트 핸들러가 갖는 표준 시그니처.
    // sender = 이 이벤트를 발생시킨 객체(여기서는 클릭된 Button 그 자체)
    // e = 이벤트에 관한 추가 정보(RoutedEventArgs, 이번 예제에서는 안 씀)
    //
    // 버튼 7/8/9가 전부 이 메서드 하나를 공유한다 — 각 버튼마다 따로
    // sevenButton_Click / eightButton_Click / nineButton_Click을 만드는 대신,
    // "누가 눌렀는지"를 sender로 구분해서 코드 중복을 없앤 버전
    private void digitButton_Click(object sender, RoutedEventArgs e)
    {
        // sender는 object 타입으로 넘어오므로, Button의 기능(Content 등)을
        // 쓰려면 실제 타입인 Button으로 캐스팅(형변환)해야 함
        Button clickedButton = (Button)sender;
        string digit = clickedButton.Content.ToString()!;

        if (resultLabel.Content.ToString() == "0")
        {
            // 기존 값이 "0"이면 그냥 새 숫자로 교체
            resultLabel.Content = digit;
        }
        else
        {
            // 그 외엔 기존 값 뒤에 새 숫자를 이어붙임
            resultLabel.Content = $"{resultLabel.Content}{digit}";
        }
    }
}