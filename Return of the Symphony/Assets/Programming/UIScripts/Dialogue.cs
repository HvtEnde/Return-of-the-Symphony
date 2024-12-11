using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //public TextMeshProUGUI textComponent;
    //public string[] lines;
    //public float textSpeed;

    //private int index;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    textComponent.text = string.Empty;
    //    StartDialogue();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (textComponent.text == lines[index])
    //        {
    //            NextLine();
    //        }
    //        else
    //        {
    //            StopAllCoroutines();
    //            textComponent.text = lines[index];
    //        }
    //    }
    //}

    //void StartDialogue()
    //{
    //    index = 0;
    //    StartCoroutine(TypeLine());
    //}

    //IEnumerator TypeLine()
    //{
    //    foreach (char c in lines[index].ToCharArray())
    //    {
    //        textComponent.text += c;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //}

    //void NextLine()
    //{
    //    if (index < lines.Length - 1)
    //    {
    //        index++;
    //        textComponent.text = string.Empty;
    //        StartCoroutine(TypeLine());
    //    }
    //    else
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isDialogueActive = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        isDialogueActive = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isDialogueActive = false;
            textComponent.text = string.Empty;
            gameObject.SetActive(false); // Verberg of deactiveer de dialoog
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Zorg dat de speler de tag "Player" heeft
        {
            StartDialogue();
        }
    }




}
