using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderMovement : MonoBehaviour
{

    [SerializeField] private bool isLadder;
    [SerializeField] private bool isClimbing;
    [SerializeField] private Rigidbody2D rb;
    public Button climbButton;

    void Start()
    {
        climbButton.onClick.AddListener(StartClimbing);
        climbButton.gameObject.SetActive(false);

    }

    void StartClimbing()
    {
        if (isLadder)
        {
             isClimbing = true; 
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            climbButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            climbButton.gameObject.SetActive(false);
        }
    }
}
