using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : RedSpace.PersistentSingleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        if (_instance != this){ return; }
        //Menu
        //  Continue / New Game / Option / Quit

        // Tour 1 (Tutoriel)
        //  Base Resource
        //  Evenement scripté (4 gars)
        //  Update resources (post évenement)
        //  Gestion de la base (Tutoriel guidé)
        //  Resource en Prévision (Panel Résumé)
        //  Save

        //  Tour 2 (mid Tutorial)
        //  Update resources (pré prise en compte de l'évenement)
        //  Evenement scripté ( à  définir)
        //  End Of Tutorial, game continue as set by systems
        //  Gestion de la base
        //  Resource en Prévision (Panel Résumé)


        //Tour par tour 

        //un tour :
        //  Update resources (pré prise en cmpte de l'évenement)
        //  Evenement
        //  Update resources (post évenement)
        //  Gestion de la base
        //  Resource en Prévision (Panel Résumé)
        //  Save


    }

}
