using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    // 싱글톤 처리를 위한 instance 변수 선언
    private static ShakeCamera instance;
    // 외부에서 Get 접근만 가능하도록 Instance 프로퍼티 선언
    public static ShakeCamera Instance => instance;

    private float shakeTime;
    private float shakeIntensity;

    /// <summary>
    /// Main Camera 오브젝트에 컴포넌트로 적용하면
    /// 게임 실행할 때 메모리 할당 / 생성자 메소드 실행
    /// 이 때 자기 자신의 정보를 instance 변수에 저장
    /// </summary>
    public ShakeCamera()
    {
        instance = this;
    }

    /// <summary>
    ///— 외부에서 카메라 흔들림을 조작할 때 호출하는 메소드  
    ///— ex) OnShakeCamera(1);      => 1초간 0.1의 세기로 흔들림  
    ///— ex) OnShakeCamera(0.5f, 1); => 0.5초간 1의 세기로 흔들림  
    /// </summary>
    /// <param name="shakeTime">카메라 흔들림 지속 시간 (설정하지 않으면 default 1.0f)</param>
    /// <param name="shakeIntensity">메카 흔들림 세기 (설정하지 않으면 default 0.1f)</param>
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }

    /// <summary>
    /// 카메라를 shakeTime동안 shakeIntensity의 세기로 흔드는 코루틴 함수
    /// </summary>
    private IEnumerator ShakeByPosition()
    {
        // 흔들리기 직전의 시작 위치 (흔들림 종료 후 돌아올 위치)
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            // 특정 축만 변경하려면 아래 코드 이용 (이동하지 않을 축은 0 값 사용)
            // float x = Random.Range(-1f, 1f);
            // float y = Random.Range(-1f, 1f);
            // float z = Random.Range(-1f, 1f);
            // transform.position = startPosition + new Vector3(x, y, z) * shakeIntensity;

            // 초기 위치로부터 r 범위(Size 1) * shakeIntensity 범위에서 카메라 위치 변동
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // 시간 감소
            shakeTime -= Time.deltaTime;

            yield return null;
        }

        // 흔들림 종료 후 원위치 복귀
        transform.position = startPosition;
    }

}
