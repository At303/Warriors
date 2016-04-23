using UnityEngine;
using System.Collections;

public class scene_loading : MonoBehaviour {

    private UISprite m_Fade;

    public float m_fDuration = 0.5f;
    public static GameObject getitem_window;
    public static GameObject item_drop_bgm_object;

    // Use this for initialization

    void Start()
    {
        // Item Drop시 popup window object.
        getitem_window = GameObject.Find("get_item_pop_window");
        item_drop_bgm_object = GameObject.Find("item_drop_bgm_object");

        // Item Drop 씬 BGM Play
        item_drop_bgm_object.GetComponent<AudioSource>().Play(0);

        m_Fade = GameObject.Find("FadeObject").GetComponent<UISprite>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        // Fade In
        TweenAlpha.Begin(m_Fade.gameObject, m_fDuration, 0.0f);
        yield return new WaitForSeconds(m_fDuration);
        NextSceneCall();

        // Fade Out
        //TweenAlpha.Begin(m_Fade.gameObject, m_fDuration, 1f);
        //yield return new WaitForSeconds(m_fDuration);

    }

    void NextSceneCall()
    {
        // Get Item popup window 띄워줌.
        boss_popup_window.enable_item_popup = true;
        getitem_window.SetActive(true);
    }

}
