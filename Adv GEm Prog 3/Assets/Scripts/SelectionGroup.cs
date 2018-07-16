﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionGroup {
    /*
     * Holds our selected Units, and a formation, formation can bes changed and positioned, units will be send to the formation, 
     * there is always one default selection group for the current selection, but groups can also be saved and assigned to shortcuts later
     * 
     */

    private List<UnitMovement> selectionGroup;
    private Formation formation;


    #region boring setter getter stuff
    
        //Constructor
    public SelectionGroup()
    {
        selectionGroup = new List<UnitMovement>();
    }

    public void Add(UnitMovement unitMovement) //like the HashSetMethod
    {
        selectionGroup.Add(unitMovement);
    }

    public void Remove(UnitMovement unitMovement)
    {
        selectionGroup.Remove(unitMovement);
    }

    public List<UnitMovement> GetSet()
    {
        return selectionGroup;
    }

    public void DeselectAll()
    {
        foreach (UnitMovement uMov in selectionGroup)
        {
            uMov.Deselect();
        }
        selectionGroup.Clear();
    }

    public void SelectAll()
    {
        foreach (UnitMovement uMov in selectionGroup)
        {
            uMov.Select();
        }
    }

    public bool Contains(UnitMovement unitMovement)
    {
        if (selectionGroup.Contains(unitMovement)) return true;
        else return false;
    }

    public int Count()
    {
        return selectionGroup.Count;
    }
    #endregion

    void CreateNewFormation() //creates the formation 
    {
        formation = new Formation(selectionGroup.Count);
    }

    //sends troops to positions determined by formation object, selectedUnits MUST be the same count as the count of the formation positions
    // the local formation positions are translatet to world coordinates here? 
    void SendTroopsToFormation()
    {
        List<FormationPosition> positionsArrayList = formation.GetThePositions();
        for (int i = 0; i < positionsArrayList.Count; i++)
        {
            selectionGroup[i].SetDestination(positionsArrayList[i].position, positionsArrayList[i].lookDirection);
        }
    }
}
