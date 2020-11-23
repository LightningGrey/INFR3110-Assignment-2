#pragma once

#include "Logger.h"

#ifdef __cplusplus
extern "C"
{
#endif

	//functions here
	PLUGIN_API void ResetLogger();

	//checkpoint times
	PLUGIN_API void SaveCheckpointTime(float time);
	PLUGIN_API float GetTotalTime();
	PLUGIN_API float GetCheckpointTime(int index);
	PLUGIN_API int GetNumCheckpoints();

	//attack accuracy
	PLUGIN_API void SaveAttacks();
	PLUGIN_API int ReturnAttacks();
	PLUGIN_API void SaveHits();
	PLUGIN_API int ReturnHits();
	PLUGIN_API void CalcAccuracy();
	PLUGIN_API float ReturnAccuracy();

	//enemies defeated
	PLUGIN_API void SaveEnemies();
	PLUGIN_API int ReturnEnemies();

	//jumps
	PLUGIN_API void SaveJumps();
	PLUGIN_API int ReturnJumps();

	//deaths
	PLUGIN_API void SaveDeaths();
	PLUGIN_API int ReturnDeaths();

	//file handling
	PLUGIN_API bool SaveToFile(char* string);
	PLUGIN_API bool LoadFromFile(char* string);

#ifdef __cplusplus
}
#endif