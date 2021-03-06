﻿using UnityEngine;
using TMPro;

public class MaterialPickup : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    public int PlayerNumber = 1;

    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionStay(Collision other)
    {
        if(Input.GetKeyDown(Keys.GetKey(1+(PlayerNumber-1)*2)))
        {
            MaterialPickUpable materialPickUpable = other.gameObject.GetComponent<MaterialPickUpable>();
            if (materialPickUpable != null)
            {
                PlayerPrefs.SetInt(materialPickUpable.resourceType, PlayerPrefs.GetInt(materialPickUpable.resourceType) + materialPickUpable.resourceAmnt);
                //Destroy(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() => text.text = "Wood : " + PlayerPrefs.GetInt("Wood") + " " + "Nails : " + PlayerPrefs.GetInt("Nails");
}
