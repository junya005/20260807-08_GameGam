using TMPro;
using UnityEngine;

/// <summary>
/// コントロールスタートテキスト
/// 
/// ゲーム開始時のテキストクラス
/// </summary>
public class ControlStartText : TextBase
{
    

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
        Effect();
    }
}
