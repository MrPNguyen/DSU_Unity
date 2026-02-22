using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler

{
    [SerializeField] private Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("open", true);
        animator.SetBool("close", false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("open", false);
        animator.SetBool("close", true);
    }
}
