using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FocusDistAnimator : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    private DepthOfField _depthOfField;
    private float _focusDistance = 10f;

    private void Start()
    {
        postProcessVolume.profile.TryGetSettings(out _depthOfField);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_focusDistance <= 1f) return;
        _focusDistance -= Time.deltaTime * 0.25f;
        _depthOfField.focusDistance.value = _focusDistance;
    }
}
