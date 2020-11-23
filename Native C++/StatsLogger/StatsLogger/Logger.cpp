#include "Logger.h"
#include <fstream>
#include <sstream>
#include <string>

void Logger::ResetLogger()
{
    _totalTime = 0.0f;
    _checkpoints.clear();
    _loadedValues.clear();

    _attacksHit = 0;
    _totalAttacks = 0;
    _hitAccuracy = 0.0f;

    _totalEnemies = 0;

    _totalJumps = 0;

    _totalDeaths = 0;
}

void Logger::SaveCheckpointTime(float time)
{
    _checkpoints.push_back(time);
    _totalTime += time;
}

float Logger::GetTotalTime()
{
    return _totalTime;
}

float Logger::GetCheckpointTime(int index)
{
    return _checkpoints[index];
}

int Logger::GetNumCheckpoints()
{
    return _checkpoints.size();
}

void Logger::SaveAttacks()
{
    _totalAttacks++;
    CalcAccuracy();
}

int Logger::ReturnAttacks()
{
    return _totalAttacks;
}

void Logger::SaveHits()
{
    _attacksHit++;
    CalcAccuracy();
}

int Logger::ReturnHits()
{
    return _attacksHit;
}

void Logger::CalcAccuracy()
{
    _hitAccuracy = ((float)_attacksHit / (float)_totalAttacks) * 100.0f;
}

float Logger::ReturnAccuracy()
{
    return _hitAccuracy;
}

void Logger::SaveEnemies()
{
    _totalEnemies++;
}

int Logger::ReturnEnemies()
{
    return _totalEnemies;
}

void Logger::SaveJumps()
{
    _totalJumps++;
}

int Logger::ReturnJumps()
{
    return _totalJumps;
}

void Logger::SaveDeaths()
{
    _totalDeaths++;
}

int Logger::ReturnDeaths()
{
    return _totalDeaths;
}

bool Logger::SaveToFile(char* string)
{
    //open file
    size_t length = strlen(string);
    std::string filename(string, length);
    std::ofstream file(filename);

    if (file.fail()) {
        return false;
    }

    //save into file
    file << "Total Time: " << _totalTime << std::endl;
    for (int i = 0; i < _checkpoints.size() - 1; i++) {
        file << "Checkpoint " << i + 1 << " Time: " << _checkpoints[i] 
            << "s" << std::endl;
    }
    file << "End: " << _checkpoints[_checkpoints.size()-1]<< "s" << std::endl;
    file << "\n";
    file << "Attacks Used: " << _totalAttacks << std::endl;
    file << "Attacks Hit: " << _attacksHit << std::endl;
    file << "Attack Accuracy: " << _hitAccuracy << "%" << std::endl;
    file << "\n";
    file << "Enemies Defeated: " << _totalEnemies << std::endl;
    file << "\n";
    file << "Total Jumps: " << _totalJumps << std::endl;
    file << "\n";
    file << "Total Deaths: " << _totalDeaths << std::endl;

    file.close();
    return true;
}

bool Logger::LoadFromFile(char* string)
{

    //open file
    size_t length = strlen(string);
    std::string filename(string, length);
    std::ifstream file(filename);

    if (file.fail()) {
        return false;
    }

    //parse values
    std::string newline;
    std::string temp_str;
    float temp_float;

    while (std::getline(file, newline)) {
        std::stringstream stream;
        stream << newline;

        while (stream >> temp_str) {
            if (std::stringstream(temp_str) >> temp_float) { //ints read as floats
                _loadedValues.push_back(temp_float);
            }
        }
    }

    //load values into corresponding variables
    //floats converted back to ints
    _totalTime = _loadedValues[0];
    _checkpoints.push_back(_loadedValues[2]);
    _checkpoints.push_back(_loadedValues[4]);
    _checkpoints.push_back(_loadedValues[6]);
    _checkpoints.push_back(_loadedValues[7]);
    _attacksHit = _loadedValues[8];
    _totalAttacks = _loadedValues[9];
    _hitAccuracy = _loadedValues[10];
    _totalEnemies = _loadedValues[11];
    _totalJumps = _loadedValues[12];
    _totalDeaths = _loadedValues[13];

    return true;
}

