using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField, Scene] private string scene;
    
    public void LoadScene() => SceneManager.LoadScene(scene, LoadSceneMode.Single);
}