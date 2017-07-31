using UnityEngine;

public class dropper : MonoBehaviour {

    //PUBLIC VARIABLES
    public Transform spawnLocation;
    public GameObject[] dropObjects; [Space]
    public bool canDrop = false;

    //PRIVATE VARIABLES
    private GameObject currentObj;
    private Collider[] tempColliders;

	// Use this for initialization

    private void Update()
    {
        if(currentObj == null)
        {
            spawnObject(pickShape());
        }
    }

    private GameObject pickShape() //Randomly picks and returns an object
    {
        int num = Mathf.FloorToInt(Mathf.Floor(Random.Range(0, dropObjects.Length)));
        return dropObjects[num];
    }

    private void spawnObject(GameObject obj) //spawns the object passed in as a child of spawnLocation
    {
        if(canDrop)
        {
            if (currentObj != null)
            {
                Destroy(currentObj); //PLEASE FOR THE LOVE OF GOD POOL THIS
            }

            currentObj = Instantiate(obj, spawnLocation); //PLS POOL ME
            currentObj.GetComponent<Rigidbody>().isKinematic = true;
            currentObj.GetComponent<dropable>()._dropper = this;
            tempColliders = currentObj.GetComponentsInChildren<Collider>();
            toggleColliders(false);
        }
    }

    public void dropObj()
    {
        if(currentObj != null)
        {
            currentObj.transform.parent = null;
            currentObj.GetComponent<Rigidbody>().isKinematic = false;
            toggleColliders(true);
            currentObj = null;
            tempColliders = null;
        }
    }

    private void toggleColliders(bool toggle)
    {
        for(int i = 0; i < tempColliders.Length; i++)
        {
            tempColliders[i].isTrigger = !toggle;
        }
    }

}
