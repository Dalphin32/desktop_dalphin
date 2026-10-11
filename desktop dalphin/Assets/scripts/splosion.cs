using UnityEngine;

public class splosion : MonoBehaviour
{
    [SerializeField] private AudioClip splode_sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settings_data.DalSettings stgs = GameObject.Find("manager").GetComponent<settings_data>().get_settings();
        if (stgs.Sound){
            GameObject.Find("sound_player").GetComponent<AudioSource>().PlayOneShot(splode_sound,stgs.Volume);
        }   
    }
}
