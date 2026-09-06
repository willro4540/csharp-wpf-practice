# C# / WPF 연습

교수님 과제(WPF → To-List / 연락처)를 계기로 진행 중인 WPF 실습 코드 저장소입니다.
학습 로그 자체는 별도 저장소([`personal-study-method-skill`](https://github.com/willro4540/personal-study-method-skill),
비공개, `csharp_study_procedure.md`)에서 관리합니다.

## ⚠️ 이 저장소의 현재 상태 (2026-09-06)

원래 계획은 교실 컴퓨터(`C:\Users\user\C#연습`)의 `WpfApp1`(Hello World)/`WpfApp2`(계산기)/
`WpfApp3`(To-List+연락처, 예정)를 그대로 옮기는 것이었습니다. 하지만 그 세션이 토큰
초과로 끊기면서 실제 파일을 옮기지 못했고, 사용자가 남긴 대화 백업만으로 다른 컴퓨터에서
**`WpfApp2`(계산기)만 코드를 재구성**해 여기 올렸습니다.

- ✅ `WpfApp2` — 백업에 남아있던 XAML 버튼 구성 + `MainWindow.xaml.cs` 전체 로직을 그대로
  재현. `dotnet build` 0 오류, 실행 프로세스 정상 기동까지 확인함(이 컴퓨터 기준).
  **단, 원본 파일 자체를 옮긴 게 아니라 대화 로그에서 재구성한 것**이라 교실 컴퓨터의
  실제 `WpfApp2`와 100% 동일하지 않을 수 있음 — 특히 `Window`/`Grid`의 정확한 스타일,
  크기, 색상 등은 백업에 남아있지 않아 임의로 채운 부분입니다. 버튼 이름·`Content`·
  `Click` 핸들러 연결, 그리고 `.cs`의 계산 로직은 백업에 있는 그대로입니다.
- ❌ `WpfApp1`(Hello World 테스트) — 백업에는 "버튼 하나 + `MessageBox.Show("Hello World")`"
  라는 설명만 있고 실제 코드는 없어서, 추측으로 만들지 않고 비워뒀습니다. 교실 컴퓨터의
  실제 파일로 나중에 교체 필요.
- ❌ `WpfApp3`(To-List + 연락처) — 아직 시작되지 않은 프로젝트라 없음.

교실 컴퓨터에 다시 갈 기회가 있으면, 그쪽의 실제 `WpfApp1`/`WpfApp2` 폴더로 이 저장소의
내용을 덮어써서 진짜 원본과 동기화하는 걸 권장합니다.

## 참고 자료

좋은 예시 코드 리서치는 `personal-study-method-skill` 저장소의 `classroom-pc` 브랜치,
`WPF_좋은예시_리서치_2026-09-06.md`를 참고하세요.
