using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyActivate : MonoBehaviour
{
    public GameObject money;

    private void Update()
    {
        if (BoyMovement.pages >= 30)
        {
            money.SetActive(true); //activate money
        }
    }
}
