using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private Dialogue dialogue;

    [SerializeField] public float moveSpeed = 5f;
    public float moveUpDistance = 1f;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    [SerializeField] private Direction direction;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        if(playerMovement == null)
        {
            Debug.LogError("PlayerMovement component not found in scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger.");
            playerMovement.canMove = false;

            if(DialogueManager.Instance != null && dialogue != null)
            {
                DialogueManager.Instance.StartDialogue(dialogue);
                StartCoroutine(MovePlayerAfterDialogue());
            }
            else
            {
                Debug.LogWarning("DialogueManager or Dialogue asset not assigned!");
            }
        }

    }
    private System.Collections.IEnumerator MovePlayerAfterDialogue()
    {
        while (!DialogueManager.Instance.DialogueEnd)
        {
            yield return null;
        }

        Debug.Log("Dialogue ended. Moving player...");

        // Store the player's current Z position
        float originalZ = playerMovement.transform.position.z;

        // Move the player up (only on the X and Y axes)
        Vector2 targetPosition = CalculateTargetPosition();

        Debug.Log("Player current position: " + playerMovement.transform.position);
        Debug.Log("Player target position: " + targetPosition);

        while (Vector2.Distance((Vector2)playerMovement.transform.position, targetPosition) > 0.1f)
        {
            // Move the player while keeping the Z position constant
            Vector3 newPosition = Vector2.MoveTowards(
                playerMovement.transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
            newPosition.z = originalZ; // Lock the Z position
            playerMovement.transform.position = newPosition;

            yield return null;
        }

        Debug.Log("Player reached target position.");

        // Re-enable player movement
        playerMovement.canMove = true;
    }

    private Vector2 CalculateTargetPosition()
    {
        Vector2 currentPosition = playerMovement.transform.position;

        switch (direction)
        {
            case Direction.Up:
                return currentPosition + Vector2.up * moveUpDistance;
            case Direction.Down:
                return currentPosition + Vector2.down * moveUpDistance;
            case Direction.Left:
                return currentPosition + Vector2.left * moveUpDistance;
            case Direction.Right:
                return currentPosition + Vector2.right * moveUpDistance;
            default:
                Debug.LogWarning("Invalid movement direction!");
                return currentPosition;
        }
    }
}

