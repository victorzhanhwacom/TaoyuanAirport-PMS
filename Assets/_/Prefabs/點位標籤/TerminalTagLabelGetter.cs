using UnityEngine;
using VzDev.ToolUtils;

public class TerminalTagLabelGetter : MonoBehaviour, IPointTagLabelGetter
{
    public string GetLabel(Transform targetModel)
    {
        if (targetModel == null)
        {
            Debug.LogWarning("Target model is null. Returning 'unknown' as label.", this);
            return "unknown";
        }
        if (targetModel.parent == null)
        {
            Debug.LogWarning($"Target model '{targetModel.name}' has no parent. Returning 'unknown' as label.", this);
            return "NoParent";
        }
        
        string[] parts = targetModel.parent.name.Split('_')[0].Split(':');
        return $"{parts[0]}\n{parts[1]}";
    }
}
