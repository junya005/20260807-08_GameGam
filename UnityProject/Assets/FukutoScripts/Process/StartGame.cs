using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    private bool isStart = false;
    private bool isAlreadyPush = false; 
    [SerializeField] private ControlStartText controlStartText;
    [SerializeField] private StartCount startCount;
    [SerializeField] private GameObject textStart;
    [SerializeField] private GameObject textStartCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ゲーム開始したら
        if (isStart) return;

        PushToSpace();
        // テキストの演出が終了したらゲーム開始
        if(controlStartText.GetFinishedEffect())
        {
            GameStart();
        }
    }

    // スペースを入力したら処理される関数
    private void PushToSpace()
    {
        // 押されていない場合
        if (!isAlreadyPush)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                // スタートテキストにスタート申請をする
                controlStartText.SetOfferToStart();
                isAlreadyPush = true;
            }
        }
    }

    // ゲームを開始する関数
    private void GameStart()
    {
        // スタートテキストを非アクティブ化
        textStart.SetActive(false);
        // タイムテキストをアクティブ化
        textStartCount.SetActive(true);
        // カウントダウンを許可
        startCount.SetApplyCount();
        isStart = true;
    }

    public bool GetIsStart()
    {
        return isStart; 
    }
}
