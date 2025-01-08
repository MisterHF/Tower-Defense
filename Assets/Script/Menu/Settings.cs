using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using UnityEngine.UI;


namespace Menu
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private Slider masterVol;
        [SerializeField] private Slider musicVol;
        [SerializeField] private Slider sfxVol;
        [SerializeField] private AudioMixer mainAudioMixer;
        [SerializeField] private GameObject panelSettings;
        [SerializeField] private Toggle fullscreenToggle;

        private Resolution[] allResolutions;
        private bool isFullscreen;
        private int selectResolution;

        private List<Resolution> selectedResolutionList = new();

        private void Start()
        {
            Assert.IsNotNull(resolutionDropdown, "graphics dropdown is null in Settings");
            Assert.IsNotNull(masterVol, "master volume slider is null in Settings");
            Assert.IsNotNull(musicVol, "music volume slider is null in Settings");
            Assert.IsNotNull(sfxVol, "sfx volume slider is null in Settings");
            Assert.IsNotNull(mainAudioMixer, "main audio mixer is null in Settings");
            Assert.IsNotNull(panelSettings, "panel settings is null in Settings");

            isFullscreen = true;
            allResolutions = Screen.resolutions;

            List<string> resolutionStringList = new List<string>();
            string newRes;
            foreach (Resolution resolution in allResolutions) 
            { 
                newRes = resolution.width.ToString() + " x " + resolution.height.ToString();
                if (!resolutionStringList.Contains(newRes))
                {
                    resolutionStringList.Add(newRes);
                    selectedResolutionList.Add(resolution);
                }
            }
            resolutionDropdown.AddOptions(resolutionStringList);
        }

        public void ChangeResolution()
        {
            selectResolution = resolutionDropdown.value;
            Screen.SetResolution(selectedResolutionList[selectResolution].width, selectedResolutionList[selectResolution].height, isFullscreen);
        }
        public void ChangeFullsreen()
        {
            isFullscreen = fullscreenToggle.isOn;
            Screen.SetResolution(selectedResolutionList[selectResolution].width, selectedResolutionList[selectResolution].height, isFullscreen);
        }

        public void ChangeMasterVolume()
        {
            mainAudioMixer.SetFloat("Master", Mathf.Log10(masterVol.value) * 20);
        }

        public void ChangeMusicVolume()
        {
            mainAudioMixer.SetFloat("Music", Mathf.Log10(musicVol.value) * 20);
        }

        public void ChangeSfxVolume()
        {
            mainAudioMixer.SetFloat("SFX", Mathf.Log10(sfxVol.value) * 20);
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}