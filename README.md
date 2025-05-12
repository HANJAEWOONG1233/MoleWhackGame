
# Whac‑A‑Mole 3D (Unity 2021.3.45)

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

필요 환경: Unity 2021.3.45 (이상) + Android Build Support 옵션

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


https://github.com/user-attachments/assets/b0f18cbf-469b-488d-803e-6c14a73a6aa6



## 사용 기술 및 에셋

*   Unity 2021.3.45 (C#)
*   TextMeshPro – 고해상도 UI 텍스트
*   Free Casual Game SFX Pack – 타격 & UI 사운드
*   PlayerPrefs – 오프라인 랭킹 저장


## 라이선스

이 프로젝트는 [MIT License](<YOUR_REPO_LICENSE_URL>)를 따릅니다. 자세한 내용은 `LICENSE` 파일을 확인하세요.




