using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UserInputManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager m_raycastManager;
    [SerializeField] private GameObject m_holePrefab;
    private string m_name;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var position = new Vector2();
#if UNITY_EDITOR
            position = Input.mousePosition;
#else
            position = Input.GetTouch(0).position;
#endif

            var listOfHits = new List<ARRaycastHit>();
            if (m_raycastManager.Raycast(position, listOfHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                var hit = listOfHits[0];
                var positionOfHit = hit.pose.position;
                Instantiate(m_holePrefab, positionOfHit, Quaternion.identity);
            }
        }  
    }

    private string ReturnGameObjectName(GameObject _gameObject)
    {
        m_name = _gameObject.name;
        return m_name;
    }

    private bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
