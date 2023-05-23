using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementHandler : MonoBehaviour
{
   [SerializeField] private Vector3 camOffset;
   [SerializeField] private float camLerpSpeed = 0.125f;
   [SerializeField] private float scrollFactor = 1.1f;
   
   private Transform m_TargetTransform;
   private Vector3 m_DesiredCamPosition;
   
   private void Awake()
   {
      m_TargetTransform = GameObject.FindWithTag("Player").transform;
   }

   private void LateUpdate()
   {
      MoveCamera();
      //LookAtPlayer();
   }


   private void MoveCamera()
   {
      m_DesiredCamPosition = m_TargetTransform.position + camOffset;
      //transform.position = Vector3.Lerp(transform.position, m_DesiredCamPosition, camLerpSpeed);
      transform.position = m_DesiredCamPosition;

   }

   private void LookAtPlayer()
   {
      transform.LookAt(m_TargetTransform);
   }
   
   

   void Update()
   {
      float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

      if (scrollDelta != 0f)
      {
         camOffset.y *= Mathf.Pow(scrollFactor, scrollDelta);
         camOffset.z *= Mathf.Pow(scrollFactor, scrollDelta);
      }
   }
}
