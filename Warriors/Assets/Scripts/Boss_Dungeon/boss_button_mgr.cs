using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class boss_button_mgr : MonoBehaviour {

    public int boss1
    {
        get { return 0; }
    }

    public int boss2
    {
        get { return 1; }
    }

    public int boss3
    {
        get { return 2; }
    }


    public void boss_enter_clicked(int boss_index)
    {
        // Boss Index세팅해줌.
        GM_Boss.boss_index = boss_index;
        
        // Boss Scene으로 입장.
        SceneManager.LoadScene ("warriors_boss");
    }



}
