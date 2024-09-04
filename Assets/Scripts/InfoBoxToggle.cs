using UnityEngine;

public class InfoBoxToggle : MonoBehaviour
{
    public GameObject infoBox;

    private bool isInfoBoxActive = false;

    public void ToggleInfoBox()
    {
        isInfoBoxActive = !isInfoBoxActive;
        infoBox.SetActive(isInfoBoxActive);
    }
}
