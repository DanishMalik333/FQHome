using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForteQuest.ForteQuestNS
{
    public class MappingClass
    {
       
        private List<TraitClass> _traits = new List<TraitClass>();
        private List<ActivitiesSelected> _activitiesSelected = new List<ActivitiesSelected>();


        // methods
        public List<TraitClass> Traits
        {
            get { return _traits; }
            set { _traits = value; }
            
        }
        public List<ActivitiesSelected> ActivitiesSelected
        {
            get { return _activitiesSelected; }
            set { _activitiesSelected = value; }

        }

        public void OtherTraits(int NumofTraits, List<string> Traits)
        {
            //to be coded later for extra functionalities
        }
       public void RIASEC()
        {
            _traits.Add(new TraitClass("R"));
            _traits.Add(new TraitClass("I"));
            _traits.Add(new TraitClass("A"));
            _traits.Add(new TraitClass("S"));
            _traits.Add(new TraitClass("E"));
            _traits.Add(new TraitClass("C"));
        }

        public void AddActivitiesSelected(List<string> activities_list)
        {
            foreach(string k in activities_list)
            {
                _activitiesSelected.Add(new ActivitiesSelected(k));
            }

        }

    }
}