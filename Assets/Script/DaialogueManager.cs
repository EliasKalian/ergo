using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DaialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    [SerializeField] DialogueTrigger startD;
    [SerializeField] AudioSource source;

    [SerializeField] AudioClip TWsound;
    [SerializeField] AudioClip TWsoundEnd;
    [SerializeField] AudioClip nextTw;

    public  DialogueTrigger dialogueTrigger;

    [SerializeField] float waitTime=0.1f;
    [SerializeField] Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        startD.TriggerDialogue();
    }


    public void startDialougue(Dialogue dialogue)
    {
        
        nameText.text = dialogue.name;
        sentences.Clear();
       

        foreach (string sentece in dialogue.Sentences)
        {
            sentences.Enqueue(sentece);

        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        source.PlayOneShot(nextTw);
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
       string sentence= sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
      
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            float t = Random.Range(0, waitTime);
            source.pitch = Random.Range(.5f,.8f);
            source.PlayOneShot(TWsound);
           
            yield return new WaitForSeconds(waitTime+t);
        }
        source.PlayOneShot(TWsoundEnd);
    }
    void EndDialogue()
    {
        
      //  Debug.Log("End of conversation");
        dialogueTrigger.EndEvent?.Invoke();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
