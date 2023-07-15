using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzuriCore.Collision.Objects;
namespace AzuriCore.Collision
{
    /// <summary>
    /// Azuri Collision Detection
    /// </summary>
    public class AzuriCD : MonoBehaviour
    {
        public AzuriOD od;
        public bool ObjectToObject(GameObject firstobject, GameObject secondobject)
        {
            Collider firstCollider = firstobject.GetComponent<Collider>();
            Collider secondCollider = secondobject.GetComponent<Collider>();

            if (firstCollider != null && secondCollider != null)
            {
                return firstCollider.bounds.Intersects(secondCollider.bounds);
            }

            return false;
        }

        public bool ObjectToTag(GameObject firstobject, string tag)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject taggedObject in taggedObjects)
            {
                if (ObjectToObject(firstobject, taggedObject))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToLayer(GameObject firstobject, string layer)
        {
            int layerMask = LayerMask.NameToLayer(layer);
            Collider[] colliders = Physics.OverlapSphere(firstobject.transform.position, 0.01f, layerMask);

            return colliders.Length > 0;
        }

        public bool TagToTag(string firsttag, string secondtag)
        {
            GameObject[] firstTaggedObjects = GameObject.FindGameObjectsWithTag(firsttag);
            GameObject[] secondTaggedObjects = GameObject.FindGameObjectsWithTag(secondtag);

            foreach (GameObject firstTaggedObject in firstTaggedObjects)
            {
                foreach (GameObject secondTaggedObject in secondTaggedObjects)
                {
                    if (ObjectToObject(firstTaggedObject, secondTaggedObject))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool TagToLayer(string tag, string layer)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            int layerMask = LayerMask.NameToLayer(layer);

            foreach (GameObject taggedObject in taggedObjects)
            {
                Collider[] colliders = taggedObject.GetComponentsInChildren<Collider>();

                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject.layer == layerMask)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool LayerToLayer(string firstlayer, string secondlayer)
        {
            int firstLayerMask = LayerMask.NameToLayer(firstlayer);
            int secondLayerMask = LayerMask.NameToLayer(secondlayer);

            Collider[] firstColliders = Physics.OverlapSphere(Vector3.zero, 0.01f, firstLayerMask);
            Collider[] secondColliders = Physics.OverlapSphere(Vector3.zero, 0.01f, secondLayerMask);

            foreach (Collider firstCollider in firstColliders)
            {
                foreach (Collider secondCollider in secondColliders)
                {
                    if (firstCollider.bounds.Intersects(secondCollider.bounds))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        
        public bool ObjectToAll(GameObject firstobject)
        {
            GameObject[] allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

            foreach (GameObject obj in allObjects)
            {
                if (obj != firstobject && ObjectToObject(firstobject, obj))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TagToAll(string tag)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            GameObject[] allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

            foreach (GameObject taggedObject in taggedObjects)
            {
                foreach (GameObject obj in allObjects)
                {
                    if (obj != taggedObject && ObjectToObject(taggedObject, obj))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool LayerToAll(string layer)
        {
            int layerMask = LayerMask.NameToLayer(layer);
            Collider[] colliders = Physics.OverlapSphere(Vector3.zero, 0.01f);

            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.layer != layerMask && ObjectToLayer(collider.gameObject, layer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToObjects(GameObject firstobject, GameObject[] secondobjects)
        {
            foreach (GameObject secondobject in secondobjects)
            {
                if (ObjectToObject(firstobject, secondobject))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToTags(GameObject firstobject, string[] tags)
        {
            foreach (string tag in tags)
            {
                if (ObjectToTag(firstobject, tag))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToLayers(GameObject firstobject, string[] layers)
        {
            foreach (string layer in layers)
            {
                if (ObjectToLayer(firstobject, layer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TagToTags(string firsttag, string[] secondtags)
        {
            foreach (string secondtag in secondtags)
            {
                if (TagToTag(firsttag, secondtag))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TagToLayers(string tag, string[] layers)
        {
            foreach (string layer in layers)
            {
                if (TagToLayer(tag, layer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool LayerToLayers(string firstlayer, string[] secondlayers)
        {
            foreach (string secondlayer in secondlayers)
            {
                if (LayerToLayer(firstlayer, secondlayer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToAllExcept(GameObject firstobject, GameObject[] exceptobjects)
        {
            GameObject[] allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            foreach (GameObject secondobject in allObjects)
            {
                if (!ArrayContains(exceptobjects, secondobject) && ObjectToObject(firstobject, secondobject))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TagToAllExcept(string tag, string[] excepttags)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject otherTag in taggedObjects)
            {
                if (!ArrayContains(excepttags, otherTag.tag) && TagToTag(tag, otherTag.tag))
                {
                    return true;
                }
            }

            return false;
        }

        public bool LayerToAllExcept(string layer, string[] exceptlayers)
        {
            int layerMask = LayerMask.NameToLayer(layer);
            Collider[] colliders = Physics.OverlapSphere(Vector3.zero, 0.01f);

            foreach (Collider collider in colliders)
            {
                if (!ArrayContains(exceptlayers, LayerMask.LayerToName(collider.gameObject.layer)) && ObjectToLayer(collider.gameObject, layer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToObjectsExcept(GameObject firstobject, GameObject[] secondobjects, GameObject[] exceptobjects)
        {
            foreach (GameObject secondobject in secondobjects)
            {
                if (!ArrayContains(exceptobjects, secondobject) && ObjectToObject(firstobject, secondobject))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToTagsExcept(GameObject firstobject, string[] tags, string[] excepttags)
        {
            foreach (string tag in tags)
            {
                if (!ArrayContains(excepttags, tag) && ObjectToTag(firstobject, tag))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ObjectToLayersExcept(GameObject firstobject, string[] layers, string[] exceptlayers)
        {
            foreach (string layer in layers)
            {
                if (!ArrayContains(exceptlayers, layer) && ObjectToLayer(firstobject, layer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TagToTagsExcept(string tag, string[] tags, string[] excepttags)
        {
            foreach (string otherTag in tags)
            {
                if (!ArrayContains(excepttags, otherTag) && TagToTag(tag, otherTag))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TagToLayersExcept(string tag, string[] layers, string[] exceptlayers)
        {
            foreach (string layer in layers)
            {
                if (!ArrayContains(exceptlayers, layer) && TagToLayer(tag, layer))
                {
                    return true;
                }
            }

            return false;
        }

        public bool LayerToLayersExcept(string layer, string[] layers, string[] exceptlayers)
        {
            foreach (string otherLayer in layers)
            {
                if (!ArrayContains(exceptlayers, otherLayer) && LayerToLayer(layer, otherLayer))
                {
                    return true;
                }
            }

            return false;
        }
        public GameObject GetObjectCollidingWith(GameObject obj)
        {
            GameObject[] gos = od.AllObjects();
            foreach (GameObject go in gos)
            {
                if (go != obj && ObjectToObject(obj, go))
                {
                    return go;
                }
            }
            return null;
        }
        public GameObject GetObjectWithRigidBodyCollidingWith(GameObject obj)
        {
            GameObject[] gos = od.AllObjectsWithRigidBody();
            foreach (GameObject go in gos)
            {
                if (go != obj && ObjectToObject(obj, go))
                {
                    return go;
                }
            }
            return null;
        }


        private bool ArrayContains<T>(T[] array, T element)
        {
            foreach (T item in array)
            {
                if (item.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
