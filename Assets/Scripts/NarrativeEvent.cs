using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NarrativeEvent", menuName = "Scriptable Objects/NarrativeEvent")]
public class NarrativeEvent : ScriptableObject
{

    [TextArea]
    public string initialText;

    public List<AbilityRequirement> abilityRequirements;
}
