using UnityEngine;

public class WaterMelonSpriteAnimation : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite intactSprite;
    [SerializeField] private Sprite brokenSprite;

    [Header("References")]
    // SpriteRendererは外部（子オブジェクトなど）から別途設定可能にする
    [SerializeField] private SpriteRenderer targetRenderer;

    private void Start()
    {
        if (targetRenderer != null && intactSprite != null)
        {
            targetRenderer.sprite = intactSprite;
        }
    }

    public void PlayBreak()
    {
        // 割れたスプライトに変更
        if (targetRenderer != null && brokenSprite != null)
        {
            targetRenderer.sprite = brokenSprite;
        }
    }
}
