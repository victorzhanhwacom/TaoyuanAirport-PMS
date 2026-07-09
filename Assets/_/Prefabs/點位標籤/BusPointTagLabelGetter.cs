using UnityEngine;
using VzDev.ToolUtils;

public class BusPointTagLabelGetter : MonoBehaviour, IPointTagLabelGetter
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

        return LabelSetter(targetModel);
        //return OldLabelSetter(targetModel);

    }

    private string LabelSetter(Transform targetModel)
    {
        string parentName = targetModel.parent.name;
        int roadNumber;
        switch (Random.Range(0, 3))
        {
            case 0:
                roadNumber = Random.Range(700, 999);
                return $"{roadNumber}A";
            case 1:
                roadNumber = Random.Range(700, 999);
                return $"{roadNumber}B";
            case 2:
                roadNumber = Random.Range(1800, 2000);
                return $"{roadNumber}";
        }
        return "unknown";
    }

    private string OldLabelSetter(Transform targetModel)
    {
        string parentName = targetModel.parent.name;
        int index = parentName.IndexOf("(");
        if (index != -1)
        {
            int roadNumber = Random.Range(1, 999);
            string roadType = Random.Range(0, 4) switch
            {
                0 => "綠",
                1 => "紅",
                2 => "藍",
                3 => "橘",
            };
            return $"{roadType}{roadNumber}";
            //return parentName.Substring(0, index) + $"-{roadType}{roadNumber}";
        }
        return parentName;
    }
}
