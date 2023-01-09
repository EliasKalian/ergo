using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent EndEvent;
    public UnityEvent StartEvent;

    public void TriggerDialogue()
    {
        DaialogueManager d= FindObjectOfType<DaialogueManager>();
        if (d!=null)
        {
            d.startDialougue(dialogue);
            d.dialogueTrigger = this;
            StartEvent?.Invoke();

        }
    }


}
