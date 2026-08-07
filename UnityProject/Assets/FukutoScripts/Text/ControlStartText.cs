using TMPro;
using UnityEngine;

/// <summary>
/// コントロールスタートテキスト
/// 
/// ゲーム開始時のテキストクラス
/// </summary>
public class ControlStartText : TextBase
{
    [SerializeField] private float fadeSpeed = 1f; // フェードスピード
    private bool isOfferToStart = false; // スタートの申請フラグ
    [SerializeField] private float maxEffectTime = 0.8f; // スタートの演出時間
    private float currentEffectTime = 0; // 現在のエフェクト時間
    private bool isFinishedEffect = false; // エフェクト終了フラグ

    void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateText();
    }

    // テキストを更新する関数
    protected override void UpdateText()
    {
        // スタートのオファーがなかったら
        if(!isOfferToStart)
        {
            float alpha = Mathf.PingPong(Time.time * fadeSpeed, 1f);
            Color c = tmpText.color;
            c.a = alpha;
            tmpText.color = c;
            return;
        }
        else
        {
            // 演出が終了した場合
            if(maxEffectTime <= currentEffectTime) 
            {
                isFinishedEffect = true;
                return; 
            }

            fadeSpeed = 10f;
            float alpha = Mathf.PingPong(Time.time * fadeSpeed, 1f);
            Color c = tmpText.color;
            c.a = alpha;
            tmpText.color = c;
            // 演出フレームを進める
            currentEffectTime += Time.deltaTime;
        }

    }

    // スタートの申請フラグを設定する関数
    public void SetOfferToStart()
    {
        isOfferToStart = true; 
    }

    // 演出終了フラグを返す関数
    public bool GetFinishedEffect()
    { 
        return isFinishedEffect; 
    }
}
