using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;
using UnityEngine.Events;

public class TTS : MonoBehaviour
{
    public static TTS instance;
    SpVoice voice = new SpVoice();

    private void Start()
    {
        instance = this;
    }

    public void Talk(string text)
    {
        voice.Speak(text, SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);

    }
}
