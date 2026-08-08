using UnityEngine;

[RequireComponent(typeof(PlayerSpriteAnimation))]
[RequireComponent(typeof(PlayerSound))]
public class PlayerView : MonoBehaviour
{
    private PlayerSpriteAnimation _spriteAnimation;
    private PlayerSound _playerSound;

    private void Awake()
    {
        _spriteAnimation = GetComponent<PlayerSpriteAnimation>();
        _playerSound = GetComponent<PlayerSound>();
    }

    // 移動状態に応じた見た目と音声の更新
    public void UpdateMoveView(Vector2 moveDirection, bool isMoving)
    {
        // アニメーションへ移動ベクトルを渡す
        _spriteAnimation.UpdateMoveAnimation(moveDirection);
        
        if (isMoving)
        {
            _playerSound.PlayWalkSound();
        }
        else
        {
            _playerSound.StopWalkSound();
        }
    }

    // 攻撃時の見た目と音声の更新
    public void PlayAttackView()
    {
        _spriteAnimation.PlayAttackAnimation();
        _playerSound.PlayAttackSound();
    }

    // リセット時の見た目の更新
    public void PlayResetView()
    {
        _spriteAnimation.PlayResetAnimation();
        _playerSound.StopWalkSound();
    }
}
