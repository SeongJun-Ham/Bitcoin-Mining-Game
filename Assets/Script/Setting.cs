using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Setting : MonoBehaviour
{
    public int clickedButton;
    private GameObject settingPanel, settingButton1, settingButton2;

    public Sprite[] soundSprites;
    //bgm包访
    public Image imageBgmVolume;
    public string[] bgmVolumeTexts;
    public Text textBgmVolume;
    //soundEffect包访
    public Image imageSoundEffectVolume;
    public string[] soundEffectVolumeTexts;
    public Text textSoundEffectVolume;
    //Volume包访
    public AudioSource bgmVolume;

    public GameSystem scriptGameSystem;

    // Start is called before the first frame update
    void Start()
    {
        settingPanel = GameObject.Find("PopupPanels").transform.Find("SettingPanel").gameObject;
        if (!scriptGameSystem) scriptGameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        if (!bgmVolume) bgmVolume = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        bgmVolume.GetComponent<AudioSource>().volume = 0.03f * Convert.ToSingle(scriptGameSystem.currentBgmVolume);
    }

    // Update is called once per frame
    void Update()
    {

    }

    async public void OnClickEvent()
    {
        ShowSetting();
        var task = Task.Run(() => GetClickedButton());
        int clickedButton = await task;

        if (clickedButton == 0)
        {
            //TODO: 技泼 历厘
        }
    }

    public void OnClickBoxButton(int index)
    {
        HideYesOrNoMsgbox();
        clickedButton = index;
    }
    public void ShowSetting()
    {
        clickedButton = -1;
        settingPanel.SetActive(true);
        if (!scriptGameSystem) scriptGameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        //bgmVolume
        imageBgmVolume = GameObject.Find("BgmVolumeImage").GetComponent<Image>();
        imageBgmVolume.GetComponent<Image>().sprite = soundSprites[scriptGameSystem.currentBgmVolume];
        textBgmVolume = GameObject.Find("BgmVolumeText").GetComponent<Text>();
        textBgmVolume.GetComponent<Text>().text = bgmVolumeTexts[scriptGameSystem.currentBgmVolume];
        //soundEffectVolume
        imageSoundEffectVolume = GameObject.Find("SoundEffectVolumeImage").GetComponent<Image>();
        imageSoundEffectVolume.GetComponent<Image>().sprite = soundSprites[scriptGameSystem.currentSoundEffectVolume];
        textSoundEffectVolume = GameObject.Find("SoundEffectVolumeText").GetComponent<Text>();
        textSoundEffectVolume.GetComponent<Text>().text = soundEffectVolumeTexts[scriptGameSystem.currentSoundEffectVolume];
    }

    private void HideYesOrNoMsgbox()
    {
        settingPanel.SetActive(false);
    }

    public int GetClickedButton()
    {
        while (clickedButton == -1)
        {

        }
        return clickedButton;
    }

    public void SetBgmVolume()
    {
        if (!scriptGameSystem) scriptGameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        if (!imageBgmVolume) imageBgmVolume = GameObject.Find("BgmVolumeImage").GetComponent<Image>();
        if (!textBgmVolume) textBgmVolume = GameObject.Find("BgmVolumeText").GetComponent<Text>();
        if (!bgmVolume) bgmVolume = GameObject.Find("MainCamera").GetComponent<AudioSource>();

        scriptGameSystem.currentBgmVolume += 1;
        if (soundSprites.Length == scriptGameSystem.currentBgmVolume)
        {
            scriptGameSystem.currentBgmVolume = 0;
        }
        bgmVolume.GetComponent<AudioSource>().volume = 0.03f * Convert.ToSingle(scriptGameSystem.currentBgmVolume);
        imageBgmVolume.GetComponent<Image>().sprite = soundSprites[scriptGameSystem.currentBgmVolume];
        textBgmVolume.GetComponent<Text>().text = bgmVolumeTexts[scriptGameSystem.currentBgmVolume];
    }

    public void SetSoundEffectVolume()
    {
        if (!scriptGameSystem) scriptGameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        if (!imageSoundEffectVolume) imageSoundEffectVolume = GameObject.Find("SoundEffectVolumeImage").GetComponent<Image>();
        if (!textSoundEffectVolume) textSoundEffectVolume = GameObject.Find("SoundEffectVolumeText").GetComponent<Text>();

        scriptGameSystem.currentSoundEffectVolume += 1;
        if (soundSprites.Length == scriptGameSystem.currentSoundEffectVolume)
        {
            scriptGameSystem.currentSoundEffectVolume = 0;
        }
        imageSoundEffectVolume.GetComponent<Image>().sprite = soundSprites[scriptGameSystem.currentSoundEffectVolume];
        textSoundEffectVolume.GetComponent<Text>().text = soundEffectVolumeTexts[scriptGameSystem.currentSoundEffectVolume];

    }
}
