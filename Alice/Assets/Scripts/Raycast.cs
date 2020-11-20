using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARRaycastManager))]
public class Raycast : MonoBehaviour
{
    private ARRaycastManager myRaycastManager;
    List<ARRaycastHit> planesHitList = new List<ARRaycastHit>();

    public GameObject prefabToInstantiate;
    public ARPlaneManager planeManager;
    private GameObject instantiatedObject;

    private bool deactivatePlanes;
    
    // Start is called before the first frame update
    void Start()
    {
        myRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began /* && instantiatedObject == null*/)
        {

            Vector2 touchPosition = Input.GetTouch(0).position;
            
            if (myRaycastManager.Raycast(touchPosition, planesHitList, TrackableType.PlaneWithinPolygon))
            {
                Pose planeHitPose = planesHitList[0].pose;
                //instantiatedObject = Instantiate(prefabToInstantiate, planeHitPose.position, planeHitPose.rotation);

                GameManager.Singleton.start = true;
                
                GameObject[] allPlanesInScene = GameObject.FindGameObjectsWithTag("ARPlanes");
                for (int i = 0; i < allPlanesInScene.Length; i++)
                {
                    allPlanesInScene[i].SetActive(false);
                }
                
                planeManager.enabled = false;
            }
        }
        
        
        /*if (instantiatedObject != null)
        {
            if (!deactivatePlanes)
            {
                EnableDisablePlanes(false);
                deactivatePlanes = true;
            }
        }
        else
        {
            if (deactivatePlanes)
            {
                EnableDisablePlanes(true);
                deactivatePlanes = false;
            }
        }*/
    }

    void EnableDisablePlanes(bool status)
    {
        GameObject[] allPlanesInScene = GameObject.FindGameObjectsWithTag("ARPlanes");
        for (int i = 0; i < allPlanesInScene.Length; i++)
        {
            allPlanesInScene[i].SetActive(status);
        }

        planeManager.enabled = status;

        GameManager.Singleton.start = status;
    }

    public void ResetSpawnObject()
    {
        Application.Quit();
        /*Destroy(instantiatedObject);
        instantiatedObject = null;*/
    }
}
