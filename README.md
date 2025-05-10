# Unity Whac-A-Mole Game

고박사님의 유니티 튜토리얼 시리즈를 따라 만든 간단한 두더지 잡기 게임 프로젝트입니다. 게임의 기본 메커니즘부터 UI, 사운드, 점수 시스템, 모바일 빌드 설정까지 유니티를 활용한 게임 개발 기초를 배울 수 있습니다.

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

## 스크린샷

<!-- Intro 씬 스크린샷Placeholder -->
**Intro Scene**
![Intro Scene Screenshot](path/to/intro_scene_screenshot.png)

<!-- 게임 플레이 스크린샷 Placeholder 1 -->
**Gameplay**
![Gameplay Screenshot 1](path/to/gameplay_screenshot_1.png)

<!-- 게임 플레이 스크린샷 Placeholder 2 (다른 색 두더지 또는 효과 포함) -->
**Gameplay with Effects**
![Gameplay Screenshot 2](path/to/gameplay_screenshot_2.png)

<!-- Game Over 씬 스크린샷 Placeholder -->
**Game Over Scene**
![Game Over Scene Screenshot](path/to/game_over_scene_screenshot.png)

## 사용 기술 및 에셋

*   Unity 2021.1.7f1
*   C#
*   TextMeshPro (UI 텍스트)
*   PlayerPrefs (로컬 랭킹 저장)
*   사운드 에셋: [튜토리얼에서 사용된 사운드 에셋 이름 또는 출처 명시, 예: Free Casual Game SFX Pack from Asset Store]
