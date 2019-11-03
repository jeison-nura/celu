using System;
using System.Collections;
using System.Collections.Generic;


public class ContextStrategy
{
   private IStrategy ies;

    public ContextStrategy( IStrategy ies) {
        this.ies = ies;
    }

    public List<string> SepararMadres(List<String> lista) {
        return ies.DarInfo(lista);
    }
}
