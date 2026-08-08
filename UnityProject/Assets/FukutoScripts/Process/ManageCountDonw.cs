using UnityEngine;

public class ManageCountDonw : MonoBehaviour
{
    private int countDown = 1;
    private bool isApplyResult = false;
    private bool isOnce = false;
    [SerializeField] private GameObject result;
    [SerializeField] private GameObject timer;

    private void Update()
    {
        if (isOnce) return;
        // 
        if(isApplyResult)
        {
            result.SetActive(true);
            isOnce = true;
        }

        if (countDown == 0)
        {
            isApplyResult = true;
        }
    }

    public void  SetCountDonw(int count)
    {
        countDown = count;
    }

    public bool GetApplyResult()
    {
        return isApplyResult; 
    }
}
