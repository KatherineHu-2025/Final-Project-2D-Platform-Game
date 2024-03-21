using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer signSpriteRenderer;
    public Transform raycastOrigin; 
    public float raycastDistance = 3f; 
    public LayerMask layerMask;
    public TMP_Text myText;

    // Start is called before the first frame update
    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        StartCoroutine(FlipAndDetect()); // Start the coroutine to flip direction and constantly detect
    }

    // Coroutine to flip the character direction and constantly detect objects when facing left
    IEnumerator FlipAndDetect()
    {
        while (true) // Infinite loop to continuously flip direction and detect
        {   
            float randomTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(randomTime);

            spriteRenderer.flipX = !spriteRenderer.flipX;

            if (spriteRenderer.flipX)
            {   
                float timeToFlipBack = Random.Range(1f, 3f); // Time after which the character will flip back
                float startTime = Time.time; // Record the start time

                while (spriteRenderer.flipX && (Time.time - startTime) < timeToFlipBack)
                {   
                    RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.left, raycastDistance, layerMask);
                    if (hit.collider != null)
                    {   
                        if(Character.CheckMoney() >= 30){
                            myText.text = "Your work for today is finished. You can leave now.";
                        }
                        else{
                            SceneManager.LoadScene("Office");
                            yield break; // Exit the coroutine if an object is detected and the scene is changed
                        }
                    }

                    // Wait a short amount of time before checking again
                    yield return new WaitForSeconds(0.01f);
                }

                // Flip back to facing right after the specified period if no collision was detected
                spriteRenderer.flipX = false;
            }
        }
    }

    void OnDrawGizmos()
    {
        if (raycastOrigin != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(raycastOrigin.position, raycastOrigin.position + Vector3.left * raycastDistance);
        }
    }
}
