using System.Collections;
using UnityEngine;

// 두더지 상태 열거형
public enum MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown }

// 두더지 종류 (기본, 점수 –, 시간 +)
public enum MoleType { Normal = 0, Red, Blue }

public class MoleFSM : MonoBehaviour
{
    [Header("▶ 콤보 초기화를 위한 GameController")]
    [SerializeField] private GameController gameController;

    [SerializeField]
    private float waitTimeOnGround;    // 지면에 올라와서 내려가기까지 기다리는 시간

    [SerializeField]
    private float limitMinY;           // 내려갈 수 있는 최소 y 위치

    [SerializeField]
    private float limitMaxY;           // 올라올 수 있는 최대 y 위치

    [SerializeField]
    private Movement3D movement3D;     // 위/아래 이동을 위한 Movement3D

    private MeshRenderer meshRenderer; // 두더지 색상 변경용
    private MoleType moleType;         // 현재 두더지 종류 저장
    private Color defaultColor;        // 기본 색상 저장

    // 두더지의 현재 상태 (set은 MoleFSM 클래스 내부에서만)
    public MoleState MoleState { private set; get; }
    // 기존 CurrentState 사용 코드 호환용
    public MoleState CurrentState => MoleState;

    // 두더지 종류 프로퍼티 (MoleType에 따라 색 변경)
    public MoleType MoleType
    {
        set
        {
            moleType = value;
            switch (moleType)
            {
                case MoleType.Normal: meshRenderer.material.color = defaultColor; break;
                case MoleType.Red:    meshRenderer.material.color = Color.red;      break;
                case MoleType.Blue:   meshRenderer.material.color = Color.blue;     break;
            }
        }
        get => moleType;
    }

    // 두더지가 배치된 인덱스 (왼쪽 상단부터 0순번)
    [field: SerializeField]
    public int MoleIndex { private set; get; }

    private void Awake()
    {
        movement3D   = GetComponent<Movement3D>();
        meshRenderer = GetComponent<MeshRenderer>();
        defaultColor = meshRenderer.material.color;  // 두더지의 초기 색 저장

        ChangeState(MoleState.UnderGround);
    }

    public void ChangeState(MoleState newState)
    {
        StopCoroutine(MoleState.ToString());
        MoleState = newState;
        StartCoroutine(MoleState.ToString());
    }

    private IEnumerator UnderGround()
    {
        movement3D.MoveTo(Vector3.zero);
        transform.position = new Vector3(transform.position.x, limitMinY, transform.position.z);
        yield return null;
    }

    private IEnumerator OnGround()
    {
        movement3D.MoveTo(Vector3.zero);
        transform.position = new Vector3(transform.position.x, limitMaxY, transform.position.z);

        yield return new WaitForSeconds(waitTimeOnGround);
        ChangeState(MoleState.MoveDown);
    }

    private IEnumerator MoveUp()
    {
        movement3D.MoveTo(Vector3.up);
        while (true)
        {
            if (transform.position.y >= limitMaxY)
            {
                ChangeState(MoleState.OnGround);
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator MoveDown()
    {
        // 이동 방향: 아래
        movement3D.MoveTo(Vector3.down);

        // limitMinY에 도달할 때까지 대기
        while (true)
        {
            if (transform.position.y <= limitMinY)
                break;
            yield return null;
        }

        // 망치에 타격 당하지 않고 자연스럽게 구멍으로 돌아갈 때
        // Normal 타입이면 콤보 초기화
        if (moleType == MoleType.Normal)
            gameController.Combo = 0;

        // UnderGround 상태로 전환
        ChangeState(MoleState.UnderGround);
    }
}
