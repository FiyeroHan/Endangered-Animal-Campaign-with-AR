using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    public GameObject[] placeablePrefabs;

    Dictionary<string, GameObject> spawnedObjects;

    public TMP_Text debugText;

    public GameObject ARObjectHolder;
    void Awake()
    {
        ResetARObjectSpawn();
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }

    void UpdateSpawnObject(ARTrackedImage trackedImage)
    {
        string referenceImageName = trackedImage.referenceImage.name;

        spawnedObjects[referenceImageName].transform.position = trackedImage.transform.position;
        spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;

        spawnedObjects[referenceImageName].SetActive(true);
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    public void ResetARObjectSpawn()
    {
        //Debug.Log("ResetARObjectSpawn");

        spawnedObjects = new Dictionary<string, GameObject>();

        foreach(GameObject obj in placeablePrefabs)
        {
            GameObject newObject = Instantiate(obj);
            newObject.name = obj.name;
            newObject.SetActive(false);

            spawnedObjects.Add(newObject.name, newObject);
        }
    }

    public void DestroyARObjects()
    {
        //Debug.Log("DestroyARObjects");
    
        foreach(RectTransform child in ARObjectHolder.transform)
        {
            Destroy(child.gameObject);
        }

        spawnedObjects.Clear();
    }

    void Update()
    {
        debugText.text = "trackedImageManager.trackables.count: " + trackedImageManager.trackables.count.ToString();
    }
}
