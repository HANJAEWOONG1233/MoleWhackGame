
# Whac‑A‑Mole 3D (Unity 2021.1)

두더지를 잡고, 콤보를 쌓고, 기록을 갱신하세요! 이 저장소는 튜토리얼 시리즈를 따라 개발한 3D 두더지 잡기(Whac‑A‑Mole) 게임의 완성 프로젝트입니다. PC와 Android에서 모두 플레이할 수 있으며, 간단한 코드 베이스로 다양한 기능(콤보, 타이머, 세이브 데이터 랭킹 등)을 학습할 수 있습니다.

## 📋 목차

*   [주요 기능](#주요-기능)
*   [게임플레이](#게임플레이)
*   [설치 & 실행](#설치--실행)
*   [프로젝트 구조](#프로젝트-구조)
*   [커스터마이징](#커스터마이징)
*   [빌드(모바일)](#빌드모바일)
*   [완성 영상](#완성-영상)
*   [사용 기술 및 에셋](#사용-기술-및-에셋)
*   [기여](#기여)
*   [라이선스](#라이선스)

## 주요 기능

| 구분             | 설명                                                                                                |
| :--------------- | :-------------------------------------------------------------------------------------------------- |
| 다양한 두더지    | • 기본 (노란색) : +점수<br>• 빨간색 : −점수 & 콤보 초기화<br>• 파란색 : +게임 시간                         |
| 콤보 시스템      | 연속 타격 시 점수 배율 ↑ / 두더지 스폰 수 ↑                                                           |
| 타이머 & 카운트다운 | 3‑2‑1 카운트다운 후 제한 시간 플레이, 파란 두더지로 시간 연장                                            |
| 시각·청각 피드백 | 카메라 쉐이크, 파티클, 텍스트 팝업, 두더지별 SFX                                                        |
| 씬 관리          | Intro → Game → Game Over 자동 전환 & PlayerPrefs 로컬 랭킹 저장                                      |
| 모바일 컨트롤    | PC (마우스) / Android (터치) 동시 지원                                                                |

## 게임플레이

*   **LEFT‑CLICK / TAP**: 두더지 타격
*   **ESC (PC)**: 게임 종료
*   **R (PC)**: 게임 재시작

1.  카운트다운(3초) 후 게임이 시작됩니다.
2.  등장하는 두더지를 빠르게 눌러 잡습니다.
3.  콤보가 상승하면 점수 배율과 한 번에 나타나는 두더지 수가 증가합니다.
4.  제한 시간이 끝나면 Game Over 씬으로 이동, 로컬 랭킹이 기록·표시됩니다.

## 설치 & 실행

필요 환경: Unity 2021.1.7f1 (이상) + Android Build Support 옵션

1.  **저장소 클론**
    ```bash
    $ git clone <REPO_URL>
    ```
2.  **Unity 프로젝트 열기**
    Unity Hub 또는 Unity Editor에서 클론한 프로젝트 폴더를 열고 `Assets/Scenes/Intro.unity` 씬을 실행합니다.

### Android 빌드

1.  `File` → `Build Settings` 열기 → `Android` 선택 후 `Switch Platform`.
2.  `Player Settings` > `Company Name` & `Product Name` 수정.
3.  `Build` 버튼 → `.apk` 파일 생성 → 기기에 설치.
    > **Tip**: 설치 오류가 나는 경우, 기기의 Google Play Protect 설정에서 앱 검사를 일시 해제 후 다시 설치해 보세요.

## 프로젝트 구조
Use code with caution.
Markdown
Assets/
├─ Audio/ # SFX (Free Casual Game SFX Pack)
├─ Materials/ # 바닥·두더지·망치 등 머티리얼
├─ Prefabs/ # Mole, Hole, Hammer, Particle 이펙트
├─ Scenes/
│ ├─ Intro.unity # 타이틀 및 Press Any Key 씬
│ ├─ Game.unity # 메인 게임 플레이
│ └─ GameOver.unity# 결과 & 로컬 랭킹
├─ Scripts/
│ ├─ Gameplay/ # GameController, MoleFSM, Hammer, ...
│ ├─ UI/ # InGameTextViewer, FadeTMP, RankSystem
│ └─ Core/ # Movement3D, ObjectDetector 등
└─ Plugins/ # TextMeshPro 외 외부 패키지
## 커스터마이징

| 옵션               | 위치                                 | 설명                                         |
| :----------------- | :----------------------------------- | :------------------------------------------- |
| 두더지 스폰 확률   | `MoleSpawner.cs` → `spawnPercent[]`  | 기본: 노랑 85 / 빨강 10 / 파랑 5              |
| 콤보별 점수 배율   | `Hammer.cs` → `scoreMultiplier`      | `(1 + combo/10 × 0.5)` 공식 수정             |
| 최대 동시 스폰 수  | `GameController.cs` → `MaxSpawnMole` | 콤보 수치에 따라 자동 조정                   |
| 랭킹 길이          | `RankSystem.cs` → `MaxRankCount`     | 기본 10 개                                   |

> 변경 후 Unity Editor에서 Play 버튼을 눌러 바로 테스트할 수 있습니다.

## 빌드(모바일)

| 단계                  | 설명                                                                                   |
| :-------------------- | :------------------------------------------------------------------------------------- |
| **Switch Platform**   | `File` › `Build Settings` → Android 선택                                               |
| **Landscape Orientation** | `Player Settings` › `Resolution & Presentation` → Landscape Left                         |
| **APK 생성**          | `Build` 버튼 → 테스트 기기에서 설치                                                     |

> **Tip**: Play Protect 오류가 날 경우 Play Protect → 앱 검사 끄기 후 설치합니다.

## 완성 영상

| #   | 내용                 | 영상 링크     |
| :-- | :------------------- | :------------ |
| 1   | 구멍·두더지 프리팹 제작 | (coming‑soon) |
| 2   | 망치 & 타격 시스템   | (coming‑soon) |
| 3   | 스테이지 UI & 카운트다운 | (coming‑soon) |
| 4   | 다양한 두더지 타입 추가 | (coming‑soon) |
| 5   | 콤보 시스템 / 멀티 스폰 | (coming‑soon) |
| 6   | 씬 전환 / 모바일 빌드 | (coming‑soon) |

## 사용 기술 및 에셋

*   Unity 2021.1.7f1 (C#)
*   TextMeshPro – 고해상도 UI 텍스트
*   Free Casual Game SFX Pack – 타격 & UI 사운드
*   PlayerPrefs – 오프라인 랭킹 저장

## 기여

PR 및 이슈 환영합니다! 버그 리포트나 기능 제안 사항은 [Issues](<YOUR_REPO_ISSUES_URL>) 탭을 통해 남겨주세요.

## 라이선스

이 프로젝트는 [MIT License](<YOUR_REPO_LICENSE_URL>)를 따릅니다. 자세한 내용은 `LICENSE` 파일을 확인하세요.






# Unity Whac-A-Mole Game

https://github.com/user-attachments/assets/84876382-ec20-4f2f-92fc-6308e033b605

## 주요 기능

*   **기본 게임 플레이:** 구멍에서 나오는 두더지를 마우스 클릭으로 잡습니다.
*   **다양한 두더지 종류:**
    *   기본 두더지 (노란색): 점수 획득
    *   빨간 두더지: 점수 감소
    *   파란 두더지: 남은 게임 시간 증가
*   **점수 시스템:** 두더지를 타격하여 점수를 쌓습니다.
*   **콤보 시스템:** 연속 타격 성공 시 콤보가 쌓이며, 점수 배율이 증가합니다. (빨간 두더지 타격 또는 기본 두더지 놓칠 시 콤보 초기화)
*   **게임 타이머:** 제한 시간 내에 게임을 진행합니다.
*   **카운트다운 시작:** 게임 시작 전 카운트다운을 진행합니다.
*   **시각 및 청각 피드백:**
    *   두더지 타격 시 카메라 흔들림 효과
    *   타격 위치에 파티클 효과 발생
    *   점수/시간 증감 텍스트 팝업 표시
    *   두더지 종류별 다른 타격 사운드 재생
*   **동적 스폰:** 콤보 수치에 따라 한 번에 등장하는 두더지 수가 증가합니다.
*   **씬 관리:**
    *   Intro 씬: 게임 타이틀 및 시작 안내 (간단한 두더지 애니메이션 포함)
    *   Game 씬: 실제 게임 플레이 진행
    *   Game Over 씬: 최종 점수, 최대 콤보, 두더지 종류별 타격 횟수 및 로컬 랭킹 표시 (PlayerPrefs 사용)
*   **재시작 및 종료:** 게임 오버 씬에서 게임 재시작 또는 애플리케이션 종료 기능 제공
*   **모바일 빌드:** Android 플랫폼 빌드 및 실행 설정

## 프로젝트 실행 방법

1.  **필수 환경:** Unity 2021.1.7f1 또는 호환 가능한 버전이 설치되어 있어야 합니다. Android 플랫폼 빌드 지원이 설정되어 있어야 합니다.
2.  **프로젝트 클론:** 본 GitHub 저장소를 로컬 환경에 클론합니다.
    ```bash
    git clone [저장소_URL]
    ```
3.  **Unity에서 열기:** Unity Hub 또는 Unity Editor에서 클론한 프로젝트 폴더를 엽니다.
4.  **실행 또는 빌드:**
    *   Unity Editor 상단 메뉴에서 `File` > `Open Scene` 을 선택하여 `Assets/Scenes/Intro.unity` 씬을 연 후, Play 버튼을 눌러 게임을 실행할 수 있습니다.
    *   Android 기기에서 실행하려면, `File` > `Build Settings` 에서 `Android` 플랫폼을 선택하고 `Switch Platform` (필요시)을 클릭한 후, `Build` 버튼을 눌러 `.apk` 파일을 생성합니다. 생성된 `.apk` 파일을 기기로 옮겨 설치합니다.

## 사용 기술 및 에셋

*   Unity 2021.1.7f1
*   C#
*   TextMeshPro (UI 텍스트)
*   PlayerPrefs (로컬 랭킹 저장)
*   사운드 에셋: [튜토리얼에서 사용된 사운드 에셋 이름 또는 출처 명시, 예: Free Casual Game SFX Pack from Asset Store]
