using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class unity_ads : MonoBehaviour
{
    public static GameObject ads_object;

    void Start()
    {
        ads_object = this.gameObject;
    }
    public void ShowRewardedAd()
    {
        print("in the ads func");
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
