using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool IsAttackPressed { get; private set; }

    public void HandleInput()
    {
        float x = 0f;
        float y = 0f;

        Keyboard keyboard = Keyboard.current;

        if (keyboard != null)
        {
            // W(上), S(下), A(左), D(右)
            if (keyboard.wKey.isPressed) y = 1f;
            if (keyboard.sKey.isPressed) y = -1f;
            if (keyboard.aKey.isPressed) x = -1f;
            if (keyboard.dKey.isPressed) x = 1f;

            // スペースキー入力（押された瞬間のみ判定）
            IsAttackPressed = keyboard.spaceKey.wasPressedThisFrame;
        }
        else
        {
            IsAttackPressed = false;
        }

        // 斜め移動時に速度が1.0を超えないよう正規化する
        MoveInput = new Vector2(x, y).normalized;
    }
}
