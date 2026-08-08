using UnityEngine;

[RequireComponent(typeof(WaterMelonSpriteAnimation))]
public class WaterMelonView : MonoBehaviour
{
    private WaterMelonSpriteAnimation _spriteAnimation;

    private void Awake()
    {
        _spriteAnimation = GetComponent<WaterMelonSpriteAnimation>();
    }

    public void PlayBreakAnimation()
    {
        if (_spriteAnimation != null)
        {
            _spriteAnimation.PlayBreak();
        }
    }
}
