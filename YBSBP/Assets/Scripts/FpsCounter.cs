using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public TMP_Text fpsText;

    private void Start(){
        Application.targetFrameRate = 60;
    }
    
    private void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int) (1f / timelapse);
        fpsText.text = string.Format(display, avgFramerate.ToString());
    }
}
