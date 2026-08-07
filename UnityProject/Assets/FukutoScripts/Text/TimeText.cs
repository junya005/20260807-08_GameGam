using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// タイムテキスト
/// 
/// 時間テキストのクラス
public class TimeText : TextBase
{
    private string timeText; // 時間のテキスト
    private int currentTime; // 現在の時間
    [SerializeField]CountDownTime countDownTime; // カウントダウンのスクリプト

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    // テキストを更新する関数
    protected override void UpdateText()
    {
        // 現在の時間を取得
        currentTime = countDownTime.GetCurrenTime();
        // 時間を文字列に変換
        timeText = currentTime.ToString();
        // テキストを更新
        tmpText.text = timeText;
    }
}
