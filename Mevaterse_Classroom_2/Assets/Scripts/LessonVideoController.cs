using UnityEngine;
using UnityEngine.Video;

public class LessonVideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    void Awake()
    {
        if (!videoPlayer) videoPlayer = GetComponent<VideoPlayer>();
        if (!videoPlayer)
        {
            Debug.LogError("[LessonVideoController] Nessun VideoPlayer trovato sul GameObject.");
            return;
        }

        // Impostazioni sicure
        videoPlayer.playOnAwake = false;
        videoPlayer.waitForFirstFrame = true;
        videoPlayer.skipOnDrop = true;
    }

    public void TogglePlayPause()
    {
        if (!videoPlayer) return;

        if (!videoPlayer.isPrepared)
        {
            videoPlayer.Prepare();
            // Avvia appena è pronto (comodo su alcuni device/URL)
            videoPlayer.prepareCompleted -= OnPreparedThenPlay;
            videoPlayer.prepareCompleted += OnPreparedThenPlay;
            Debug.Log("[LessonVideoController] Preparing...");
            return;
        }

        if (videoPlayer.isPlaying)
        {
            //videoPlayer.Pause();
            Debug.Log("[LessonVideoController] Paused Pressed but Temporarly Removed");
        }
        else
        {
            videoPlayer.Play();
            Debug.Log("[LessonVideoController] Playing");
        }
    }

    private void OnPreparedThenPlay(VideoPlayer vp)
    {
        vp.prepareCompleted -= OnPreparedThenPlay;
        vp.Play();
        Debug.Log("[LessonVideoController] Prepared -> Playing");
    }
}