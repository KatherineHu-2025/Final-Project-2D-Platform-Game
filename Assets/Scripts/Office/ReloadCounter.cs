using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadCounter : MonoBehaviour
{
    public static int reloadCount = 0;

    void Awake()
    {
        reloadCount++;
    }
}
