using UnityEngine;

public class SpawnControl : MonoBehaviour {




    //PRIVATE VARIABLES
    const int DIST_CLAMP = 5;

    [SerializeField] private Transform spawnLocation;
    private Vector3 inputPos;
    private Camera cam;
    private dropper _dropper;
    private bool firstDrop = true;

    //PUBLIC VARIABLES
    public float sensitivity = 5f;

    private void Start()
    {
        cam = GetComponent<Camera>();
        _dropper = GetComponent<dropper>();
    }

    // Update is called once per frame
    void Update () {
        moveSpawner();
        getInput();
	}

    void moveSpawner()
    {
        inputPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        inputPos.z = 0;
        //print(inputPos);
        inputPos *= sensitivity;
        inputPos.x = Mathf.Clamp(inputPos.x, -DIST_CLAMP, DIST_CLAMP);
        spawnLocation.position = new Vector3(inputPos.x, spawnLocation.position.y, spawnLocation.position.z);
    }

    void getInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(firstDrop)
            {
                print("did this work?");
                GameManager.instance.firstDrop();
                firstDrop = false;
            }

            if(_dropper.canDrop)
                _dropper.dropObj();
        }
    }
}
