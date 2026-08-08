using UnityEngine;

[RequireComponent(typeof(WaterMelonCollider), typeof(WaterMelonView))]
public class WaterMelonController : MonoBehaviour
{
    private WaterMelonView _view;
    private bool _isBroken = false;

    private void Awake()
    {
        _view = GetComponent<WaterMelonView>();
    }

    public void OnBroken()
    {
        if (_isBroken) return; // 既に割れている場合は無視
        _isBroken = true;
        
        // 見た目の制御へ通知
        if (_view != null)
        {
            _view.PlayBreakAnimation();
        }
        
        Debug.Log("スイカが割れました！");
    }
}
