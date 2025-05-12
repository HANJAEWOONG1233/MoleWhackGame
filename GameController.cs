using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CountDown countDown;

    [SerializeField]
    private MoleSpawner moleSpawner;

    // 점수
    private int score;
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    // 콤보 및 최대 콤보
    private int combo;
    public int Combo
    {
        set
        {
            combo = Mathf.Max(0, value);

            // 콤보에 따라 최대 동시 등장 두더지 수 조정 (콤보 0~70까지만)
            if (combo <= 70)
                moleSpawner.MaxSpawnMole = 1 + (combo + 10) / 20;

            // 최대 콤보 갱신
            if (combo > MaxCombo)
                MaxCombo = combo;
        }
        get => combo;
    }

    // 통계용 프로퍼티
    public int MaxCombo             { private set; get; }
    public int NormalMoleHitCount   { set; get; }
    public int RedMoleHitCount      { set; get; }
    public int BlueMoleHitCount     { set; get; }

    // 남은 시간 (Inspector에서 설정, 외부는 읽기만)
    [field: SerializeField]
    public float MaxTime { private set; get; }

    private float currentTime;
    public float CurrentTime
    {
        set => currentTime = Mathf.Clamp(value, 0, MaxTime);
        get => currentTime;
    }

    private void Start()
    {
        countDown.StartCountDown(GameStart);
    }

    private void GameStart()
    {
        moleSpawner.Setup();
        StartCoroutine(OnTimeCount());
    }

    private IEnumerator OnTimeCount()
    {
        CurrentTime = MaxTime;

        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            yield return null;
        }

        // 시간이 다 되면 게임 오버 처리
        GameOver();
    }

    private void GameOver()
    {
        // 지금까지의 기록을 PlayerPrefs에 저장
        PlayerPrefs.SetInt("CurrentScore", Score);
        PlayerPrefs.SetInt("CurrentMaxCombo", MaxCombo);
        PlayerPrefs.SetInt("CurrentNormalMoleHitCount", NormalMoleHitCount);
        PlayerPrefs.SetInt("CurrentRedMoleHitCount", RedMoleHitCount);
        PlayerPrefs.SetInt("CurrentBlueMoleHitCount", BlueMoleHitCount);

        // GameOver 씬으로 전환
        SceneManager.LoadScene("GameOver");
    }
}
