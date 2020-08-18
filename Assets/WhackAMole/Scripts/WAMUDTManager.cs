using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class WAMUDTManager : MonoBehaviour, IUserDefinedTargetEventHandler
{
    private UserDefinedTargetBuildingBehaviour udt_targetBuildingBehaviour;

    private ObjectTracker _objectTracker;
    private DataSet _dataSet;

    private ImageTargetBuilder.FrameQuality udt_FrameQuality;
    public ImageTargetBehaviour _targetBehaviour;

    public GameObject[] qualityBars;
    
    private int targetCounter;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        udt_targetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
        if (udt_targetBuildingBehaviour)
        {
            udt_targetBuildingBehaviour.RegisterEventHandler(this);
        }
    }

    public void OnInitialized()
    {
        _objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (_objectTracker != null)
        {
            _dataSet = _objectTracker.CreateDataSet();
            _objectTracker.ActivateDataSet(_dataSet);
        }
    }

    public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)
    {
        udt_FrameQuality = frameQuality;
        foreach (var bar in qualityBars)
        {
            bar.SetActive(false);
        }
        
        if (frameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW)
        {
            qualityBars[0].SetActive(true);
        }
        else if (frameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM)
        {
            qualityBars[1].SetActive(true);
        }
        else if (frameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH)
        {
            qualityBars[2].SetActive(true);
        }
    }

    public void OnNewTrackableSource(TrackableSource trackableSource)
    {
        targetCounter++;
        _objectTracker.DeactivateDataSet(_dataSet);
        _dataSet.CreateTrackable(trackableSource, _targetBehaviour.gameObject);
        _objectTracker.ActivateDataSet(_dataSet);
        udt_targetBuildingBehaviour.StartScanning();
    }

    public void BuildTarget()
    {
        if (udt_FrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH)
        {
            udt_targetBuildingBehaviour.BuildNewTarget(targetCounter.ToString(),_targetBehaviour.GetSize().x);
            Time.timeScale = 1f;
        }
    }
}
