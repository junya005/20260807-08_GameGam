using Unity.VisualScripting;
using UnityEngine;

public class CountDownTime : CountBase
{
    [SerializeField] private GameObject textStartCount; // テキストスタートカウント
    [SerializeField] private ManageCountDonw manageCountDown;
    private bool isStop = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      // 時間の設定
        currentTime = settingTime;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーを停止
        if (isStop) return;

        if (!isApplyCount) return;

        CountDown();

        SetCountDown();
    }

    // カウントダウンを設定する関数
    private void SetCountDown()
    {
        int time = (int)Mathf.Ceil(currentTime);
        manageCountDown.SetCountDonw(time);
    }

    // タイマーを停止する関数
    public void StopCount()
    {
        isStop = true;
    }
}
