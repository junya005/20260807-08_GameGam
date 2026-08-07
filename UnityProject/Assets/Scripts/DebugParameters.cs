using UnityEngine;
using UnityEngine.InputSystem;

public class DebugParameters : MonoBehaviour
{
    private bool _showDebugMenu = false;
    private Rect _windowRect = new Rect(20, 20, 350, 450);

    // 調整対象のコンポーネント
    private PlayerMove _playerMove;
    private PlayerAutoMover _playerAutoMover;
    private PlayerAttack _playerAttack;
    private TargetChecker _targetChecker;

    private void Start()
    {
        // 実行時にシーン内から自動取得
        _playerMove = FindAnyObjectByType<PlayerMove>();
        _playerAutoMover = FindAnyObjectByType<PlayerAutoMover>();
        _playerAttack = FindAnyObjectByType<PlayerAttack>();
        _targetChecker = FindAnyObjectByType<TargetChecker>();
    }

    private void Update()
    {
        // プロジェクトでInputSystemを採用しているため、F11キー入力もこちらで検知
        if (Keyboard.current != null && Keyboard.current.f11Key.wasPressedThisFrame)
        {
            _showDebugMenu = !_showDebugMenu;
        }
    }

    private void OnGUI()
    {
        if (!_showDebugMenu) return;

        // GUIウィンドウの描画
        _windowRect = GUILayout.Window(0, _windowRect, DrawDebugWindow, "Debug Parameters (F11 to toggle)");
    }

    private void DrawDebugWindow(int windowID)
    {
        GUILayout.BeginVertical();

        if (_playerMove != null)
        {
            GUILayout.Label("=== Player Move ===", UnityEditorStyles.BoldLabel());
            _playerMove.ManualSpeed = DrawSlider("Manual Speed", _playerMove.ManualSpeed, 0f, 10f);
            _playerMove.MinX = DrawSlider("Min X", _playerMove.MinX, -30f, 0f);
            _playerMove.MaxX = DrawSlider("Max X", _playerMove.MaxX, 0f, 30f);
            _playerMove.MinY = DrawSlider("Min Y", _playerMove.MinY, -30f, 0f);
            _playerMove.MaxY = DrawSlider("Max Y", _playerMove.MaxY, 0f, 30f);
            GUILayout.Space(10);
        }

        if (_playerAutoMover != null)
        {
            GUILayout.Label("=== Player Auto Mover ===", UnityEditorStyles.BoldLabel());
            _playerAutoMover.AutoMoveSpeed = DrawSlider("Auto Move Speed", _playerAutoMover.AutoMoveSpeed, 0f, 5f);
            GUILayout.Space(10);
        }

        if (_playerAttack != null)
        {
            GUILayout.Label("=== Player Shadow (Attack) ===", UnityEditorStyles.BoldLabel());
            _playerAttack.ShadowRadius = DrawSlider("Shadow Radius", _playerAttack.ShadowRadius, 0.1f, 5f);
            
            Vector2 sOffset = _playerAttack.ShadowOffset;
            sOffset.x = DrawSlider("Offset X", sOffset.x, -5f, 5f);
            sOffset.y = DrawSlider("Offset Y", sOffset.y, -5f, 5f);
            _playerAttack.ShadowOffset = sOffset;
            GUILayout.Space(10);
        }

        if (_targetChecker != null)
        {
            GUILayout.Label("=== Target Checker ===", UnityEditorStyles.BoldLabel());
            _targetChecker.TargetRadius = DrawSlider("Target Radius", _targetChecker.TargetRadius, 0.1f, 5f);
            
            Vector2 tOffset = _targetChecker.TargetOffset;
            tOffset.x = DrawSlider("Offset X", tOffset.x, -5f, 5f);
            tOffset.y = DrawSlider("Offset Y", tOffset.y, -5f, 5f);
            _targetChecker.TargetOffset = tOffset;
        }

        GUILayout.EndVertical();

        // ウィンドウをドラッグ可能にする
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
    }

    private float DrawSlider(string label, float value, float min, float max)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label + ": " + value.ToString("F2"), GUILayout.Width(130));
        float newValue = GUILayout.HorizontalSlider(value, min, max);
        GUILayout.EndHorizontal();
        return newValue;
    }

    // 簡単なボールドスタイルのヘルパー
    private static class UnityEditorStyles
    {
        public static GUIStyle BoldLabel()
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontStyle = FontStyle.Bold;
            return style;
        }
    }
}
