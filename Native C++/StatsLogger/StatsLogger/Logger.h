#pragma once

#include "PluginSettings.h"
#include <vector>

class PLUGIN_API Logger
{
public:
	void ResetLogger();

	//checkpoint times
	void SaveCheckpointTime(float time);
	float GetTotalTime();
	float GetCheckpointTime(int index);
	int GetNumCheckpoints();

	//attack accuracy
	void SaveAttacks();
	int ReturnAttacks();
	void SaveHits();
	int ReturnHits();
	void CalcAccuracy();
	float ReturnAccuracy();

	//enemies defeated
	void SaveEnemies();
	int ReturnEnemies();

	//jumps
	void SaveJumps();
	int ReturnJumps();

	//deaths
	void SaveDeaths();
	int ReturnDeaths();

	//file handling
	bool SaveToFile(char* string);
	bool LoadFromFile(char* string);

private:
	float _totalTime = 0.0f;
	std::vector<float> _checkpoints;

	int _attacksHit = 0;
	int _totalAttacks = 0;
	float _hitAccuracy = 0.0f;

	int _totalEnemies = 0;

	int _totalJumps = 0;

	int _totalDeaths = 0;

	std::vector<float> _loadedValues;
};

