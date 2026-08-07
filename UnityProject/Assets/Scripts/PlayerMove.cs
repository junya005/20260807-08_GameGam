using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float ManualSpeed = 1.0f;
    
    // マップの境界線（仮の制限値）
    public float MinX = -10f;
    public float MaxX = 10f;
    public float MinY = -10f;
    public float MaxY = 10f;

    public void Move(Vector2 manualInput, Vector2 autoInput)
    {
        // 手動入力ベクトルに速度を掛ける
        Vector2 manualMove = manualInput * ManualSpeed;

        // プレイヤー挙動と自動移動が重なる場合はベクトルの合成（加算）
        Vector2 finalMove = manualMove + autoInput;

        // Transform.positionを更新（Time.deltaTimeを掛けてフレームレートに依存しない移動速度にする）
        // 2D座標系としてVector2で計算
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = currentPosition + finalMove * Time.deltaTime;

        // マップの端へ行けないように制限（Clamp）
        newPosition.x = Mathf.Clamp(newPosition.x, MinX, MaxX);
        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);

        // Z軸はそのまま維持して位置を適用する
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
