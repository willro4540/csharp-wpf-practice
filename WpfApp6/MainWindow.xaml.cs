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

namespace WpfApp6;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        // InitializeComponent(): XAML 파일을 실제로 읽어들이고,
        // x:Name이 붙은 컨트롤들(resultLabel, acButton, CalculatorGrid)을
        // 아래에서 쓸 수 있는 C# 필드로 연결해주는 자동 생성 메서드
        InitializeComponent();

        // x:Name="resultLabel"로 XAML에 이름을 붙였기 때문에,
        // 코드비하인드에서 그 이름 그대로 참조해서 값을 바꿀 수 있음
        // (XAML의 Content="0"을 실행 시점에 덮어씀)
        resultLabel.Content = "12345";

        // FindName(): x:Name 문자열로 컨트롤을 "동적으로" 찾아오는 방법.
        // resultLabel처럼 변수명으로 바로 쓸 수도 있지만,
        // 이름을 문자열로만 알고 있을 때(예: 반복문)는 FindName이 필요함
        Grid grid = (Grid)FindName("CalculatorGrid");

        // 여기서부터는 XAML에 안 적힌 버튼을 C# 코드로만 새로 만들어 추가
        Button sevenBtn = new Button();
        sevenBtn.Content = "7 (동적 생성)";
        sevenBtn.Margin = new Thickness(4);
        Grid.SetRow(sevenBtn, 1);
        Grid.SetColumn(sevenBtn, 0);
        grid.Children.Add(sevenBtn);
    }
}