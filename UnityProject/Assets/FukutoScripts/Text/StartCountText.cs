using TMPro;
using UnityEngine;


/// <summary>
/// スタートカウントテキスト
/// 
/// 開始カウントテキストスクリプト
/// </summary>
public class StartCountText : TextBase
{
    private string countText; // 時間のテキスト
    private string START = "START!";
    private int currentTime; // 現在の時間
    private bool isInactive; // 非アクティブのフラグ
    private float inactiveCount = 0f;
    [SerializeField] private StartCount startCount; // 開始カウント
    [SerializeField] private CountDownTime countDownTime;
    [SerializeField] private GameObject textTime;

    private void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateText();
        if(isInactive)
        {
            if(1.0f < inactiveCount)
            {
                InactiveGameObject();
            }
        }
    }

    protected override void UpdateText()
    {
        // 現在の時間を取得
        currentTime = startCount.GetCurrenTime();
        // 時間を文字列に変換
        countText = currentTime.ToString();

        // 時間が0だったら
        if (currentTime == 0)
        {
            countText = START;
            isInactive = true;
            inactiveCount += Time.deltaTime;
        }
        // テキストを更新
        tmpText.text = countText;
    }

    private void InactiveGameObject()
    {
        countDownTime.SetApplyCount();
        textTime.SetActive(true);
        gameObject.SetActive(false);
    }
}
