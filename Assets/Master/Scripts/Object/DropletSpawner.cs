using UnityEngine;

public class DropletSpawner : MonoBehaviour
{
    [SerializeField] private Transform m_AnchorDropletParent;
    [SerializeField] private GameObject m_DropletPrefab;

    
    public void SpawnDroplet()
    {
        if (m_DropletPrefab != null && m_AnchorDropletParent != null)
        {
            //Debug.Log("DropletSpawner");
            GameObject drop = Instantiate(m_DropletPrefab, m_AnchorDropletParent.position, Quaternion.identity);
            drop.transform.SetParent(m_AnchorDropletParent, true);
        }
    }
}
