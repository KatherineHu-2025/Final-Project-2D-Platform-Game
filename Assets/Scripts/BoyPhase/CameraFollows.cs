using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    // Update is called once per frame
    void LateUpdate () {
        transform.position = player.transform.position + new Vector3(1, 0, -5);
    }
}
