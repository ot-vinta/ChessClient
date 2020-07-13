using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChess : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered " + other.gameObject + " | " + gameObject);
        
        if (other.rigidbody == null || gameObject.GetComponent<Collider>().attachedRigidbody == null)
            return;
        
        var thisVelocity = gameObject.GetComponent<Rigidbody>().velocity;
        var otherVelocity = other.rigidbody.velocity;
        
        var thisVelocityUnit = Math.Pow(thisVelocity.x, 2) + Math.Pow(thisVelocity.z, 2);
        var otherVelocityUnit = Math.Pow(otherVelocity.x, 2) + Math.Pow(otherVelocity.z, 2);
        
        if (!(thisVelocityUnit < otherVelocityUnit)) return;
        
        var position = gameObject.transform.position;
        var parent = gameObject.transform.parent;
        var prevRotation = gameObject.transform.rotation;
        var material = gameObject.GetComponent<MeshRenderer>().material;
        var rotation = Quaternion.Euler(prevRotation.eulerAngles.x + 90, prevRotation.eulerAngles.y, prevRotation.eulerAngles.z);
        
        var prefab = Resources.Load("Prefabs/Figures/BrokenPawn") as GameObject;
        
        AddMaterialToPrefab(material, prefab);
        
        Destroy(gameObject);
        Instantiate(prefab, position, rotation, parent);
    }

    private void AddMaterialToPrefab(Material material, GameObject prefab)
    {
        foreach (var child in prefab.GetComponentsInChildren<Transform>())
            if (!child.gameObject.name.Contains("BrokenPawn"))
            {
                child.GetComponent<MeshRenderer>().material = material;
            }
    }
}
