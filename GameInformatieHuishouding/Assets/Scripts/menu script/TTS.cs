using UnityEngine;
using SpeechLib;
using UnityEditor;
using UnityEngine.SceneManagement;

public class TTS : MonoBehaviour
{
    public static bool TTSON = true;
    public static TTS instance;
    SpVoice voice = new SpVoice();
    public Camera camara;

    private void Awake()
    {
        instance = this;
        Camera.ToggleCameraLock();
        SetDutchVoice();
    }
    // step 1 use this code 
    public void Talk(string text)
    {
        if (TTSON == true)
        {
           voice.Speak(text, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
        }
        else
        {
            TTSON = false;
            Camera.BlindMode = false;
        }
    }

    private void SetDutchVoice()
    {
        foreach (SpObjectToken token in voice.GetVoices())
        {
            string languageId = token.GetAttribute("Language");

            if (languageId == "1043")
            {
                voice.Voice = token;
                Debug.Log("Dutch voice " + token.GetDescription());
                break;
            }
        }
    }

    public void CanTalk(bool canTalk)
    {
        TTSON = canTalk;
        Camera.BlindMode = true;
    }




    // step 2 add microsoft speech library version 11

}
// step 3 profit ?