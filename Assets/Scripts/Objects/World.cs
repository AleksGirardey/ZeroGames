using System.Collections.Generic;
using UnityEngine;


/**
 * Informations lié au monde dans lequel évolue la partie du joueur :
 * - Intégration des chiens pseudo random
 * - Gestion des écuries conccurentes (Entrainement et Course)
 */

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WorldScriptableObject", order = 1)]
public class World : ScriptableObject {

    private List<Kennel> _kennels;

    public List<StatsChien> AllDogs;

}