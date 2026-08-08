using UnityEngine;
using System.Collections.Generic;

public class WaterMelonCollider : MonoBehaviour, IWaterMelonHit
{
    [Header("Hit Detection Settings")]
    [SerializeField] private float colliderRadius = 0.5f;
    [SerializeField] private Vector2 colliderOffset = Vector2.zero;

    private WaterMelonController _controller;

    // パフォーマンス最適化のため、シーン上の全てのスイカを管理するリスト
    public static List<IWaterMelonHit> AllWaterMelons = new List<IWaterMelonHit>();

    private void Awake()
    {
        _controller = GetComponent<WaterMelonController>();
    }

    private void OnEnable()
    {
        if (!AllWaterMelons.Contains(this))
        {
            AllWaterMelons.Add(this);
        }
    }

    private void OnDisable()
    {
        if (AllWaterMelons.Contains(this))
        {
            AllWaterMelons.Remove(this);
        }
    }

    public bool CheckHit(Vector2 batPosition, float batRadius)
    {
        Vector2 myPos = (Vector2)transform.position + colliderOffset;
        float distance = Vector2.Distance(myPos, batPosition);
        return distance <= (colliderRadius + batRadius);
    }

    public void Break()
    {
        if (_controller != null)
        {
            _controller.OnBroken();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((Vector2)transform.position + colliderOffset, colliderRadius);
    }
}
