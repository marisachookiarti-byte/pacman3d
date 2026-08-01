using UnityEngine;
using Yarn.Unity;

public class dialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string[] node = { "Start","A", "B", "C", "D", "E" };
    public static int currentNode=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueRunner.StartDialogue(node[currentNode++]);
    }
}
