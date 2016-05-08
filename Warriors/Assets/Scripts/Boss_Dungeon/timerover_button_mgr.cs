using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class timerover_button_mgr : MonoBehaviour {

 	public void timeover_todungeon()
    {
        SceneManager.LoadScene("Warriors");
    }

    public void timeover_adsview_and_retry()
    {
        // To Do retry.
        // ads view and retry.
        
    }
}
