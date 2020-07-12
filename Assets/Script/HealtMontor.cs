using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealtMontor : MonoBehaviour
{
    [SerializeField] private static ushort health;

    [SerializeField] private ushort maxHealth;

    private List<GameObject> hearts;

    public static ushort Health { get => health; set=> health = value; }

    // Start is called before the first frame update
    void Start()
    {
        const float spacingMulitplyer = 1.05f;

        Transform initialHeart = this.gameObject.transform.GetChild(0);

        RectTransform initialHeartRectTransform = initialHeart.GetComponent<RectTransform>();
        float width = initialHeartRectTransform.sizeDelta.x;

        for (int i = 1; i < this.maxHealth; i++)
        {
            Transform otherHeart = Instantiate(initialHeart);
            otherHeart.Translate(width * spacingMulitplyer * i,0,0, Space.Self);
            otherHeart.SetParent(this.transform, false);
        }

        foreach (Transform child in this.gameObject.transform)
        {
            this.hearts.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject heart in this.hearts)
        {
            var healthDisplayObject = heart.transform.GetChild(0);
            healthDisplayObject.gameObject.SetActive(health >= i);
            i++;
        }
    }
}
