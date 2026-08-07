using UnityEngine;

public class PlayerAutoMover : MonoBehaviour
{
    public float AutoMoveSpeed = 0.5f;
    
    private Vector2 _currentDirection;
    private float _timer;

    private void Start()
    {
        SetNextAutoMove();
    }

    private void Update()
    {
        // タイマーを減らす
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            // インターバルなしで連続で次の移動を決定
            SetNextAutoMove();
        }
    }

    public Vector2 GetCurrentAutoMove()
    {
        // 現在の方向ベクトルに自動移動の速度を掛けたものを返す
        return _currentDirection * AutoMoveSpeed;
    }

    private void SetNextAutoMove()
    {
        // 8方向（東西南北＋斜め４方向）をランダムに決定
        int dir = Random.Range(0, 8);
        switch (dir)
        {
            case 0: _currentDirection = new Vector2(0, 1); break; // 北
            case 1: _currentDirection = new Vector2(1, 1).normalized; break; // 北東
            case 2: _currentDirection = new Vector2(1, 0); break; // 東
            case 3: _currentDirection = new Vector2(1, -1).normalized; break; // 南東
            case 4: _currentDirection = new Vector2(0, -1); break; // 南
            case 5: _currentDirection = new Vector2(-1, -1).normalized; break; // 南西
            case 6: _currentDirection = new Vector2(-1, 0); break; // 西
            case 7: _currentDirection = new Vector2(-1, 1).normalized; break; // 北西
        }

        // 0.3～1秒程度のランダムな秒数
        _timer = Random.Range(0.3f, 1.0f);
    }
}
