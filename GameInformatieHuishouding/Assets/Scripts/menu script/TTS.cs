using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TTS : MonoBehaviour
{
    public static bool TTSON = true;
    public static TTS instance;
    SpVoice voice = new SpVoice();

    private void Start()
    {
        instance = this;
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

    public void CanTalk(bool canTalk)
    {
        TTSON = canTalk;
    }



    // step 2 add microsoft speech library version 11

}
// step 3 profit ?