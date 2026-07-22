using UnityEngine;
using System.Collections;
using TMPro;
public class GameSystem : MonoBehaviour
{
    public GameObject DialogUI;
    public GameObject dialogdisplay;
    public TextMeshProUGUI textComponent;

    public string[] dialogue;
    public float textSpeed;
    private int index;
    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogue[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogue[index];
            }
        }
    }

    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void ShowStatus()
    {

    }
    void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogdisplay.SetActive(false);
        }
    }
}
