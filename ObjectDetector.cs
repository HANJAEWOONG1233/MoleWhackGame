using UnityEngine;
using UnityEngine.Events;

public class ObjectDetector : MonoBehaviour
{
    [System.Serializable]
    public class RaycastEvent : UnityEvent<Transform> {} 
    // 이벤트 정의: Transform 파라미터를 받는 UnityEvent

    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent(); 
    // 외부에 보이진 않지만 내부에서 사용할 이벤트 인스턴스

    private Camera mainCamera;      // 사용할 카메라
    private Ray ray;                // 생성된 광선
    private RaycastHit hit;         // 광선에 부딪힌 대상 정보

    private void Awake()
    {
        mainCamera = Camera.main;  // MainCamera 태그가 붙은 카메라 자동 참조
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // 오브젝트에 맞았으면 이벤트 발동
                raycastEvent.Invoke(hit.transform);
            }
        }
    }

}
