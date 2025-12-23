using UnityEngine;

public class TableDestroyerTrigger : BaseTrigger
{
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Droplet")
        {
            Destroy(other.gameObject);
        }

    }
}
    


