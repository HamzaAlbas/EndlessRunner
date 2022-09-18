using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
