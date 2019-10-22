using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    [SerializeField] public string SceneToLoad;
    
    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
        }
    }
}
