using UnityEngine;
using SpeechLib;

public class TTS : MonoBehaviour
{
    public static bool TTSON = true;
    public static TTS instance;
    SpVoice voice = new SpVoice();

    private void Awake()
    {
        instance = this;
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
    }



    // step 2 add microsoft speech library version 11

}
// step 3 profit ?