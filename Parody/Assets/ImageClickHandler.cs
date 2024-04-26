using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
   
public class ImageClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Image enlargedImagePrefab; // Asigna la imagen grande que deseas mostrar
    private Image currentEnlargedImage;
    private bool isDragging = false;
    private RectTransform rectTransform;
    private Vector3 originalScale;

    // Define los límites para cambiar el tamaño
    private const float enlargeThreshold = -59f;
    private const float originalThreshold = 68f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = transform.localScale;
    }

public void OnPointerDown(PointerEventData eventData)
{
    isDragging = true;
}

public void OnPointerUp(PointerEventData eventData)
{
    isDragging = false;
}

public void OnDrag(PointerEventData eventData)
{
    if (isDragging)
    {
        transform.position = eventData.position;

        if (transform.localPosition.x <= enlargeThreshold)
        {
                Debug.Log("Enlarging");
            transform.localScale = originalScale * 3f;
        }
        else if (transform.localPosition.x >= originalThreshold)
        {
                Debug.Log("Restoring");
            transform.localScale = originalScale;
        }
    }
}


}



