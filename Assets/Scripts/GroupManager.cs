using UnityEngine;
using System.Collections;

public class GroupManager : MonoBehaviour
{
    public GameObject[] groups;
    public Transform[] entryPoints;
    public SceneTransitionManager transitionManager;

    public void SwitchGroup(string targetGroupName)
    {
        StartCoroutine(SwitchGroupCoroutine(targetGroupName));
    }

    private IEnumerator SwitchGroupCoroutine(string targetGroupName)
    {
        if (transitionManager != null)
        {
            yield return StartCoroutine(transitionManager.FadeOut());
        }

        for (int i = 0; i < groups.Length; i++)
        {
            if (groups[i].name == targetGroupName)
            {
                groups[i].SetActive(true);
                Camera.main.transform.position = entryPoints[i].position;
                Camera.main.transform.rotation = entryPoints[i].rotation;
            }
            else
            {
                groups[i].SetActive(false);
            }
        }

        if (transitionManager != null)
        {
            yield return StartCoroutine(transitionManager.FadeIn());
        }
    }
}
