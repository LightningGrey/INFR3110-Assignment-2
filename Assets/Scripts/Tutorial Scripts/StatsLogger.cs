using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;

public class StatsLogger : MonoBehaviour
{
    const string DLL_NAME = "StatsLoggerDLL";

	[DllImport(DLL_NAME)]
	private static extern void ResetLogger();
	
	[DllImport(DLL_NAME)]
	private static extern void SaveCheckpointTime(float time);
	[DllImport(DLL_NAME)]
	private static extern float GetTotalTime();
	[DllImport(DLL_NAME)]
	private static extern float GetCheckpointTime(int index);
	[DllImport(DLL_NAME)]
	private static extern int GetNumCheckpoints();

	[DllImport(DLL_NAME)]
	private static extern void SaveAttacks();
	[DllImport(DLL_NAME)]
	private static extern int ReturnAttacks();
	[DllImport(DLL_NAME)]
	private static extern void SaveHits();
	[DllImport(DLL_NAME)]
	private static extern int ReturnHits();
	[DllImport(DLL_NAME)]
	private static extern void CalcAccuracy();
	[DllImport(DLL_NAME)]
	private static extern float ReturnAccuracy();

	[DllImport(DLL_NAME)]
	private static extern void SaveEnemies();
	[DllImport(DLL_NAME)]
	private static extern int ReturnEnemies();

	[DllImport(DLL_NAME)]
	private static extern void SaveJumps();
	[DllImport(DLL_NAME)]
	private static extern int ReturnJumps();

	[DllImport(DLL_NAME)]
	private static extern void SaveDeaths();
	[DllImport(DLL_NAME)]
	private static extern int ReturnDeaths();

	[DllImport(DLL_NAME)]
	private static extern bool SaveToFile([MarshalAs(UnmanagedType.LPStr)] string file);
	[DllImport(DLL_NAME)]
	private static extern bool LoadFromFile([MarshalAs(UnmanagedType.LPStr)] string file);


	//getters
	public float TotalTime()
    {
		return GetTotalTime();
    }
	public float CheckpointTime(int index)
    {
		return GetCheckpointTime(index);
	}
	public float NumCheckpoints()
	{
		return GetNumCheckpoints();
	}
	public int Attacks()
	{
		return ReturnAttacks();
	}
	public int Hits()
	{
		return ReturnHits();
	}
	public float Accuracy()
	{
		return ReturnAccuracy();
	}
	public int Enemies()
	{
		return ReturnEnemies();
	}
	public int Jumps()
	{
		return ReturnJumps();
	}
	public int Deaths()
	{
		return ReturnDeaths();
	}



	//setters
	public void OnCheckpoint(float time)
	{
		SaveCheckpointTime(time);
	}

	public void OnAttack()
	{
		SaveAttacks();
	}
    public void OnHit()
    {
		SaveHits();
    }

    public void OnJump()
	{
		SaveJumps();
	}

	public void OnEnemyKill()
    {
		SaveEnemies();
    }

	public void OnDeath()
	{
		SaveDeaths();
	}

	public void SaveStats()
    {
		if (File.Exists(Application.dataPath + "/Resources/Stats.txt")) 
		{
			File.Delete(Application.dataPath + "/Resources/Stats.txt");
		}
		SaveToFile(Application.dataPath + "/Resources/Stats.txt");
	}

	public void LoadStats()
	{
		if (File.Exists(Application.dataPath + "/Resources/Stats.txt"))
		{
			LoadFromFile(Application.dataPath + "/Resources/Stats.txt");
		}
	}

	private void OnDestroy()
    {
		ResetLogger();
    }

}
