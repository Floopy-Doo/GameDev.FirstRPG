using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    [SerializeField]
    private AudioSource collectSound;

    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    public void Update()
    {
        this.transform.Rotate(new Vector3(0,1,0), this.rotationSpeed);
    }

    public void OnTriggerEnter()
    {
        this.collectSound?.Play();
        this.gameObject.SetActive(false);

        HealtMontor.Health += 1;
    }
}