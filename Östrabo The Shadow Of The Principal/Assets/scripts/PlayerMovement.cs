using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float moveSpeed = 5f;
    private Transform playerTransform;
    private Vector2 targetPosition;

    private Vector2 movementDirection;
    private Vector2 currentInput;

    [SerializeField] AudioSource audioSource;

    [Header("Animations")]
    [SerializeField] private Animator anim;
    private string lastDirection = "Down";

    private Rigidbody2D rb;

    public bool canMove = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HandleAnimations();

        if(rb.linearVelocity.x != 0 || rb.linearVelocity.y != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void FixedUpdate()
    {
        if (!canMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

       
            rb.linearVelocity = movementDirection * moveSpeed;
    }

    private void HandleAnimations()
    {
        if (anim == null) return;

        string animationName = "";

        if (movementDirection == Vector2.zero)
            animationName = "Idle";
        else
            animationName = "Walking";

        anim.Play(animationName + lastDirection);
    }
    private Vector3 GetDirection(Vector3 input)
    {
        Vector3 finalDirection = Vector2.zero;
        if (input.y > 0.01f)
        {
            lastDirection = "Up";
            finalDirection = new Vector2(0, 1);
        }
        else if (input.y < -0.01f)
        {
            lastDirection = "Down";
            finalDirection = new Vector2(0, -1);
        }
        else if (input.x > 0.01f)
        {
            lastDirection = "Right";
            finalDirection = new Vector2(1, 0);
        }
        else if (input.x < -0.01f)
        {
            lastDirection = "Left";
            finalDirection = new Vector2(-1, 0);
        }
        else
            finalDirection = Vector2.zero;

        return finalDirection;
    }
    #region Input
    private void OnMovement(InputValue value)
    {
        currentInput = value.Get<Vector2>().normalized;
        movementDirection = GetDirection(currentInput);
    }
    #endregion
}
