using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Open()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
