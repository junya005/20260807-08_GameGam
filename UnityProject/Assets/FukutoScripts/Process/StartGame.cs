using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartGame : MonoBehaviour
{
    private bool isStart = false;
    private bool isAlreadyPush = false; 
    [SerializeField] private StartCount startCount;
    [SerializeField] private GameObject Title;
    [SerializeField] private GameObject textStartCount;
    [SerializeField] private GameObject rule;
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
    }

    // スペースを入力したら処理される関数
    private void PushToSpace()
    {
        // 押されていない場合
        if (!isAlreadyPush)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                GameStart();
                isAlreadyPush = true;
            }
        }
    }

    // ゲームを開始する関数
    private void GameStart()
    {
        // スタートテキストを非アクティブ化
        Title.SetActive(false);
        // アクティブ化
        rule.SetActive(true);
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
