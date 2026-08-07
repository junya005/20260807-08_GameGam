using UnityEngine;

[RequireComponent(typeof(TargetChecker))]
public class TargetController : MonoBehaviour
{
    private TargetChecker _checker;

    private void Awake()
    {
        _checker = GetComponent<TargetChecker>();
    }

    // Bridgeから呼び出すための判定窓口（TargetCheckerへの委譲）
    public bool CheckHit(Vector2 pos, float radius, out float distance)
    {
        return _checker.CheckArrival((Vector3)pos, radius, out distance);
    }

    public void OnHitSuccess()
    {
        Debug.Log("判定成功：スイカのターゲットに命中しました！");
        // 成功時のパーティクル再生やスコア加算などをここに実装
    }

    public void OnHitFailed()
    {
        Debug.Log("判定失敗：ターゲットから離れています。");
        // 失敗時の処理をここに実装
    }
}
