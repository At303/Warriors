using UnityEngine;
using System.Collections;

public class boss_popup_window : MonoBehaviour {

    public GameObject label_;
    public UISprite sprite_;

    void Start()
    {
       

        setDisable();
    }

    //SetActive(true) 호출 시 실행됩니다.
    void OnEnable()
    {
        // Boss Kill시 popup창에서 사용할 Label && Sprite.
        label_ = GameObject.Find("get_item_label");
        sprite_ = GameObject.Find("get_item_sprite").GetComponent<UISprite>();

        open();
    }
    //SetActive(false) 호출 시 실행됩니다.
    void OnDisable()
    {
        close();
    }

    // 팝업 열기
    void open()
    {
        
        switch(GM_Boss.boss_index)
        {
            // 30% : 단검 , 30% : 활1 , 30% 꽝.
            case 0:
                float select_val = 0f;
                select_val = Random.Range(0, 100);
                if(select_val < 100)
                {
                    // 단검 enable
                    //index에 해당하는 무기의 lock sprite를 false시켜줌. ( boss_index도 어차피 weapon_index랑 같음. )
                    string weapon_enable_str = "weapon" + GM_Boss.boss_index.ToString() + "_enable";
                    PlayerPrefs.SetInt(weapon_enable_str, 0);
                    PlayerPrefs.Save();

                    // Label update.
                    label_.GetComponent<UILabel>().text = "단검 획득!!";

                    // sprite update.
                    // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
                    string weapon_sprite_str = "weapon" + GM_Boss.boss_index.ToString() + "_icon";

                    sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    sprite_.spriteName = weapon_sprite_str;
                    sprite_.MakePixelPerfect();

                    // pop 창 띄우기.
                    init();
                }
                else if(30 < select_val && select_val < 60)
                {
                    // To Do...
                    // 활1 enable.
                }else
                {

                    // Label update.
                    label_.GetComponent<UILabel>().text = "무기 획득 실패...";
                    // To Do..
                    // 꽝.
                    // sprite update.
                    // 무기 장착 메뉴에서 무기의 type과 index를 to_change 구조체에 미리 저장해두고 여기서 가져와서 해당 무기 장착 sprite로 바꿔줌.
                    string weapon_sprite_str = "Fail";

                    sprite_.atlas = Resources.Load<UIAtlas>("BackgroundAtlas");
                    sprite_.spriteName = weapon_sprite_str;
                    sprite_.MakePixelPerfect();

                }
                break;
        } 
      

    }

    float duration = 0.2f; // 애니메이션의 길이입니다.(시간)
    float startDelay = 0.2f; // 애니메이션 시작 전 딜레이입니다.
    Vector3 scaleTo = new Vector3(1f, 1f, 1f); // 오브젝트의 최종 Scale 입니다.

    // 부풀었다가 줄어드는 효과를 위한 AnimationCurve 입니다.
    AnimationCurve animationCurve = new AnimationCurve(
    new Keyframe(0f, 0f, 0f, 1f), // 0%일때 0의 값에서 시작해서 
    new Keyframe(0.7f, 1.2f, 1f, 1f), // 애니메이션 시작후 70% 지점에서 1.2의 사이즈까지 커졌다가 
    new Keyframe(1f, 1f, 1f, 0f)); // 100%로 애니메이션이 끝날때는 1.0의 사이즈가 됩니다.

    // 초기화
    void init()
    {
        TweenScale tween = TweenScale.Begin(gameObject, duration, scaleTo);
        tween.duration = duration;
        tween.delay = startDelay;
        //tween.method = UITweener.Method.BounceIn; // AnimationCurve 대신 이것도 한번 써보세요.
        tween.animationCurve = animationCurve;

    }

    // 팝업 닫기
    public void close()
    {
        setDisable();
    }

    // 오브젝트 Disable
    void setDisable()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }
}
