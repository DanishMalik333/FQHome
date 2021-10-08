using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForteQuest.ForteQuestNS
{
    public class TraitClass
    {
        private string _name;
        private float _totalWeights;
        private List<SubTraitClass> _subTraits = new List<SubTraitClass>();

        private List<string> _subTraitNames = new List<string>();
        private List<string> _subTraitID = new List<string>();
        private List<float> _subTraitWeights = new List<float>();
        // methods

        public TraitClass(string Name)
        {
            _name = Name;
        }
        public float TotalWeights
        {
            get { return _totalWeights; }
            set { _totalWeights = value; }
        }
        public List<SubTraitClass> SubTraits
        {
            get {return _subTraits; }
            set { _subTraits = value; }
        
        }
        public List<string> SubTraitNames
        {
            get { return _subTraitNames; }
            set { _subTraitNames = value; }

        }
        public List<float> SubTraitWeights
        {
            get { return _subTraitWeights; }
            set { _subTraitWeights = value; }

        }
        public string Name
        {
            get { return _name; }
        }
        public void AddSubTrait(SubTraitClass OneSubTrait)
        {
            _subTraits.Add(OneSubTrait);
        }

        public void AddSubTraitNames(string Names)
        {
            _subTraitNames.Add(Names);
        }
        public void AddSubTraitID(string ID)
        {
            _subTraitID.Add(ID);
        }
        public void AddSubTraitWeights(float Weights)
        {
            _subTraitWeights.Add(Weights);
        }
        public void RemoveSubTrait(SubTraitClass OneSubTrait)
        {
            _subTraits.Remove(OneSubTrait);
        }

    }
}