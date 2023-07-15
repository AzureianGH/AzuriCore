using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzuriCore.Logging;
/// <summary>
/// Used for finding objects in the scene
/// </summary>
namespace AzuriCore.Collision.Objects
{
    /// <summary>
    /// Azuri Objects
    /// </summary>
    
    public class AzuriOD : AzuriLog
    {
        /// <summary>
        /// Return all objects in the scene
        /// </summary>
        public GameObject[] AllObjects()
        {
            GameObject[] gos = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            if (gos == null)
            {
                WarningLog("AzuriOD", "No objects found");
            }
            else if (gos != null)
            {
                InfoLog("AzuriOD", "Found " + gos.Length + " objects");
            }
            return gos;
        }
        /// <summary>
        /// Return all objects with certain tag
        /// </summary>
        public GameObject[] AllObjectsWithTag(string tag)
        {
            GameObject[] gos = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            
            List<GameObject> gos2 = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.tag == tag)
                {
                    gos2.Add(go);
                }
            }
            // gos2.ToArray()
            GameObject[] gos3 = gos2.ToArray();
            if (gos2 == null)
            {
                WarningLog("AzuriOD", "No objects found with tag: " + tag);
            }
            else if (gos2 != null)
            {
                InfoLog("AzuriOD", "Found " + gos3.Length + " objects with tag: " + tag);
            }
            return gos3;
        }
        /// <summary>
        /// Return all objects with certain layer
        /// </summary>
        public GameObject[] AllObjectsWithLayer(int layer)
        {
            GameObject[] gos = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            List<GameObject> gos2 = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.layer == layer)
                {
                    gos2.Add(go);
                }
            }
            GameObject[] gos3 = gos2.ToArray();
            if (gos2 == null)
            {
                WarningLog("AzuriOD", "No objects found with layer: " + layer);
            }
            else if (gos2 != null)
            {
                InfoLog("AzuriOD", "Found " + gos3.Length + " objects with layer: " + layer);
            }
            return gos3;
        }
        /// <summary>
        /// Return all objects with certain name
        /// </summary>
        public GameObject[] AllObjectsWithName(string name)
        {
            GameObject[] gos = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            List<GameObject> gos2 = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.name == name)
                {
                    gos2.Add(go);
                }
            }
            GameObject[] gos3 = gos2.ToArray();
            if (gos2 == null)
            {
                WarningLog("AzuriOD", "No objects found with name: " + name);
            }
            else if (gos2 != null)
            {
                InfoLog("AzuriOD", "Found " + gos3.Length + " objects with name: " + name);
            }
            return gos3;
        }
        /// <summary>
        /// Return all objects with rigidbodies (3D)
        /// </summary>
        public GameObject[] AllObjectsWithRigidBody()
        {
            GameObject[] gos = AllObjects();
            // Check if the object has a rigidbody
            List<GameObject> gos2 = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.GetComponent<Rigidbody>() != null)
                {
                    gos2.Add(go);
                }
            }
            GameObject[] gos3 = gos2.ToArray();
            if (gos3.Length == 0)
            {
                WarningLog("AzuriOD", "No objects found with rigidbodies.");
            }
            else
            {
                InfoLog("AzuriOD", "Found " + gos3.Length + " objects with rigidbodies.");
            }
            return gos3;
        }
        /// <summary>
        /// Return all objects with rigidbodies (2D)
        /// </summary>
        public GameObject[] AllObjectsWithRigidBody2D()
        {
            GameObject[] gos = AllObjects();
            //Check if th object has a rigidbody
            List<GameObject> gos2 = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.GetComponent<Rigidbody2D>() != null)
                {
                    gos2.Add(go);
                }
            }
            GameObject[] gos3 = gos2.ToArray();
            if (gos2 == null)
            {
                WarningLog("AzuriOD", "No objects found with 2D rigidbodies.");
            }
            else if (gos2 != null)
            {
                InfoLog("AzuriOD", "Found " + gos3.Length + " objects with 2D rigidbodies.");
            }
            return gos3;
        }
        /// <summary>
        // Return all objects with a collider
        /// </summary>
        public GameObject[] AllObjectsWithCollider()
        {
            GameObject[] gos = AllObjects();
            //Check if th object has a rigidbody
            List<GameObject> gos2 = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.GetComponent<Collider>() != null)
                {
                    gos2.Add(go);
                }
            }
            GameObject[] gos3 = gos2.ToArray();
            if (gos2 == null)
            {
                WarningLog("AzuriOD", "No objects found with collider.");
            }
            else if (gos2 != null)
            {
                InfoLog("AzuriOD", "Found " + gos3.Length + " objects with colliders.");
            }
            return gos3;
        }
    }
}