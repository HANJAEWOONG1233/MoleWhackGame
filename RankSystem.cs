using System.Collections;
using UnityEngine;
using TMPro;

public class RankSystem : MonoBehaviour
{
    [System.Serializable]
    public struct RankData
    {
        public int score;
        public int maxCombo;
        public int normalMoleHitCount;
        public int redMoleHitCount;
        public int blueMoleHitCount;
    }

    [Header("▶ 랭크 표시 설정")]
    [SerializeField] private int maxRankCount = 10;
    [SerializeField] private GameObject textPrefab = null;
    [SerializeField] private Transform panelRankInfo = null;

    private RankData[] rankDataArray;
    private int currentIndex = -1;

    private void Awake()
    {
        rankDataArray = new RankData[maxRankCount];

        LoadRankData();
        CompareRank();
        SortRankDataByScore();         // ✅ 점수 기준 정렬 추가
        PrintRankData();
        SaveRankData();
    }

    private void LoadRankData()
    {
        for (int i = 0; i < maxRankCount; ++i)
        {
            rankDataArray[i].score              = PlayerPrefs.GetInt("RankScore" + i);
            rankDataArray[i].maxCombo           = PlayerPrefs.GetInt("RankMaxCombo" + i);
            rankDataArray[i].normalMoleHitCount = PlayerPrefs.GetInt("RankNormalMoleHitCount" + i);
            rankDataArray[i].redMoleHitCount    = PlayerPrefs.GetInt("RankRedMoleHitCount" + i);
            rankDataArray[i].blueMoleHitCount   = PlayerPrefs.GetInt("RankBlueMoleHitCount" + i);
        }
    }

    private void CompareRank()
    {
        RankData currentData = new RankData
        {
            score              = PlayerPrefs.GetInt("CurrentScore"),
            maxCombo           = PlayerPrefs.GetInt("CurrentMaxCombo"),
            normalMoleHitCount = PlayerPrefs.GetInt("CurrentNormalMoleHitCount"),
            redMoleHitCount    = PlayerPrefs.GetInt("CurrentRedMoleHitCount"),
            blueMoleHitCount   = PlayerPrefs.GetInt("CurrentBlueMoleHitCount")
        };

        // 삽입 위치 탐색 및 밀어내기
        for (int i = 0; i < maxRankCount; ++i)
        {
            if (currentData.score >= rankDataArray[i].score)
            {
                for (int j = maxRankCount - 1; j > i; --j)
                    rankDataArray[j] = rankDataArray[j - 1];

                rankDataArray[i] = currentData;
                currentIndex = i;
                return;
            }
        }
    }

    // ✅ 점수 기준 내림차순 정렬
    private void SortRankDataByScore()
    {
        System.Array.Sort(rankDataArray, (a, b) => b.score.CompareTo(a.score));
    }

    private void PrintRankData()
    {
        for (int i = 0; i < maxRankCount; ++i)
        {
            Color color = (IsCurrentRank(rankDataArray[i])) ? Color.yellow : Color.white;

            SpawnText((i + 1).ToString(), color);
            SpawnText(rankDataArray[i].score.ToString(), color);
            SpawnText(rankDataArray[i].maxCombo.ToString(), color);
            SpawnText(rankDataArray[i].normalMoleHitCount.ToString(), color);
            SpawnText(rankDataArray[i].redMoleHitCount.ToString(), color);
            SpawnText(rankDataArray[i].blueMoleHitCount.ToString(), color);
        }
    }

    // ✅ 현재 점수인지 여부 판단
    private bool IsCurrentRank(RankData data)
    {
        return
            data.score              == PlayerPrefs.GetInt("CurrentScore") &&
            data.maxCombo           == PlayerPrefs.GetInt("CurrentMaxCombo") &&
            data.normalMoleHitCount == PlayerPrefs.GetInt("CurrentNormalMoleHitCount") &&
            data.redMoleHitCount    == PlayerPrefs.GetInt("CurrentRedMoleHitCount") &&
            data.blueMoleHitCount   == PlayerPrefs.GetInt("CurrentBlueMoleHitCount");
    }

    private void SpawnText(string print, Color color)
    {
        GameObject clone = Instantiate(textPrefab, panelRankInfo);
        clone.transform.localScale = Vector3.one;

        var text = clone.GetComponent<TextMeshProUGUI>();
        text.text = print;
        text.color = color;
    }

    private void SaveRankData()
    {
        for (int i = 0; i < maxRankCount; ++i)
        {
            PlayerPrefs.SetInt("RankScore" + i, rankDataArray[i].score);
            PlayerPrefs.SetInt("RankMaxCombo" + i, rankDataArray[i].maxCombo);
            PlayerPrefs.SetInt("RankNormalMoleHitCount" + i, rankDataArray[i].normalMoleHitCount);
            PlayerPrefs.SetInt("RankRedMoleHitCount" + i, rankDataArray[i].redMoleHitCount);
            PlayerPrefs.SetInt("RankBlueMoleHitCount" + i, rankDataArray[i].blueMoleHitCount);
        }
    }
}
