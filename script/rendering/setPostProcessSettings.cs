using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class setPostProcessSettings : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    LoadOptionInLevel loadOption;

    private Bloom bloom;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject();
        loadOption = gameObject.AddComponent<LoadOptionInLevel>();

        postProcessVolume.profile.TryGetSettings(out bloom);

        bloom.active = loadOption.isBloom;
    }
}
