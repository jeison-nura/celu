using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextState 
{
    IState stateactual;
    public ContextState() { }

    public void setContext(IState stateactual) {
        this.stateactual = stateactual;
    }

    public List<int> request() {
        return stateactual.tamañoTipico();
    }
}
