using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private TurnManager turnManager;

    private Dictionary<int, List<Selectable>> selectables = new Dictionary<int, List<Selectable>>();
    private int selectedIndex = 0;
    private int currentSide = -1;

    void Update()
    {
        if(this.turnManager.CurrentSide != this.currentSide)
        {
            if(this.selectables.ContainsKey(this.currentSide))
            {
                this.selectables[this.currentSide][this.selectedIndex].Selected = false;
            }
            
            this.currentSide = this.turnManager.CurrentSide;
            
            var list = this.selectables[this.currentSide];
            this.selectedIndex = 0;
            list[this.selectedIndex].Selected = true;
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            this.SelectPrevious();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            this.SelectNext();
        }
    }
    
    private void SelectPrevious()
    {
        if(this.selectables.ContainsKey(this.currentSide))
        {
            Select(Math.Abs(this.selectedIndex - 1));
        }
    }

    private void SelectNext()
    {
        if(this.selectables.ContainsKey(this.currentSide))
        {
            Select(this.selectedIndex + 1);
        }
    }

    private void Select(int index)
    {
        Debug.Log("select: " + index);
        var list = this.selectables[this.currentSide];

        list[this.selectedIndex].Selected = false;
        this.selectedIndex = index % list.Count;
        list[this.selectedIndex].Selected = true;

    }

    public void Register(Selectable selectable)
    {
        if(!this.selectables.ContainsKey(selectable.Side.Id))
        {
            this.selectables.Add(selectable.Side.Id, new List<Selectable>());
        }

        var list = this.selectables[selectable.Side.Id];

        if(!list.Contains(selectable))
        {
            list.Add(selectable);
        }
    }
}
