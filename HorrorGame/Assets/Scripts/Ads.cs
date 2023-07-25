using System;
using Fungus;
using GamePush;
using UnityEngine;

public class Ads : MonoBehaviour
{
    [SerializeField] private Flowchart _flowchartEpisodes;
    [SerializeField] private Flowchart _flowchartSettings;

    private void Start()
    {
        GP_Ads.ShowSticky();
    }

    private void OnEnable()
    {
        GP_Game.OnPause += Pause;
        GP_Game.OnResume += Resume;
        GP_Ads.OnAdsStart += OnAdsStart;
        GP_Ads.OnAdsClose += OnAdsClose;
    }

    private void OnDisable()
    {
        GP_Game.OnPause -= Pause;
        GP_Game.OnResume -= Resume;
        GP_Ads.OnAdsStart -= OnAdsStart;
        GP_Ads.OnAdsClose -= OnAdsClose;
    }
    
    private void Pause() => _flowchartSettings.ExecuteBlock("SetVolumeMinIn0Sec");

    private void Resume()
    {
        _flowchartSettings.ExecuteBlock(_flowchartSettings.GetBooleanVariable("AudioOn")
            ? "SetVolumeMaxIn0Sec"
            : "SetVolumeMinIn0Sec");
    }

    public void ShowFullscreen() => GP_Ads.ShowFullscreen(OnFullscreenStart, OnFullscreenClose);

    // ��������� �����
    private void OnAdsStart()
    {
        //_flowchartSettings.ExecuteBlock("SetVolumeMinIn0Sec");
        Debug.Log("ON ADS: START");
    }

    // �������� �����
    private void OnAdsClose(bool success)
    {
        //_flowchartSettings.ExecuteBlock("SetVolumeMaxIn0Sec");
        Debug.Log("ON ADS: CLOSE");
    }

    private void OnFullscreenStart() => Debug.Log("ON FULLSCREEN START");
    private void OnFullscreenClose(bool success) => Debug.Log("ON FULLSCREEN CLOSE");


    public void ShowRewarded(string episode) =>
        GP_Ads.ShowRewarded(episode, OnRewardedReward, OnRewardedStart, OnRewardedClose);

    private void OnRewardedStart() => Debug.Log("ON REWARDED: START");

    private void OnRewardedReward(string value)
    {
        switch (value)
        {
            case "Ep_1":
                _flowchartEpisodes.ExecuteBlock("StartEp1");
                break;
            case "Ep_2":
                _flowchartEpisodes.ExecuteBlock("StartEp2");
                break;
            case "Ep_3":
                _flowchartEpisodes.ExecuteBlock("StartEp3");
                break;
            case "Ep_4":
                _flowchartEpisodes.ExecuteBlock("StartEp4");
                break;
        }
    }

    private void OnRewardedClose(bool success) => Debug.Log("ON REWARDED: CLOSE");
}