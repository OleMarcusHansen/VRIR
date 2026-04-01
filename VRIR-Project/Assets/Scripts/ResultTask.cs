using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultTask : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;

    public void Setup(string taskName, Color color)
    {
        text.text = taskName;
        image.color = color;
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }
}
