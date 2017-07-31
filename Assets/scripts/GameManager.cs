using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public CameraMovement cam;

    public GameObject startMenu;

    public dropper _dropper;

	// Use this for initialization
	void Awake () {
        instance = this;
	}
	
    public void firstDrop()
    {
        if(cam != null)
        {
            cam.canMove = true;
        }
    }

    public void lose()
    {
        print("Wow you lost");
    }

    public void startGame()
    {
        startMenu.SetActive(false);
        cam.gameObject.GetComponent<Animation>().Play();
        StartCoroutine(WaitForStartAnim());
        

    }

    private IEnumerator WaitForStartAnim()
    {
        yield return new WaitForSeconds(1f);
        _dropper.canDrop = true;
    }

}
