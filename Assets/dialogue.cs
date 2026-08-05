using Pacman;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class dialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        dialogueRunner.StartDialogue(sceneName+"Dialogue");
    }
}
