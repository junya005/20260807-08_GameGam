using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Title,
        InGame,
        Result
    }

    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerTargetBridge playerTargetBridge;

    [Header("Settings")]
    [SerializeField] private float countdownSeconds = 3.0f;

    public GameState CurrentState { get; private set; } = GameState.Title;
    private bool _isCountingDown = false;

    private void Start()
    {
        // 最初はプレイヤーが動けないようにロックする
        if (playerController != null)
        {
            playerController.SetPlayerActive(false);
        }

        // 攻撃結果のイベントを購読してResultへの遷移に備える
        if (playerTargetBridge != null)
        {
            playerTargetBridge.OnAttackResult.AddListener(OnPlayerAttackResult);
        }

        CurrentState = GameState.Title;
        Debug.Log("State: Title - スペースキーを押してスタート");
    }

    private void Update()
    {
        if (CurrentState == GameState.Title && !_isCountingDown)
        {
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                StartCoroutine(StartCountdownRoutine());
            }
        }
    }

    private IEnumerator StartCountdownRoutine()
    {
        _isCountingDown = true;
        Debug.Log("カウントダウン開始...");
        
        float timer = countdownSeconds;
        while (timer > 0)
        {
            Debug.Log($"残り {Mathf.Ceil(timer)} 秒");
            yield return new WaitForSeconds(1.0f);
            timer -= 1.0f;
        }

        Debug.Log("START!");
        ChangeState(GameState.InGame);
    }

    private void ChangeState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.InGame:
                if (playerController != null)
                {
                    playerController.SetPlayerActive(true);
                }
                Debug.Log("State: InGame - プレイヤー操作可能");
                break;

            case GameState.Result:
                if (playerController != null)
                {
                    playerController.SetPlayerActive(false);
                }
                Debug.Log("State: Result - ゲーム終了、プレイヤー操作ロック");
                break;
        }
    }

    private void OnPlayerAttackResult(bool isSuccess, float distance)
    {
        if (CurrentState == GameState.InGame)
        {
            Debug.Log($"攻撃実行によりゲーム終了。結果: {isSuccess}, 距離: {distance}");
            ChangeState(GameState.Result);
        }
    }

    private void OnDestroy()
    {
        if (playerTargetBridge != null)
        {
            playerTargetBridge.OnAttackResult.RemoveListener(OnPlayerAttackResult);
        }
    }
}
