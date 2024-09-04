using UnityEngine;
using UnityEngine.Video;

public class VideoLoop : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.playOnAwake = true;

        videoPlayer.loopPointReached += OnLoopPointReached;
    }

    void OnLoopPointReached(VideoPlayer vp)
    {
        vp.frame = 0;
        vp.Play();
    }
}
