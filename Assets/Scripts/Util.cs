using UnityEngine;
using System.Collections;

public class Util
{
    public static void playAudio(AudioClip audio, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(audio, position);
    }
}
