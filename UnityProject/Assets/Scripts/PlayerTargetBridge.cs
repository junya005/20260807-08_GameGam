using UnityEngine;
using UnityEngine.Events;

public class PlayerTargetBridge : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TargetController targetController;

    // 上位のゲームマネージャー等に結果を通知するためのUnityEvent
    // (引数: bool isSuccess, float distance)
    [System.Serializable]
    public class AttackResultEvent : UnityEvent<bool, float> { }
    
    [Header("Events")]
    public AttackResultEvent OnAttackResult;

    private void OnEnable()
    {
        if (playerController != null)
        {
            playerController.OnPlayerAttack += HandleAttack;
        }
    }

    private void OnDisable()
    {
        if (playerController != null)
        {
            playerController.OnPlayerAttack -= HandleAttack;
        }
    }

    private void HandleAttack(Vector2 shadowPos, float shadowRadius)
    {
        if (targetController == null) 
        {
            Debug.LogWarning("PlayerTargetBridge: TargetControllerが設定されていません。");
            return;
        }

        float distance;
        // TargetController経由で判定（TargetCheckerへは間接的にアクセス）
        bool isHit = targetController.CheckHit(shadowPos, shadowRadius, out distance);

        // 判定結果をTargetControllerのイベントに伝達
        if (isHit)
        {
            targetController.OnHitSuccess();
        }
        else
        {
            targetController.OnHitFailed();
        }

        // ゲームマネージャー等に結果と距離を通知する
        OnAttackResult?.Invoke(isHit, distance);
    }
}
