using UnityEngine;

[CreateAssetMenu(fileName = "DialogObject", menuName = "Scriptable Objects/DialogObject")]
public class DialogObject : ScriptableObject
{
    [TextArea]
    public string[] dialogue;
}
