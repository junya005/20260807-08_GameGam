using Unity.VisualScripting;
using UnityEngine;

public class CountDownTime : CountBase
{
    [SerializeField] private GameObject textStartCount; // テキストスタートカウント

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 時間の設定
        currentTime = settingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isApplyCount) return;
            CountDown();
    }
}
