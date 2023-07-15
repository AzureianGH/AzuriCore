using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AzuriCore.Sounds
{
    /// <summary>
    /// Azuri Sound Manager, this class is used to manage all the sounds in the game.
    /// </summary>
    public class AzuriSM : MonoBehaviour
    {
        public GameObject CreateSoundInstance(AudioClip audio)
        {
            //Create a new gameobject (Empty called SoundInstance)
            GameObject soundInstance = new GameObject("SoundInstance");
            //Add the AudioSource component to the gameobject
            soundInstance.AddComponent<AudioSource>();
            //Add audio to the AudioSource component
            soundInstance.GetComponent<AudioSource>().clip = audio;
            //Return the gameobject
            return soundInstance;
        }
        //Add location to the function
        public GameObject CreateSoundInstance(AudioClip audio, Vector3 location)
        {
            //Create a new gameobject (Empty called SoundInstance)
            GameObject soundInstance = new GameObject("SoundInstance");
            //Add the AudioSource component to the gameobject
            soundInstance.AddComponent<AudioSource>();
            //Add audio to the AudioSource component
            soundInstance.GetComponent<AudioSource>().clip = audio;
            //Set the location of the gameobject
            soundInstance.transform.position = location;
            //Return the gameobject
            return soundInstance;
        }
        public GameObject CreateSoundInstance(AudioClip audio, Vector3 location, GameObject parent)
        {
            //Create a new gameobject (Empty called SoundInstance)
            GameObject soundInstance = new GameObject("SoundInstance");
            //Add the AudioSource component to the gameobject
            soundInstance.AddComponent<AudioSource>();
            //Add audio to the AudioSource component
            soundInstance.GetComponent<AudioSource>().clip = audio;
            //Set the location of the gameobject
            soundInstance.transform.position = location;
            //Set the parent of the gameobject
            Transform locparent = parent.transform;
            soundInstance.transform.SetParent(locparent);
            //Return the gameobject
            return soundInstance;
        }
        public GameObject ChangeSoundInstance(GameObject soundInstance, AudioClip audio)
        {
            //Add audio to the AudioSource component
            soundInstance.GetComponent<AudioSource>().clip = audio;
            //Return the gameobject
            return soundInstance;
        }
    }
}