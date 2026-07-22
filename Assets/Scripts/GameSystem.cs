using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public GameObject DialogUI;
    public GameObject dialogdisplay;
    int i = 0;
    string[] dialogue;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogUI.SetActive(false);
        dialogue[0] = "Hello There!";
        dialogue[1] = "General Kenobi!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        // Ferme le jeu (ne fonctionne que dans le build, pas dans l'éditeur)
        Application.Quit();
    }

    public void StartDialog()
    {
        DialogUI.SetActive(true);
        i = 0;
    }

    public void ShowStatus()
    {
        
    }

    public void RunDialog()
    {
        if (dialogue[i] != null)
        {
            Debug.Log(dialogue[i]);
            dialogdisplay.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue[i];
            i++; 
        }
        else
        {
            DialogUI.SetActive(false);
        }
        
    }
}
