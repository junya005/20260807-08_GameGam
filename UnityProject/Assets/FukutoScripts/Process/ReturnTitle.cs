using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    private bool isReturn = false;
    private bool isAlreadyPush = false;
    private bool isApplyReturn = false; 
    [SerializeField] private ReturnTitleText returnText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 既に戻ったらしたら
        if (isReturn) return;

        // 許可が出ていなかったら
        if (!isApplyReturn) return;

        PushToSpace();
        // テキストの演出が終了したらゲーム開始
        if (returnText.GetFinishedEffect())
        {
            ReturnToTitle();
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
                returnText.SetOfferToStart();
                isAlreadyPush = true;
            }
        }
    }

    // ゲームを開始する関数
    private void ReturnToTitle()
    {
        isReturn = true;
        SceneManager.LoadScene("Main");
    }

    // 戻るフラグを設定する関数
    public  void SetApplyReturn()
    {
        isApplyReturn = true;
    }
}
