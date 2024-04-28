using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadCollider : MonoBehaviour
{
    private Rigidbody2D _boxRigidbody;
    public Slider pageSlider;

    public Animator _pageAnimator;
    //private BoyMovement pages;

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
        if (coll.collider == true)
        {
            // Disables the Collider2D component
            BoyMovement.IncreasePages();
            Debug.Log("collider hit");
            UpdatePages();
            Debug.Log("pages are: " +  pageSlider.value);
            //_pageAnimator.Play("Page");
        }
    }
    public void UpdatePages()
    {
        float pages = BoyMovement.CheckPages();
        pageSlider.value = pages;
    }
}
