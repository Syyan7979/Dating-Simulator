using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "state")]

public class States : ScriptableObject
{
    // Configuration Parameters
    [SerializeField] string speaker;
    [TextArea(2, 5)][SerializeField] string[] DialogueMessage;
    [TextArea(2, 5)] [SerializeField] string[] choices;
    [SerializeField] States[] states;

    public States NextState(int index)
    {
        return states[index];
    }

    public string[] ChoicesReturn()
    {
        return choices;
    }

    public string[] DialogueReturn()
    {
        return DialogueMessage;
    }

    public string SpeakerReturn()
    {
        return speaker;
    }
}
