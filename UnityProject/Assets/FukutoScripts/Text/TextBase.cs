using TMPro;
using UnityEngine;

/// <summary>
/// テキストベース
/// 
/// テキストスクリプトの基底クラス
/// </summary>
public abstract class TextBase : MonoBehaviour
{
    protected TextMeshProUGUI tmpText; // テキストメッシュプロのコンポーネント
    protected bool isOfferToStart = false; // スタートの申請フラグ
    [SerializeField] protected float fadeSpeed = 1f; // フェードスピード
    [SerializeField] protected float maxEffectTime = 0.8f; // スタートの演出時間
    protected float currentEffectTime = 0; // 現在のエフェクト時間
    protected bool isFinishedEffect = false; // エフェクト終了フラグ

    // テキストを更新する関数
    protected abstract void UpdateText();

    protected void Effect()
    {
        // スタートのオファーがなかったら
        if (!isOfferToStart)
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
            if (maxEffectTime <= currentEffectTime)
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
