﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReading();
    }

    public void StreamReading()
    {
        StreamReader streamReader = null;
        //string[] name;
        string[] values;
        try
        {
            streamReader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string readLine = streamReader.ReadLine();
            readLine.Split(',');
            readLine = streamReader.ReadLine();
            values = readLine.Split(',');
            FillVariablies(values);
        }
        catch (Exception) { }
        finally
        {
            if (streamReader != null)
                streamReader.Close();
        }
    }
    public void FillVariablies(string[] values)
    {
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
    }
    #endregion
}