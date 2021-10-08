using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForteQuest.ForteQuestNS
{
    public class ActivityClass
    {

        private string _activityName;
        private bool _isTeam;
        private Hashtable _participantActivityScore = new Hashtable();
        private string _activityType;
        private int _duration;
        private float _maxScore;
        private float _instructorWeightage;
        private float _tAWeightage;
        private Hashtable _instructorObtainedScore = new Hashtable();
        private Hashtable _tAObtainedScore = new Hashtable();
        
        // methods
        public ActivityClass()
        {

        }
        public ActivityClass(List<string> ParticipantID)
        {

        }
        public void SetScore(string ParticipantID, float InstScore, float TAScore)
        {

        }
        public void getParticipantScore(string ParticipantID)
        {

        }
        public string ActivityName 
        {
            get { return _activityName; }   
            set { _activityName = value; }  
        }
        public string ActivityType
        {
            get { return _activityType; }
            set { _activityType = value;}
        }
        public bool IsTeam
        {
            get { return _isTeam; }
            set { _isTeam = value; }
        }
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public float InstructorWeightage
        {
            get { return _instructorWeightage; }
            set { _instructorWeightage = value; }
        }
        public float TAWeightage
        {
            get { return _tAWeightage; }
            set { _tAWeightage = value; }
        }
        public float MaxScore
        {
            get { return _maxScore; }
            set { _maxScore = value; }
        }

    }
}