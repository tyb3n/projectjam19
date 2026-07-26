using FMODUnity;
using System.Collections;
using TMPro;
using UnityEngine;
using FMOD.Studio;
public class GameSystem : MonoBehaviour
{
    public GameObject DialogUI;
    public GameObject dialogdisplay;
    public TextMeshProUGUI textComponent;

    public string[] dialogue;
    public float textSpeed;
    private int index;

    [SerializeField] private EventReference textScrollSoundEvent;
    private EventInstance textScrollSoundInstance;

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

                // Stop scrolling text sound
                textScrollSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                textScrollSoundInstance.release();
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

        // Start scrolling text sound
        textScrollSoundInstance = RuntimeManager.CreateInstance(textScrollSoundEvent);
        textScrollSoundInstance.start();

        foreach (char c in dialogue[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Stop scrolling text sound
        textScrollSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        textScrollSoundInstance.release();

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
