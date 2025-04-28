
# Unity  기반 **Mole Whack Game** 🎯  
(두더지 잡기 게임)

> 20231081 한재웅 &nbsp;|&nbsp; Software Principles / Software Fundamentals Project

---

## 📖 프로젝트 개요
Unity 엔진으로 클래식 아케이드 게임 ‘두더지 잡기(Whac-A-Mole)’를 재해석했습니다.  
제한 시간 내 구멍에서 무작위로 등장하는 두더지를 클릭(또는 터치)해 점수를 획득하며,  
**다양한 타입**의 두더지와 **콤보 시스템**, **시청각 피드백**(파티클·카메라 흔들림·사운드)이 핵심 재미 요소입니다. :contentReference[oaicite:2]{index=2}&#8203;:contentReference[oaicite:3]{index=3}  

## 🎯 목표
| 단계 | 설명 |
|------|------|
| **Minimum Viable Product** | • 기본 두더지 스폰/히트 & 점수 집계<br>• 제한 시간 UI |
| **High-Level Goal** | • 두더지 타입별 스킬 (점수 감소, 시간 증가 등)<br>• 연속 히트 콤보 & 보너스<br>• 랭킹 시스템 + 최고 점수 저장 |

## 🛠️ 필요 기술 스택
- Unity **2022 LTS** 이상 (URP 권장)
- C#  
- Git / GitHub
- (선택) Visual Studio Code + Rider

## ⚙️ 구현 방법
1. **게임 루프 설계**  
   - `GameManager`가 상태(FSM) 전환 관리  
   - `MoleSpawner` 코루틴으로 스폰 타이밍 제어  
2. **두더지 타입 시스템**  
   ```csharp
   public enum MoleType { Normal, Red, Blue, TimeBoost }
