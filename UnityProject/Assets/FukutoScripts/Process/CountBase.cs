using UnityEngine;

public abstract class CountBase : MonoBehaviour
{
    [SerializeField] protected float settingTime = 1f; // 設定時間
    protected float currentTime; // 現在の時間
    protected bool isApplyCount = false;

    // カウントダウンをする関数
    protected void CountDown()
   {
        // 0秒以下の場合0に設定
        if (currentTime <= 0)
        {
            currentTime = 0f;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    // 現在の時間を取得する関数
    public int GetCurrenTime()
    {
        // 切り上げ式に変換
        int time = (int)Mathf.Ceil(currentTime);
        return time;
    }

    // カウントの許可を設定する関数
    public void SetApplyCount()
    {
        isApplyCount = true;
    }
}
