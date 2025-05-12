using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScenario : MonoBehaviour
{
    [SerializeField]
    private Movement3D[] movementMoles;    // 두더지들을 위로 이동시키기 위한 Movement3D

    [SerializeField]
    private GameObject[] textMoles;        // 두더지 색상에 따라 획득 가능한 효과 출력 Text

    [SerializeField]
    private GameObject textPressAnyKey;    // "Press Any Key" 출력 Text

    [SerializeField]
    private float maxY = 1.5f;             // 두더지가 올라올 수 있는 최대 높이

    private int currentIndex = 0;          // 두더지 순서대로 등장하도록 순번 관리
    private bool canLoadGame = false;      // 아무 키 입력 활성화 여부

    private void Awake()
    {
        StartCoroutine("Scenario");
    }

    private void Update()
    {
        // 모든 연출 끝난 뒤 아무 키 누르면 "Game" 씬 로드
        if (canLoadGame && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Game");  // 정확한 씬 이름 사용
        }
    }

    private IEnumerator Scenario()
    {
        // 두더지 Normal → Red → Blue 순서대로 등장
        while (currentIndex < movementMoles.Length)
        {
            yield return StartCoroutine("MoveMole");
        }

        // "Press Any Key" 텍스트 출력
        textPressAnyKey.SetActive(true);
        canLoadGame = true;  // 입력 가능 상태 전환
    }

    private IEnumerator MoveMole()
    {
        movementMoles[currentIndex].MoveTo(Vector3.up);

        // 목표 높이에 도달할 때까지 대기
        while (true)
        {
            if (movementMoles[currentIndex].transform.position.y >= maxY)
            {
                movementMoles[currentIndex].MoveTo(Vector3.zero);
                break;
            }
            yield return null;
        }

        // 텍스트 활성화
        textMoles[currentIndex].SetActive(true);
        currentIndex++;
        yield return null;
    }
}
