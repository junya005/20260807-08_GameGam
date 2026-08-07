using UnityEngine;

public class TargetChecker : MonoBehaviour, IArrivalCheck
{
    [Header("Target Settings")]
    [SerializeField] private Vector2 targetOffset = new Vector2(-1f, 0f); // スイカの左側を想定したオフセット
    [SerializeField] private float targetRadius = 0.5f; // ターゲット円の半径

    // デバッグUI等から変更するためのプロパティ
    public Vector2 TargetOffset { get => targetOffset; set => targetOffset = value; }
    public float TargetRadius { get => targetRadius; set => targetRadius = value; }

    public bool CheckArrival(Vector2 checkPos, float checkRadius)
    {
        return CheckArrival((Vector2)checkPos, checkRadius, out _);
    }

    public bool CheckArrival(Vector2 checkPos, float checkRadius, out float distance)
    {
        // ターゲットの位置と判定位置（プレイヤーの影）の距離を計算
        distance = Vector2.Distance(GetTargetPosition(), (Vector2)checkPos);

        // 少しでも重なっていれば成功（距離が両者の半径の和以下）
        return distance <= (targetRadius + checkRadius);
    }

    private Vector2 GetTargetPosition()
    {
        return (Vector2)transform.position + targetOffset;
    }

    // デバッグ用にギズモを描画
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetTargetPosition(), targetRadius);
    }
}
