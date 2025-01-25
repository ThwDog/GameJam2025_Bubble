using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : SingletonClass<_SceneManager>
{
    private string current_Scene;
    private string previous_Scene;

    private void Update() {
        if( current_Scene != SceneManager.GetActiveScene().name ) current_Scene = SceneManager.GetActiveScene().name;
    }

    public void reLoadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void _nextScene(){
        if(current_Scene == "CutScene"){
            SceneManager.LoadScene(checkNextScene(previous_Scene));
        }
        else if(current_Scene == "EndGame"){
            shutdown();
        }
        else{
            SceneManager.LoadScene("CutScene");      
        }

        previous_Scene = SceneManager.GetActiveScene().name;

    }

    private string checkNextScene(string scene){
        switch(scene){
            case "Area01":
                return "Area02";
            case "Area02":
                return "Area03";
            case "Area03":
                return "EndGame";
        }
        return null;
    }

    public void shutdown(){
        Application.Quit();
    }
}
