# TCP 소켓 스터디 노트 — 교수님 강의(10~15강) 이해 보강용

`basiclike.tistory.com`의 "8. TCP\IP" 관련 시리즈 중, `TcpListener`/`TcpClient` +
`async`/`await` 도입부(10강~15강)를 따라가다가 개념이 헷갈려서, 완전 초보 기준으로
처음부터 다시 풀어쓴 보강 자료입니다. 티스토리 HTML 편집 모드에 그대로 붙여넣을 수
있는 형태로 작성했습니다.

## 구성

| 파일 | 내용 |
|---|---|
| `tistory_part1_async_basics.html` | 1부 — 클래스/메서드 아주 짧은 복습, "스레드"가 뭔지부터 정의, 동기 vs 비동기 개념(카페 번호표·세탁기 비유 + SVG 다이어그램), "async=병렬"이라는 흔한 오해 정정, 이해도 확인 질문 |
| `tistory_part2_tcplistener_walkthrough.html` | 2부 — 10~15강 전체 로드맵 표, [11강](https://basiclike.tistory.com/240) 코드 3줄을 한 줄씩 완전 분해(IP/포트 아파트 비유 다이어그램, 실행 흐름도), `using System.Net.Sockets;`의 의미, "실행하면 실제로 뭐가 일어나는지" 상상 실습, 1부 퀴즈 정답 풀이 |

## 참고 원문 (실제 강의)

- [10강. C# TCPClient, TCPListener](https://basiclike.tistory.com/239)
- [11강. TCPListener 서버 1단계](https://basiclike.tistory.com/240) ← 이번 노트가 다루는 지점
- [12강. TCPListener 서버 2단계](https://basiclike.tistory.com/241)
- [13강. TCPListener 서버 3단계](https://basiclike.tistory.com/297)
- [14강. TCPListener 서버 4단계](https://basiclike.tistory.com/298)
- [15강. TCPListener 서버 5단계](https://basiclike.tistory.com/32)

## 이 노트가 특정 상용 서비스와 무관함

이 폴더는 교수님의 공개 교육 블로그 강의를 따라가며 개인적으로 이해를 보강하기 위해
직접 작성한 설명 자료입니다. 강의 원문의 코드/저작물을 그대로 복사하지 않고, 핵심
개념(3줄 코드)만 짧게 인용해 독자적으로 다시 설명했습니다.
