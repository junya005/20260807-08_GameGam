using TMPro;
using UnityEngine;

public class ReturnTitleText:TextBase
{

    void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateText();
    }

    protected override void UpdateText()
    {
        Effect();
    }
}
