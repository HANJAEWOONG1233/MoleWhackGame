using System.Collections;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [Header("▶ Hammer 이동 범위")]
    [Tooltip("망치가 올라갈 최대 Y 위치")]
    [SerializeField] private float maxY;

    [Tooltip("망치가 내려올 최소 Y 위치")]
    [SerializeField] private float minY;

    [Header("▶ 타격 이펙트")]
    [Tooltip("두더지 타격 효과 프리팹")]
    [SerializeField] private GameObject moleHitEffectPrefab;

    [Header("▶ 사운드 클립")]
    [Tooltip("두더지 타격 시 재생할 오디오 클립 배열 (Normal=0, Red=1, Blue=2)")]
    [SerializeField] private AudioClip[] audioClips;

    [Header("▶ 타격 텍스트 출력")]
    [Tooltip("타격된 두더지 위치에 점수/시간 텍스트 출력")]
    [SerializeField] private MoleHitTextViewer[] moleHitTextViewer;

    [Header("▶ 점수 관리")]
    [Tooltip("점수·시간 관리를 위한 GameController")]
    [SerializeField] private GameController gameController;

    [Header("▶ Raycast 이벤트")]
    [Tooltip("ObjectDetector 컴포넌트 (마우스 클릭 감지기)")]
    [SerializeField] private ObjectDetector objectDetector;

    [Header("▶ 내부 컴포넌트 참조")]
    [Tooltip("Hammer 이동 제어용")]
    [SerializeField] private Movement3D movement3D;
    [Tooltip("사운드 재생용 AudioSource")]
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (movement3D == null)  movement3D = GetComponent<Movement3D>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();

        objectDetector.raycastEvent.AddListener(OnHit);
    }

    private void OnHit(Transform target)
    {
        if (!target.CompareTag("Mole")) return;
        var mole = target.GetComponent<MoleFSM>();
        if (mole == null || mole.CurrentState == MoleState.UnderGround) return;

        // 망치 위치 이동
        transform.position = new Vector3(target.position.x, minY, target.position.z);

        // 타격 이펙트 생성 및 색상 적용
        var effect = Instantiate(moleHitEffectPrefab, target.position, Quaternion.identity);
        var main  = effect.GetComponent<ParticleSystem>().main;
        main.startColor = mole.GetComponent<MeshRenderer>().material.color;

        // 점수·콤보·통계·사운드 처리
        MoleHitProcess(mole);

        // 두더지 지하 상태로 전환
        mole.ChangeState(MoleState.UnderGround);

        // 카메라 흔들기
        ShakeCamera.Instance.OnShakeCamera(0.1f, 0.1f);

        // 망치 원위치 복귀
        StartCoroutine(MoveUp());
    }

    private void MoleHitProcess(MoleFSM mole)
    {
        int index = mole.MoleIndex;

        if (mole.MoleType == MoleType.Normal)
        {
            // 기본 두더지 타격 횟수 증가
            gameController.NormalMoleHitCount++;

            // 콤보 증가 및 점수 계산
            gameController.Combo += 1;
            const int baseScore = 50;
            float multiplier = 1 + (gameController.Combo / 10f) * 0.5f;
            int gained = (int)(baseScore * multiplier);
            gameController.Score += gained;

            // 텍스트 표시
            moleHitTextViewer[index].OnHit($"Score +{gained}", Color.white);
        }
        else if (mole.MoleType == MoleType.Red)
        {
            // 빨간 두더지 타격 횟수 증가
            gameController.RedMoleHitCount++;

            // 콤보 초기화 및 벌점
            gameController.Combo = 0;
            gameController.Score += 300;

            moleHitTextViewer[index].OnHit("Score -300", Color.red);
        }
        else if (mole.MoleType == MoleType.Blue)
        {
            // 파란 두더지 타격 횟수 증가
            gameController.BlueMoleHitCount++;

            // 콤보 유지, 시간 보너스
            gameController.Combo += 1;
            gameController.CurrentTime += 3f;

            moleHitTextViewer[index].OnHit("Time +3", Color.blue);
        }

        // 사운드 재생
        PlaySound((int)mole.MoleType);
    }

    private void PlaySound(int index)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    private IEnumerator MoveUp()
    {
        movement3D.MoveTo(Vector3.up);
        while (true)
        {
            if (transform.position.y >= maxY)
            {
                movement3D.MoveTo(Vector3.zero);
                yield break;
            }
            yield return null;
        }
    }
}
