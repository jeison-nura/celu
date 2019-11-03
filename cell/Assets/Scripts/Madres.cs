using System;
using System.Collections;
using System.Collections.Generic;


public class Madres : IStrategy
{
    List<String> MadresSimulador = new List<String>();
    public List<string> DarInfo(List<string> lista)
    {
        ListarMadres(lista);
        return MadresSimulador;
    }

    private void ListarMadres(List<string> lista)
    {
        foreach (String celula in lista) {
            string[] elementos = celula.Split('$');
            if (elementos[elementos.Length-1].Contains("Madre")) {
                MadresSimulador.Add(celula);
            }
        }
    }
}
