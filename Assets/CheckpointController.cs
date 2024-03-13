using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] private GameObject _checkpointsParent;
    public GameObject[] _checkPointsArray;
    private Vector3 _startingPoint;

    
     private Rigidbody _rigidbody;

    private const string SAVE_CHECKPOINT_INDEX = "Last_checkpoint_index";

    private void Awake()
    {
        
         _rigidbody = GetComponent<Rigidbody>();          

        LoadCheckpoints();
    }

    void Start()
    {
        int savedCheckpointIndex = -1;
        savedCheckpointIndex = PlayerPrefs.GetInt(SAVE_CHECKPOINT_INDEX, -1);
        if (savedCheckpointIndex != -1)
        {
            _startingPoint = _checkPointsArray[savedCheckpointIndex].transform.position;
        }
        else
        {
            _startingPoint = gameObject.transform.position;
        }

        RespawnPlayer();
    }

    
        void Update()
        {
            if (transform.position.y <= -10f || transform.position.y <= _startingPoint.y - 10f)
            {
                RespawnPlayer();
            Debug.Log("respawn");
            PlayerHealthController.instance.DamagePlayer();
        }
        }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            // Get the position of the checkpoint
            Vector3 checkpointPosition = other.transform.position;

            // Set the starting point to the checkpoint position
            _startingPoint = checkpointPosition;

            // Deactivate the checkpoint
            other.gameObject.SetActive(false);

            // Save the index of the checkpoint
            int checkPointIndex = Array.IndexOf(_checkPointsArray, other.gameObject);
            PlayerPrefs.SetInt(SAVE_CHECKPOINT_INDEX, checkPointIndex);

            // Debug logs for verification
            Debug.Log("Player touched checkpoint. Starting point updated to: " + _startingPoint);
            Debug.Log("Checkpoint deactivated.");
        }
    }





    private void RespawnPlayer()
    {
        gameObject.transform.position = _startingPoint;
        
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void LoadCheckpoints()
    {
        _checkPointsArray = new GameObject[_checkpointsParent.transform.childCount];

        int index = 0;

        foreach (Transform singleCheckpoint in _checkpointsParent.transform)
        {
            _checkPointsArray[index] = singleCheckpoint.gameObject;
            index++;
        }
    }
}
