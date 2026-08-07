using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Shadow Settings")]
    [SerializeField] private Vector2 shadowOffset = new Vector2(0f, -0.5f); // プレイヤーの下
    [SerializeField] private float shadowRadius = 0.5f; // 丸影の半径

    // デバッグUI等から変更するためのプロパティ
    public Vector2 ShadowOffset { get => shadowOffset; set => shadowOffset = value; }
    public float ShadowRadius { get => shadowRadius; set => shadowRadius = value; }

    // PlayerTargetBridge に判定を依頼するためのイベント
    public delegate void AttackEventHandler(Vector2 position, float radius);
    public event AttackEventHandler OnAttackTriggered;

    public void Attack()
    {
        Debug.Log("スイカを割るアクション実行！");
        
        // プレイヤーの丸影の中心座標を計算
        Vector2 shadowPos = (Vector2)transform.position + shadowOffset;
        
        // イベントを発火して判定処理を要求
        OnAttackTriggered?.Invoke(shadowPos, shadowRadius);
    }

    // デバッグ用にギズモを描画
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere((Vector2)transform.position + shadowOffset, shadowRadius);
    }
}
