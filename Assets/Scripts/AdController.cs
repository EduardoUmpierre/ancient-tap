using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour {
    public string placementId = "rewardedVideo";

    private string gameId = "2771328";
    private Button ShowAdButton;

    // Use this for initialization
    void Start () {
        Advertisement.Initialize(gameId);
        ShowAdButton = gameObject.transform.Find("WatchVideoButton").GetComponent<Button>();

        if (ShowAdButton)
        {
            ShowAdButton.onClick.AddListener(ShowAd);
        }
    }
	
    // Update is called once per frame
    void Update () {
		if (ShowAdButton)
        {
            ShowAdButton.GetComponent<Button>().interactable = Advertisement.IsReady(placementId);
        }
    }

    //
    public void CloseAdContainer()
    {
        Destroy(gameObject);
    }

    //
    private void ShowAd()
    {
        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(placementId, options);
    }

    //
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
