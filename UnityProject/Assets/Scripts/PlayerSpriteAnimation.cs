using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteAnimation : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Animator _animator;

    // Animatorのパラメータハッシュ
    private readonly int _moveValueHash = Animator.StringToHash("MoveValue");

    private readonly int _attackedHash = Animator.StringToHash("Attacked");
    private readonly int _resetedHash = Animator.StringToHash("Reseted");

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateMoveAnimation(Vector2 moveValue)
    {
        if (_animator == null) return;

        // 全体の速さ(magnitude)を Float 型の "MoveValue" としてAnimatorに送信
        _animator.SetFloat(_moveValueHash, moveValue.magnitude);

        // 進行方向に応じてスプライトを左右反転
        // ターゲットについたのにスイカに当たらないという事象が発生するためコメント化
        // if (moveValue.x > 0.01f)
        // {
        //     _spriteRenderer.flipX = false;
        // }
        // else if (moveValue.x < -0.01f)
        // {
        //     _spriteRenderer.flipX = true;
        // }
    }

    public void PlayAttackAnimation()
    {
        if (_animator != null)
        {
            _animator.SetTrigger(_attackedHash);
        }
    }

    public void PlayResetAnimation()
    {
        if (_animator != null)
        {
            _animator.SetTrigger(_resetedHash);
        }
    }
}
