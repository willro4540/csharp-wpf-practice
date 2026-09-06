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

namespace WpfApp3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // ── 할 일 목록 ──────────────────────────────────────────────

    // "추가" 버튼: 입력창(todoInputBox)의 글자를 목록(todoListBox)에 한 줄 추가
    private void TodoAddButton_Click(object sender, RoutedEventArgs e)
    {
        string text = todoInputBox.Text;

        // 빈 칸이거나 공백만 입력했으면 추가하지 않음 (빈 할 일이 쌓이는 걸 방지)
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        // ListBox.Items는 "지금 목록에 표시된 항목들"을 담고 있는 상자.
        // 배열([])처럼 번호(인덱스)로 접근할 수 있지만, 배열과 다르게
        // Add()/Remove()로 항목을 자유롭게 늘리고 줄일 수 있음
        // (배열은 한 번 크기를 정하면 못 늘렸던 것 기억하시나요? 이건 그게 가능한 버전)
        todoListBox.Items.Add(text);

        // 추가 후 입력창은 비워서 다음 항목을 바로 입력할 수 있게 함
        todoInputBox.Text = "";
    }

    // "선택 삭제" 버튼: 목록에서 지금 클릭(선택)된 항목 하나를 지움
    private void TodoDeleteButton_Click(object sender, RoutedEventArgs e)
    {
        // SelectedItem: 사용자가 목록에서 클릭해 선택한 항목. 아무것도 선택 안 했으면 null
        if (todoListBox.SelectedItem == null)
        {
            return;
        }

        todoListBox.Items.Remove(todoListBox.SelectedItem);
    }

    // ── 연락처 ──────────────────────────────────────────────────

    // "추가" 버튼: 이름 + 전화번호 두 칸을 합쳐서 한 줄로 목록에 추가
    private void ContactAddButton_Click(object sender, RoutedEventArgs e)
    {
        string name = contactNameBox.Text;
        string phone = contactPhoneBox.Text;

        // 이름이나 전화번호 둘 중 하나라도 비어 있으면 추가하지 않음
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
        {
            return;
        }

        // 문자열 두 개를 " - "로 이어붙여서 "홍길동 - 010-1234-5678" 같은 한 줄을 만듦
        // (계산기에서 숫자를 화면에 이어붙일 때 썼던 += 방식과 같은 원리)
        string display = name + " - " + phone;
        contactListBox.Items.Add(display);

        contactNameBox.Text = "";
        contactPhoneBox.Text = "";
    }

    // "선택 삭제" 버튼: 연락처 목록에서 선택된 항목 하나를 지움
    private void ContactDeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (contactListBox.SelectedItem == null)
        {
            return;
        }

        contactListBox.Items.Remove(contactListBox.SelectedItem);
    }
}