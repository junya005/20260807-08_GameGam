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
    private PlayerView _playerView;

    // Bridgeなどに攻撃の発生を伝えるイベント
    public event Action<Vector2, float> OnPlayerAttack;

    private bool _isActive = true;
    private bool _isAttacking = false; // 攻撃中かどうかを判定するフラグ

    public void SetPlayerActive(bool isActive)
    {
        _isActive = isActive;
    }

    private void Awake()
    {
        _playerHandler = GetComponent<PlayerHandler>();
        _playerMove = GetComponent<PlayerMove>();
        _playerAutoMover = GetComponent<PlayerAutoMover>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerView = GetComponent<PlayerView>();

        // PlayerAttackからの内部イベントをサブスクライブし、外部へ中継する
        _playerAttack.OnAttackTriggered += (pos, radius) =>
        {
            OnPlayerAttack?.Invoke(pos, radius);
        };
    }

    private void Update()
    {
        if (!_isActive || _isAttacking)
        {
            // 非アクティブ時や攻撃中は見た目をIdle（移動なし）にして入力を受け付けない
            if (_playerView != null) _playerView.UpdateMoveView(Vector2.zero, false);
            return;
        }

        // 1. 入力の更新
        _playerHandler.HandleInput();

        // 2. 攻撃アクション
        if (_playerHandler.IsAttackPressed)
        {
            _isAttacking = true; // 攻撃した瞬間に移動をロック
            _playerAttack.Attack();
            // アニメーション再生（このアニメーション内のAnimationEventで実際の当たり判定が行われる）
            if (_playerView != null) _playerView.PlayAttackView();
            return; // 攻撃開始フレームではこれ以降の移動処理を行わない
        }

        // 3. 移動処理（手動入力 + 自動移動）
        Vector2 manualMove = _playerHandler.MoveInput;
        Vector2 autoMove = _playerAutoMover.GetCurrentAutoMove();

        _playerMove.Move(manualMove, autoMove);

        // 4. 見た目の更新
        Vector2 finalMove = manualMove + autoMove;
        if (_playerView != null)
        {
            _playerView.UpdateMoveView(finalMove, finalMove.magnitude > 0.01f);
        }
    }

    // 外部（GameManager等）から呼び出してアニメーション等をリセットするためのメソッド
    public void TriggerReset()
    {
        _isAttacking = false;
        if (_playerView != null)
        {
            _playerView.PlayResetView();
        }
    }
}
