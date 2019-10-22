using System.Collections.Generic;
using UnityEngine;


/**
 * Informations lié au monde dans lequel évolue la partie du joueur :
 * - Intégration des chiens pseudo random
 * - Gestion des écuries conccurentes (Entrainement et Course)
 */
public class World : ScriptableObject {
    private List<Stable> _stables;
}