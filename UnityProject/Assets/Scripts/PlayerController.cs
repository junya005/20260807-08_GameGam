using UnityEngine;

[RequireComponent(typeof(PlayerHandler), typeof(PlayerMove), typeof(PlayerAutoMover))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerController : MonoBehaviour
{
    private PlayerHandler _playerHandler;
    private PlayerMove _playerMove;
    private PlayerAutoMover _playerAutoMover;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerHandler = GetComponent<PlayerHandler>();
        _playerMove = GetComponent<PlayerMove>();
        _playerAutoMover = GetComponent<PlayerAutoMover>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        // 1. 入力の更新
        _playerHandler.HandleInput();

        // 2. 攻撃処理の判定
        if (_playerHandler.IsAttackPressed)
        {
            _playerAttack.Attack();
        }

        // 3. 移動処理（手動入力 + 自動移動）
        Vector2 manualMove = _playerHandler.MoveInput;
        Vector2 autoMove = _playerAutoMover.GetCurrentAutoMove();

        Debug.Log(manualMove);

        _playerMove.Move(manualMove, autoMove);
    }
}
