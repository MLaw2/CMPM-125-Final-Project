using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public static FootstepAudio instance;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource footstepPlayer;
    [SerializeField] private float footstepFrequency = 0.6f;
    [SerializeField] private float footstepSprintFrequency = 0.4f;
    private bool footstepCanPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }
        if (clips == null)
        {
            Debug.LogError("clips is undefined/there are no audio of clips");
        }
    }

    // calculate a random footstep sound to play
    public void PlayOneShot() {
        int clipID = Random.Range(0, clips.Length);
        footstepPlayer.PlayOneShot(clips[clipID]);

    }

    public IEnumerator PlayFootsteps() {
        if (footstepCanPlay) {
            footstepCanPlay = false;
            PlayOneShot();
            yield return new WaitForSeconds(footstepFrequency);
            footstepCanPlay = true;
        }
    }

    public IEnumerator PlaySprinting() {
        if(footstepCanPlay) {
            footstepCanPlay = false;
            PlayOneShot();
            yield return new WaitForSeconds(footstepSprintFrequency);
            footstepCanPlay = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
