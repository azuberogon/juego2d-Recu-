using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void loadscene(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }
}
