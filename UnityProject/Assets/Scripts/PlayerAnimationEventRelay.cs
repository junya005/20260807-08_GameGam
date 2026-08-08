using UnityEngine;

/// <summary>
/// Animatorコンポーネントと同じGameObjectにアタッチし、AnimationEventを受け取って
/// 別のGameObjectにある PlayerAttack へ処理を中継（リレー）するためのヘルパークラスです。
/// </summary>
public class PlayerAnimationEventRelay : MonoBehaviour
{
    [Header("References")]
    [Tooltip("当たり判定を実行するPlayerAttackの参照。未設定の場合は親オブジェクトから自動取得します。")]
    [SerializeField] private PlayerAttack playerAttack;

    private void Awake()
    {
        // インスペクターで設定されていない場合は、親や自分自身のオブジェクトから自動で取得を試みる
        if (playerAttack == null)
        {
            playerAttack = GetComponentInParent<PlayerAttack>();
        }
    }

    /// <summary>
    /// AnimationEventのFunctionとして指定するメソッド。
    /// 受け取ったイベントを実際の PlayerAttack.ExecuteHit() に流します。
    /// </summary>
    public void ExecuteHit()
    {
        if (playerAttack != null)
        {
            playerAttack.ExecuteHit();
        }
        else
        {
            Debug.LogWarning("PlayerAnimationEventRelay: 中継先の PlayerAttack が設定されていません。");
        }
    }
}
