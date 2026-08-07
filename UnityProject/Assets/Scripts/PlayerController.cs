using System;
using UnityEngine;

[RequireComponent(typeof(PlayerHandler), typeof(PlayerMove), typeof(PlayerAutoMover))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerController : MonoBehaviour
{
    private PlayerHandler _playerHandler;
    private PlayerMove _playerMove;
    private PlayerAutoMover _playerAutoMover;
    private PlayerAttack _playerAttack;

    // Bridgeなどに攻撃の発生を伝えるイベント
    public event Action<Vector2, float> OnPlayerAttack;

    private void Awake()
    {
        _playerHandler = GetComponent<PlayerHandler>();
        _playerMove = GetComponent<PlayerMove>();
        _playerAutoMover = GetComponent<PlayerAutoMover>();
        _playerAttack = GetComponent<PlayerAttack>();

        // PlayerAttackからの内部イベントをサブスクライブし、外部へ中継する
        _playerAttack.OnAttackTriggered += (pos, radius) =>
        {
            OnPlayerAttack?.Invoke(pos, radius);
        };
    }

    private void Update()
    {
        // 入力の更新
        _playerHandler.HandleInput();

        // 攻撃アクション
        if (_playerHandler.IsAttackPressed)
        {
            _playerAttack.Attack();
        }

        // 移動処理（手動入力 + 自動移動）
        Vector2 manualMove = _playerHandler.MoveInput;
        Vector2 autoMove = _playerAutoMover.GetCurrentAutoMove();

        _playerMove.Move(manualMove, autoMove);
    }
}
