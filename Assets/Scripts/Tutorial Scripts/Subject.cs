using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public List<Observer> Observers = new List<Observer>();

    public virtual void Notify() {
        for (int i = 0; i < Observers.Count; i++) {
            Observers[i].OnNotify();
        }
    }

    public void AddObserver(Observer _newObserver) {
        Observers.Add(_newObserver);
    }

    public void RemoveObserver(Observer _newObserver) {
        Observers.Remove(_newObserver);
    }
}
