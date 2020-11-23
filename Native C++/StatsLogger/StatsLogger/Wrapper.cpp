#include "Wrapper.h"

Logger logger;

PLUGIN_API void ResetLogger()
{
	return logger.ResetLogger();
}

PLUGIN_API void SaveCheckpointTime(float time)
{
	return logger.SaveCheckpointTime(time);
}

PLUGIN_API float GetTotalTime()
{
	return logger.GetTotalTime();
}

PLUGIN_API float GetCheckpointTime(int index)
{
	return logger.GetCheckpointTime(index);
}

PLUGIN_API int GetNumCheckpoints()
{
	return logger.GetNumCheckpoints();
}

PLUGIN_API void SaveAttacks()
{
	return logger.SaveAttacks();
}

PLUGIN_API int ReturnAttacks()
{
	return logger.ReturnAttacks();
}

PLUGIN_API void SaveHits()
{
	return logger.SaveHits();
}

PLUGIN_API int ReturnHits()
{
	return logger.ReturnHits();
}

PLUGIN_API void CalcAccuracy()
{
	return logger.CalcAccuracy();
}

PLUGIN_API float ReturnAccuracy()
{
	return logger.ReturnAccuracy();
}

PLUGIN_API void SaveEnemies()
{
	return logger.SaveEnemies();
}

PLUGIN_API int ReturnEnemies()
{
	return logger.ReturnEnemies();
}

PLUGIN_API void SaveJumps()
{
	return logger.SaveJumps();
}

PLUGIN_API int ReturnJumps()
{
	return logger.ReturnJumps();
}

PLUGIN_API void SaveDeaths()
{
	return logger.SaveDeaths();
}

PLUGIN_API int ReturnDeaths()
{
	return logger.ReturnDeaths();
}

PLUGIN_API bool SaveToFile(char* string)
{
	return logger.SaveToFile(string);
}

PLUGIN_API bool LoadFromFile(char* string)
{
	return logger.LoadFromFile(string);
}
