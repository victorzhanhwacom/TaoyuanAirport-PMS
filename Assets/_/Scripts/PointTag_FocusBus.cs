using System;
using UnityEngine;
using VzDev.ToolUtils;

public class PointTag_FocusBus : MonoBehaviour
{
    public event Action<bool, Transform> OnToggleStateChanged;
    public PointTag pointTag;
    public void SetToggleState(bool isOn)
    {
        OnToggleStateChanged?.Invoke(isOn, pointTag.FollowerTarget);
    }

    private void OnValidate()
    {
        if (pointTag == null)
            pointTag = GetComponent<PointTag>();
    }
}
