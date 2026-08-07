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

    // テキストを更新する関数
    protected abstract void UpdateText();
}
