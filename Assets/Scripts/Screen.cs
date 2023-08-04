using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{    
   //public GameObject empty;
   //public GameObject PathFinding;

   Vector3 touchStart;
   public float zoomOutMin;
   public float zoomOutMax;
   //[SerializeField]
   public SpriteRenderer mapRenderer;
   private float mapMinX , mapMaxX , mapMinY, mapMaxY;

   bool Zoom;
   
   //public void Map(SpriteRenderer bg)
    void Start()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

   void Update()
   {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Zoom = false;
        }

        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch tuochOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 tuochOnePrevPos = tuochOne.position - tuochOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - tuochOnePrevPos).magnitude;
            float currenMagnitude = (touchZero.position - tuochOne.position).magnitude;

            float difference = currenMagnitude - prevMagnitude;

            zoom(difference*0.05f);

            Zoom = true;

        }else{
            if(Input.GetMouseButton(0) && !Zoom)
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Camera.main.transform.position += direction;
                Camera.main.transform.position = ClampCamera(Camera.main.transform.position + direction);
            }
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));

        //transform.position = Camera.main.transform.position;
   } 

   void zoom(float increment)
   {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax); 
        //Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
   }

   private Vector3 ClampCamera(Vector3 targetPosition)
   {
        float camHeight = Camera.main.orthographicSize;
        float camWidth = Camera.main.orthographicSize * Camera.main.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
   }
}
