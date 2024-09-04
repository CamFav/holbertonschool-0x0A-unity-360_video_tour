// not working
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float gazeDuration = 1f;
    private float gazeTime;
    private bool isGazing;
    private RectTransform rectTransform;

    public float scaleFactor = 1.2f;

    private Vector3 originalScale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        originalScale = rectTransform.localScale;
    }

    private void Update()
    {
        if (isGazing)
        {
            gazeTime += Time.deltaTime;
            if (gazeTime >= gazeDuration)
            {
                OnGazeComplete();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isGazing = true;
        gazeTime = 0f;

        // Agrandir l'élément
        rectTransform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isGazing = false;
        gazeTime = 0f;

    
        rectTransform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("Gazed and clicked!");
    }

    private void OnGazeComplete()
    {
        OnPointerClick(null);
    }
}
