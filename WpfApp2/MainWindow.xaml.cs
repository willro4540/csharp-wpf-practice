using System.Windows;
using System.Windows.Controls;

namespace WpfApp2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // 화면(resultLabel)에 지금 표시 중인 숫자를 문자열로 들고 있는 변수.
    // 문자열로 두는 이유: "12." 처럼 입력 중간 상태(소수점만 찍힌 상태)를 그대로 보여줘야 하기 때문
    private string _display = "0";

    // 연산자(+,-,*,/)를 누르기 "직전"까지 화면에 있던 숫자를 저장해두는 곳
    // 예: 3 + 5 를 누르면, "+" 누르는 순간 3이 여기에 저장됨
    private double _storedValue = 0;

    // 지금 대기 중인 연산자. 아직 아무 연산자도 안 눌렀으면 null
    private string? _pendingOperator = null;

    // true면 "다음 숫자 버튼을 누르면 기존 화면을 지우고 새로 시작"을 의미
    // (연산자를 누른 직후, AC를 누른 직후, = 을 누른 직후가 이 상태)
    private bool _startNewNumber = true;

    public MainWindow()
    {
        InitializeComponent();
    }

    // 숫자 버튼(0~9, .) 전부가 이 한 메서드를 공유해서 사용함
    // sender: 실제로 클릭된 버튼 객체가 넘어옴 (어떤 숫자를 눌렀는지는 여기서 알아냄)
    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        Button clicked = (Button)sender;
        string digit = clicked.Content.ToString()!;

        if (_startNewNumber)
        {
            // 새로 시작하는 시점: "." 을 누르면 "0."부터, 아니면 그 숫자 하나로 시작
            _display = (digit == ".") ? "0." : digit;
            _startNewNumber = false;
        }
        else
        {
            // 이미 소수점이 있는데 "."을 또 누르면 무시 (12.3. 같은 잘못된 값 방지)
            if (digit == "." && _display.Contains('.'))
            {
                return;
            }
            _display += digit; // 기존 문자열 뒤에 이어붙임 (예: "1" + "2" -> "12")
        }

        resultLabel.Content = _display;
    }

    // +, -, *, / 버튼이 공유하는 메서드
    private void OperatorButton_Click(object sender, RoutedEventArgs e)
    {
        Button clicked = (Button)sender;

        // 이미 대기 중인 연산자가 있고, 그 사이에 새 숫자를 입력한 상태라면
        // 새 연산자를 처리하기 전에 먼저 이전 계산을 끝내야 함 (예: 3 + 5 * 에서 * 누르는 순간 3+5=8 먼저 계산)
        if (_pendingOperator != null && !_startNewNumber)
        {
            Calculate();
        }

        _storedValue = double.Parse(_display); // 지금까지 입력된 숫자를 저장
        _pendingOperator = clicked.Content.ToString(); // 어떤 연산자인지 기억
        _startNewNumber = true; // 다음 숫자 입력은 새로 시작
    }

    // = 버튼: 저장된 값과 대기 중인 연산자로 실제 계산 실행
    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
        Calculate();
        _pendingOperator = null; // 계산 끝났으니 대기 연산자 초기화
        _startNewNumber = true;
    }

    // 실제 사칙연산을 수행하는 공통 로직 (OperatorButton_Click, EqualButton_Click이 같이 사용)
    private void Calculate()
    {
        if (_pendingOperator == null)
        {
            return; // 아직 연산자를 누른 적이 없으면 계산할 게 없음
        }

        double current = double.Parse(_display);
        double result = current; // 기본값(혹시 연산자가 이상한 값이면 그냥 현재 값 유지)

        // 저장된 연산자 문자열을 하나씩 비교해서 알맞은 계산을 고름
        if (_pendingOperator == "+")
        {
            result = _storedValue + current;
        }
        else if (_pendingOperator == "-")
        {
            result = _storedValue - current;
        }
        else if (_pendingOperator == "*")
        {
            result = _storedValue * current;
        }
        else if (_pendingOperator == "/")
        {
            if (current == 0)
            {
                result = double.NaN; // 0으로 나누기는 계산 불가 표시
            }
            else
            {
                result = _storedValue / current;
            }
        }

        _display = result.ToString();
        resultLabel.Content = _display;
        _storedValue = result; // 연속 계산(=을 여러 번 누르는 경우) 대비
    }

    // AC 버튼: 모든 상태를 처음(0)으로 되돌림
    private void AcButton_Click(object sender, RoutedEventArgs e)
    {
        _display = "0";
        _storedValue = 0;
        _pendingOperator = null;
        _startNewNumber = true;
        resultLabel.Content = _display;
    }

    // +/- 버튼: 현재 화면 숫자의 부호만 뒤집음
    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
        double current = double.Parse(_display);
        _display = (-current).ToString();
        resultLabel.Content = _display;
    }

    // % 버튼: 현재 화면 숫자를 100으로 나눔 (예: 50 -> 0.5)
    private void PercentageButton_Click(object sender, RoutedEventArgs e)
    {
        double current = double.Parse(_display);
        _display = (current / 100).ToString();
        resultLabel.Content = _display;
    }
}
