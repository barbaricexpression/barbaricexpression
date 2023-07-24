using System.Collections;
using UnityEngine;

public class CharacterControl_02 : MonoBehaviour
{
    private Animator animator;
    public bool isOnGround_level_00 = true;
    public float jumpForce = 1.5f;
    private Rigidbody playerRB;
    private readonly bool canJump = true;
    private readonly bool canSlide = true;
    private BoxCollider boxCollider;
    private Vector3 originalSize;
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        originalSize = boxCollider.size;
    }
    private void Update()
    {
        animator.SetBool("isRunning", true);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            _ = StartCoroutine(DelayedJump(0.5f));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && canSlide)
        {
            // Change the size of the box collider
            boxCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
            // Reset the size of the box collider after a delay
            Invoke(nameof(ResetBoxColliderSize), 1.0f);
        }
    }
    private IEnumerator DelayedJump(float delay)
    {
        // Delay the jump force by the specified delay time
        yield return new WaitForSeconds(delay);

        if (isOnGround_level_00)
        {
            // Apply vertical force to the rigidbody to make the character jump
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround_level_00 = false;
        }
        // Reset the isOnGround_level_00 flag after each jump
        yield return new WaitForSeconds(0.1f);
        isOnGround_level_00 = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground_level_00"))
        {
            isOnGround_level_00 = true;
        }
    }
    private void ResetBoxColliderSize()
    {
        boxCollider.size = originalSize;
    }
    private void Jump()
    {
        if (isOnGround_level_00)
        {
            // Trigger the "Jump" animation
            animator.SetTrigger("JumpOnce");
            animator.ResetTrigger("SlideOnce");
        }
    }
    private void Slide()
    {
        if (isOnGround_level_00)
        {
            // Trigger the "Slide" animation
            animator.SetTrigger("SlideOnce");
            animator.ResetTrigger("JumpOnce");
        }
    }
}