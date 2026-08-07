using UnityEngine;

public class StartCount: CountBase
{
    private void Start()
    {
        // 時間の設定
        currentTime = settingTime;
    }

    private void Update()
    {
        if (!isApplyCount) return;
        CountDown();
    }

}
