using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForteQuest.ForteQuestNS
{
    public class SubTraitClass
    {
        private string _subTraitName;
        private string _subTraitID;
        private Hashtable _activityTable = new Hashtable();
        private List<string> _activitiesNames = new List<string>(); 
        private Hashtable _participantSubTraitScore = new Hashtable();
        private float _subTraitWeightage;


        // methods
        public Hashtable ActivityTable
        {
            get { return _activityTable; }
            set { _activityTable = value; }
        }
        public List<string> ActivitiesNames
        {
            get { return _activitiesNames; }
            set { _activitiesNames = value; }
        }
        public Hashtable ParticipantSubtraitScores
        {
            get { return _participantSubTraitScore; }
        }
        public string SubTraitNames
        {
            get { return _subTraitName; }
            set { _subTraitName = value; }
        }
        public float SubTraitWeightage
        {
            get { return _subTraitWeightage; }
            set { _subTraitWeightage = value; }
        }
        public string SubTraitID
        {
            get { return _subTraitID; }
            set { _subTraitID = value; }
        } 

        public void AddActivity(ActivityClass OneActivity, float Weightage)
        {
            _activityTable.Add(OneActivity, Weightage);

            
        }
        public void RemoveActivity(ActivityClass OneActivity)
        {
            _activityTable.Remove(OneActivity);
        }

    }
}