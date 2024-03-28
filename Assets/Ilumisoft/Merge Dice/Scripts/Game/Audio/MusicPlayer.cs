using Ilumisoft.MergeDice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : SingletonBehaviour<MusicPlayer>
{
    [SerializeField]
    private AudioSource _musicSource;


}
