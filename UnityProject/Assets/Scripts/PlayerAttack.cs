using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Shadow Settings")]
    [SerializeField] private Vector2 shadowOffset = new Vector2(0f, -0.5f); // プレイヤーの下
    [SerializeField] private float shadowRadius = 0.5f; // 丸影の半径

    [Header("Bat Settings (WaterMelon Hit)")]
    [SerializeField] private Vector2 batOffset = new Vector2(0f, 0.5f); // バットの判定位置
    [SerializeField] private float batRadius = 0.5f; // バットの当たり判定半径

    // デバッグUI等から変更するためのプロパティ
    public Vector2 ShadowOffset { get => shadowOffset; set => shadowOffset = value; }
    public float ShadowRadius { get => shadowRadius; set => shadowRadius = value; }
    public Vector2 BatOffset { get => batOffset; set => batOffset = value; }
    public float BatRadius { get => batRadius; set => batRadius = value; }

    // PlayerTargetBridge に判定を依頼するためのイベント
    public delegate void AttackEventHandler(Vector2 position, float radius);
    public event AttackEventHandler OnAttackTriggered;

    public void Attack()
    {
        Debug.Log("スイカを割るアクション開始（アニメーション開始）");
        // 実際の当たり判定は AnimationEvent から ExecuteHit() が呼ばれたタイミングで行われます
    }

    // AnimationEventから呼び出すメソッド
    public void ExecuteHit()
    {
        Debug.Log("アニメーションイベントから当たり判定を実行！");
        
        // --- 1. 目標ポイント（Target）の判定 ---
        Vector2 shadowPos = (Vector2)transform.position + shadowOffset;
        OnAttackTriggered?.Invoke(shadowPos, shadowRadius);

        // --- 2. スイカ本体（WaterMelon）の当たり判定 ---
        Vector2 batPos = (Vector2)transform.position + batOffset;
        
        // リスト登録されたすべてのスイカに対してヒットチェックを行う
        foreach (var hittable in WaterMelonCollider.AllWaterMelons)
        {
            if (hittable.CheckHit(batPos, batRadius))
            {
                hittable.Break();
            }
        }
    }

    // デバッグ用にギズモを描画
    private void OnDrawGizmosSelected()
    {
        // 影の判定範囲（青）
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere((Vector2)transform.position + shadowOffset, shadowRadius);

        // バットの判定範囲（黄色）
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere((Vector2)transform.position + batOffset, batRadius);
    }
}
