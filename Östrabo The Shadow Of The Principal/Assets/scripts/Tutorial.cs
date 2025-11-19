using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public float displayTime = 3f; // Time in seconds before hiding
    private CanvasGroup canvasGroup; // For smooth fading (optional)

    void Start()
    {
        // Get or add a CanvasGroup for fading (optional)
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Start the hiding coroutine
        StartCoroutine(HideAfterDelay());
    }

    private System.Collections.IEnumerator HideAfterDelay()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(displayTime);

        // Option 1: Simply deactivate the GameObject
        gameObject.SetActive(false);

        // Option 2: Fade out smoothly (uncomment if desired)
        float fadeDuration = 1f;
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
