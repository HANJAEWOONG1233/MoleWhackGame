using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameTextViewer : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private TextMeshProUGUI textScore;
    [SerializeField]
    private TextMeshProUGUI textPlayTime;
    [SerializeField]
    private Slider sliderPlayTime;
    [SerializeField]
    private TextMeshProUGUI textCombo;    // 콤보 표시용 텍스트

    private void Update()
    {
        // 점수 업데이트
        textScore.text = "Score " + gameController.Score;
        // 콤보 업데이트
        textCombo.text  = "Combo " + gameController.Combo;
        // 남은 시간 텍스트 및 슬라이더 업데이트
        textPlayTime.text      = gameController.CurrentTime.ToString("F1");
        sliderPlayTime.value   = gameController.CurrentTime / gameController.MaxTime;
    }
}
