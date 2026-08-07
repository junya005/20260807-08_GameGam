using System.Xml;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ControlText : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private TextMeshProUGUI tmpText;

    void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        float alpha = Mathf.PingPong(Time.time * speed, 1f);
        Color c = tmpText.color;
        c.a = alpha;
        tmpText.color = c;
    }
}
