using UnityEngine;

public class ResultScript : MonoBehaviour
{
    private bool flag;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    //void Update()
    //{
    //    if(gameManager.)
    //}

    public void Set(bool value)
    {
        flag = value;
        if(flag)
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(false);
        }
    }
}
