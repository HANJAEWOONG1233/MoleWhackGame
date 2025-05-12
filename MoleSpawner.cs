using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<MoleFSM> moles = new List<MoleFSM>();    // 맵에 존재하는 두더지들

    [SerializeField]
    private float spawnTime;                              // 두더지 등장 주기

    // 두더지 등장 확률 (Normal : 85%, Red : 10%, Blue : 5%)
    private int[] spawnPercents = new int[] { 85, 10, 5 };

    // 한 번에 등장시킬 최대 두더지 수 (Inspector 노출, 외부 쓰기/읽기 가능)
    [field: SerializeField]
    public int MaxSpawnMole { get; set; } = 1;

    public void Setup()
    {
        // 코루틴 직통 호출
        StartCoroutine(SpawnMole());
    }

    private IEnumerator SpawnMole()
    {
        while (true)
        {
            if (moles.Count == 0)
            {
                yield return null;
                continue;
            }

            // 1) 우선 한 마리 랜덤으로 스폰
            int index = Random.Range(0, moles.Count);
            moles[index].MoleType = SpawnMoleType();
            moles[index].ChangeState(MoleState.MoveUp);

            // 2) 추가로 MaxSpawnMole 만큼 더 스폰
            StartCoroutine(SpawnMultiMoles());

            // 다음 스폰까지 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    // 여러 마리 동시 스폰 코루틴
    private IEnumerator SpawnMultiMoles()
    {
        // 0~moles.Count-1까지 중복 없이 섞은 인덱스 배열 생성
        int[] indexes = RandomNumerics(moles.Count, moles.Count);
        int spawned = 0;
        int cursor = 0;

        // 배열 끝까지 돌면서 UnderGround 상태인 두더지만 스폰
        while (cursor < indexes.Length)
        {
            var mole = moles[indexes[cursor]];
            if (mole.MoleState == MoleState.UnderGround)
            {
                mole.MoleType = SpawnMoleType();
                mole.ChangeState(MoleState.MoveUp);
                spawned++;

                // 약간의 간격 주고
                yield return new WaitForSeconds(0.1f);

                // 최대치에 도달하면 끝
                if (spawned >= MaxSpawnMole)
                    yield break;
            }

            cursor++;
            yield return null;
        }
    }

    // 단일 두더지 타입 결정 로직
    private MoleType SpawnMoleType()
    {
        int percent = Random.Range(0, 100);
        float cum = 0f;

        for (int i = 0; i < spawnPercents.Length; i++)
        {
            cum += spawnPercents[i];
            if (percent < cum)
                return (MoleType)i;
        }

        return MoleType.Normal;
    }

    // 0~maxCount-1 사이의 숫자 중 n개를 중복 없이 랜덤 추출
    private int[] RandomNumerics(int maxCount, int n)
    {
        int[] pool = new int[maxCount];
        int[] result = new int[n];

        for (int i = 0; i < maxCount; i++)
            pool[i] = i;

        for (int i = 0; i < n; i++)
        {
            int pick = Random.Range(0, maxCount);
            result[i] = pool[pick];
            pool[pick] = pool[maxCount - 1];
            maxCount--;
        }

        return result;
    }
}
