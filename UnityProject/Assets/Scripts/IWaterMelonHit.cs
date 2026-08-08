using UnityEngine;

public interface IWaterMelonHit
{
    // バットの座標と半径を受け取り、自身に当たっているか判定する
    bool CheckHit(Vector2 batPosition, float batRadius);
    
    // 破壊処理を実行する
    void Break();
}
