using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private Door door;
    [SerializeField] private string nextLevel;
    [SerializeField] private bool needsKey = true;
    [SerializeField] private bool isMenuScene = false;

    public void KeyIsReached()
    {
        Debug.Log("Key is reached");
        door.Open();
    }

    public void DoorIsReached()
    {
        Debug.Log("Door is reached!");
        
        if(nextLevel != null)
            SceneManager.LoadScene(nextLevel);
    }

    private void Start()
    {
        if (!isMenuScene) DataManager.Save();
        
        // check for key
        if (key != null)
            key.manager = this;
        else if (key == null && needsKey)
            Debug.LogWarning("Level manager needs a key. Give a key.");

        // check for door
        if (door != null)
            door.manager = this;
        else
            Debug.LogWarning("Level manager needs a door; give door.");
    }
}
