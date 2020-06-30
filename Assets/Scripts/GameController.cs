using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public ThirdPersonCharacterController player;
    public ThirdPersonCameraController cameraController;

    private bool battleMusicPlaying;
    private bool backgroundMusicPlaying;
    public AudioSource battleMusic;
    public AudioSource backgroundMusic;

    public bool allowCameraControl;

    private void Start()
    {
        allowCameraControl = true;
    }

    private void Update()
    {
        if (player.getHS().getHealth() <= 0){
            playerDead();
        }
        controlMusic();
    }

    private void controlMusic()
    {
        if (player.combatDelay > 0 && battleMusicPlaying == false)
        {
            backgroundMusic.Pause();
            backgroundMusicPlaying = false;

            battleMusic.Play();
            battleMusicPlaying = true;
        }

        if (player.combatDelay <= 0)
        {
            battleMusic.Stop();
            battleMusicPlaying = false;

            if (backgroundMusicPlaying == false)
            {
                backgroundMusic.UnPause();
                backgroundMusicPlaying = true;
            }
        }
    }

    private void playerDead()
    {
        SceneManager.LoadScene("Death");
    }
}
