using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForteQuest.ForteQuestNS
{
    public class ActivitiesSelected
    {
        private string _name;
        private Hashtable _subtraitTable = new Hashtable();
        //private List<String> _subTraitsID = new List<string>();


        // methods

        public ActivitiesSelected(string Name)
        {
            _name = Name;
        }
        public Hashtable SubtraitTable
        {
            get { return _subtraitTable; }
            set { _subtraitTable = value; }
        }
        public string Name
        {
            get { return _name; }
        }

        public void AddSubtraitsToActivities(string SubtraitID, float Weightage)
        {
            _subtraitTable.Add(SubtraitID, Weightage);

        }
    }
}