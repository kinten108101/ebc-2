using UnityEngine;

[CreateAssetMenu(fileName = "XRCardboardInputSettings", menuName = "Google Cardboard/Cardboard Input Settings")]
public class XRCardboardInputSettings : ScriptableObject
{
    public string ClickInput => clickInputName;
    public float GazeTime => gazeTimeInSeconds;
    public float forwardSpeed => forwardMultiplier;
    public float sideSpeed => sideMultiplier;
    public bool scanParameters = true;

    [SerializeField]
    string clickInputName = "Submit";
    [SerializeField, Range(.5f, 5)]
    float gazeTimeInSeconds = 2f;
    [SerializeField, Range(0.1f,5f)]
    private float forwardMultiplier = 1.5f;
    [SerializeField, Range(0.1f,5f)]
    private float sideMultiplier = 1.1f;
}