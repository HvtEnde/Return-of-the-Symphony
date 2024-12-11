using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public int dialoguePart;
    public float textSpeed;
    public float textWait;
    public bool dialogueCheckStart;
    public bool dialogueCheckEnd;

    public TextMeshProUGUI textComponent;
    public string[] linesStart;
    public string[] linesEnd;
    int currentLine;

    void Start()
    {
        textComponent.text = string.Empty;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        switch (dialoguePart)
        {
            case 0:
                if (!dialogueCheckStart)
                {
                    StartCoroutine(TypeLineStart());
                    dialogueCheckStart = true;
                }

                break;
            case 1:
                if (!dialogueCheckEnd)
                {
                    StartCoroutine(TypeLineEnd());
                    dialogueCheckEnd = true;
                }
                break;

            default:
                Debug.LogWarning("Int out of bounds (Dialogue Manager Switch)");
                break;
        }
    }

    IEnumerator TypeLineStart()
    {
        foreach (string lines in linesStart) 
        {
            currentLine++;

            foreach (char c in linesStart[currentLine -1].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            yield return new WaitForSeconds(textWait);
            textComponent.text = string.Empty;
        }

        currentLine = 0;
    }
    IEnumerator TypeLineEnd()
    {
        foreach (string lines in linesEnd)
        {
            currentLine++;

            foreach (char c in linesEnd[currentLine - 1].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            yield return new WaitForSeconds(textWait);
            textComponent.text = string.Empty;
        }

        currentLine = 0;
    }
}
