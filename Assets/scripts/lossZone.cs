using UnityEngine;

public class lossZone : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("dropable"))
        {
            GameManager.instance.lose();
        }
    }
}
