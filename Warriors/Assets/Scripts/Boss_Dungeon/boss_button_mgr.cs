using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class boss_button_mgr : MonoBehaviour {

    public int boss0
    {
        get { return 0; }
    }

    public int boss1
    {
        get { return 1; }
    }

    public int boss2
    {
        get { return 2; }
    }
    public int boss3
    {
        get { return 3; }
    }
    public int boss4
    {
        get { return 4; }
    }
    public int boss5
    {
        get { return 5; }
    }
    public int boss6
    {
        get { return 6; }
    }
    public int boss7
    {
        get { return 7; }
    }
    public int boss8
    {
        get { return 8; }
    }
    public int boss9
    {
        get { return 9; }
    }
    public int boss10
    {
        get { return 10; }
    }

    public void boss_enter_clicked(int boss_index)
    {
        // Boss Index선택하여 해당 Boss던전으로 입장.
        switch(boss_index)
        {
            case 0:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
            break;
            case 1:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 2:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 3:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 4:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 5:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 6:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 7:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 8:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
            case 9:
                GM_Boss.boss_index = boss_index;
                print("boss index : " + boss_index.ToString());
                break;
        }
      

        // Boss Scene으로 입장.
        SceneManager.LoadScene ("warriors_boss");
    }



}
