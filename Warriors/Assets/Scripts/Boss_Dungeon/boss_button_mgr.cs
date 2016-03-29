using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class boss_button_mgr : MonoBehaviour {



    public void boss1_enter_clicked()
    {
        GM_Boss.boss_index = 0;
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene ("warriors_boss");
    }



}
