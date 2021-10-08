using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forte.ForteQuestNS;
using ForteQuest.ForteQuestNS;



namespace ForteQuest
{
    
    public partial class WebForm2 : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            string activityname;
            string activitytype;
            float maxscore;
            bool isteam;
            int instructorweightage;
            int taweightage;
            int duration;

            if ((int.Parse(Durationtxt.Text) > 0) && (int.Parse(Durationtxt.Text) <= 120)
                && (float.Parse(MaxScore.Text) > 0) && (float.Parse(MaxScore.Text) <= 100))
            {
                activityname = ActivityNametxt.Text;
                activitytype = ActivityType.SelectedValue;
                maxscore = int.Parse(MaxScore.Text);
                duration = int.Parse(Durationtxt.Text);

                if (IsTeamDD.SelectedValue == "Team")
                {
                    int total = int.Parse(Individual.Text) + int.Parse(Team.Text);

                    if ((int.Parse(Team.Text) <= 100) && (int.Parse(Team.Text) > 0)
                        && (int.Parse(Individual.Text) <= 100) && (int.Parse(Individual.Text) > 0)
                        && (total <= 100))
                    {
                        isteam = true;
                        instructorweightage = int.Parse(Team.Text);
                        taweightage = int.Parse(Individual.Text);

                        ActivityNametxt.Text = "";
                        Durationtxt.Text = "";
                        ActivityType.Text = "";
                        MaxScore.Text = "";
                        Team.Text = "";
                        Individual.Text = "";

                        Hashtable ht = new Hashtable();
                        ht.Add("@name", activityname);
                        ht.Add("@type", activitytype);
                        ht.Add("@isTeam", isteam);
                        ht.Add("@maxscore", maxscore);
                        ht.Add("@instructorWeightage", instructorweightage);
                        ht.Add("@taWeightage", taweightage);
                        ht.Add("@duration", duration);
                        DBContext.ExecuteNonScalor("stp_Activities1_Insert", ht);

                        Response.Redirect("AddNewTemplatePage.aspx");
                    }
                    else
                    {
                        string message = "alert('Data Entered is Invalid.')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }    
                }
                else
                {
                    isteam = false;
                    instructorweightage = 100;
                    taweightage = 0;

                    Hashtable ht = new Hashtable();
                    ht.Add("@name", activityname);
                    ht.Add("@type", activitytype);
                    ht.Add("@isTeam", isteam);
                    ht.Add("@maxscore", maxscore);
                    ht.Add("@instructorWeightage", instructorweightage);
                    ht.Add("@taWeightage", taweightage);
                    ht.Add("@duration", duration);
                    DBContext.ExecuteNonScalor("stp_Activities1_Insert", ht);

                    ActivityNametxt.Text = "";
                    Durationtxt.Text = "";
                    ActivityType.Text = "";
                    MaxScore.Text = "";

                    Team.Text = "";
                    Individual.Text = "";
                    Response.Redirect("AddNewTemplatePage.aspx");
                }
            }
            else
            {
                string message = "alert('Data Entered is Invalid.')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }

        }

        protected void IsTeamDD_Selected(object sender, EventArgs e)
        {
            if (IsTeamDD.SelectedValue == "Team")
            {
                Team.Visible = true;
                TeamEffort.Text = "Team Effort: (%)";
                Individual.Visible = true;
                IndividualEffort.Text = "Individual Effort: (%)";

            }
            else
            {
                Team.Visible = false;
                Individual.Visible = false;
                TeamEffort.Text = "";
                IndividualEffort.Text = "";

            }
            IsTeamup.Update();
        }


    }

}
