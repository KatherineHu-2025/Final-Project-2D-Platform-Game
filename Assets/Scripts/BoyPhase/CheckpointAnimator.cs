using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointAnimator : MonoBehaviour
{
    private Animator _flagAnimator;
    //private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        _flagAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _flagAnimator.SetBool("isActivated", true);
        }
    }
}
