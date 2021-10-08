using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forte.ForteQuestNS;
using ForteQuest.ForteQuestNS;

namespace ForteQuest
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private List<string> RIASEC_List = new List<string>();
        private List<string> Other_List = new List<string>();
        private List<string> Subtrait_List = new List<string>();
        
        MappingClass m = new MappingClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create RIASEC Trait Objects
            m.RIASEC();

            // Upadate Mapping with each postback if changings are made in the object attributes
            if ((string)Session["clicked"]=="true")
            {
                m = (MappingClass)Session["mapping"];
            }
            // Updating Selected Activities if user is importing them from previous quests
            if ((string)Session["clicked2"]=="true")
            {
                RIASEC_List = (List<string>)Session["Activities"];
                m.AddActivitiesSelected(RIASEC_List);
                Session["clicked"] = "true";
                Session["mapping"] = m;
                Activity1DD.DataSource = RIASEC_List;
                Activity1DD.DataBind();
                Session["clicked2"] = "false";
            }

        }
        protected void ApplyBtn_Click(object sender, EventArgs e)
        {
            // Select RIASEC and Other Activities for Quest
            foreach (ListItem item in RIASEC_Activities.Items)
            {
                if (item.Selected)
                {
                    RIASEC_List.Add(item.ToString());
                }
            }
            foreach (ListItem item in Other_Activities.Items)
            {
                if (item.Selected)
                {
                    Other_List.Add(item.ToString());
                }
            }
            
            m.AddActivitiesSelected(RIASEC_List);
            // Store the changings in mapping object 
            Session["clicked"] = "true";
            Session["mapping"] = m;
            Session["Activities"] = RIASEC_List;
            // Update Activities DropDown with the Selected activities for quest
            Activity1DD.DataSource = RIASEC_List;
            Activity1DD.DataBind();

        }
        protected void TraitSelected(object sender, EventArgs e)
        {

            AddSUbtraitBtn2.Visible = true;
            SubTraitDropDown.Items.Clear();
            Weight.Text = "";
            RemoveSubtraitBtn.Visible = false;
            SubTraitDropDown.Items.Insert(0, new ListItem("Select SubTrait"));
            // Loop Through all the traits and bind subtrait list of selected one
            for (int i = 0; i < 7; i++)
            {
                if (TraitDropDown.SelectedIndex == i + 1)
                {
                    if (m.Traits[i].SubTraits.Count >= 3)
                    {
                        AddSUbtraitBtn2.Visible = false;
                    }
                    for (int j = 0; j < m.Traits[i].SubTraits.Count; j++)
                    {

                        Subtrait_List.Add(m.Traits[i].SubTraits[j].SubTraitNames);

                    }
                    SubTraitDropDown.DataSource = Subtrait_List;
                    SubTraitDropDown.DataBind();
                }
            }
        }
        protected void SubTraitSelected(object sender, EventArgs e)
        { // Show Weights of selected subtrait and show add or remove buttons
            if (SubTraitDropDown.SelectedIndex == 0)
            {
                AddActivityBtn.Visible = false;
                RemoveSubtraitBtn.Visible = false;
                Weight.Text = "";
            }
            else
            {
                AddActivityBtn.Visible = true;
                RemoveSubtraitBtn.Visible = true;
                Weight.Text = "Weights: " + m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits[SubTraitDropDown.SelectedIndex - 1].SubTraitWeightage.ToString();
            }
            Subtraitup.Update();
        }
        protected void RemoveSubTraiBtn_Click(object sender, EventArgs e)
        {
            // Search the subtrait list of objects and find the one to be removed
            var item = m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits.SingleOrDefault(x => x.SubTraitNames == SubTraitDropDown.SelectedValue);
            if (item != null)
            {
                m.Traits[TraitDropDown.SelectedIndex - 1].RemoveSubTrait(item);
                m.Traits[TraitDropDown.SelectedIndex - 1].TotalWeights -= item.SubTraitWeightage;
            }
            // update mapping object after removing subtrait
            Session["mapping"] = m;
            Subtraitup.Update();
            SubTraitDropDown.Items.Clear();
            SubTraitDropDown.Items.Insert(0, new ListItem("Select SubTrait"));
            TraitSelected(sender, e);
            RemoveSubtraitBtn.Visible = false;
            Weight.Text = "";
        }
        protected void AddSubtraitBtn_Click(object sender, EventArgs e)
        {
            Weight.Text = "";
           
            bool check = m.Traits[TraitDropDown.SelectedIndex - 1].SubTraitNames.Contains(SubTraitNameTxt.Text);
            // Check if subtraits are 3 or less and their weights sum equal to zero and avoid subtrait duplication
            if ((m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits.Count < 4) && ((m.Traits[TraitDropDown.SelectedIndex - 1].TotalWeights + float.Parse(SubTraitWeightTxt.Text)) <= 100) && (float.Parse(SubTraitWeightTxt.Text) > 0) && (!check))
            {
                SubTraitClass ST = new SubTraitClass()
                {
                    SubTraitNames = SubTraitNameTxt.Text,
                    SubTraitWeightage = float.Parse(SubTraitWeightTxt.Text),
                    SubTraitID = m.Traits[TraitDropDown.SelectedIndex - 1].Name + (m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits.Count + 1) + "_Weights"
                };
                m.Traits[TraitDropDown.SelectedIndex - 1].TotalWeights += float.Parse(SubTraitWeightTxt.Text);
                m.Traits[TraitDropDown.SelectedIndex - 1].AddSubTrait(ST);
                m.Traits[TraitDropDown.SelectedIndex - 1].AddSubTraitNames(ST.SubTraitNames);
                m.Traits[TraitDropDown.SelectedIndex - 1].AddSubTraitWeights(ST.SubTraitWeightage);
                m.Traits[TraitDropDown.SelectedIndex - 1].AddSubTraitID(ST.SubTraitID);

                SubTraitDropDown.Items.Clear();
                SubTraitDropDown.Items.Insert(0, new ListItem("Select SubTrait"));
                Session["clicked"] = "true";
                Session["mapping"] = m;
                SubTraitNameTxt.Text = "";
                SubTraitWeightTxt.Text = "";
                TraitSelected(sender, e);
            }
            else
            {
                string message = "alert('Invalid Information')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                
                SubTraitNameTxt.Text = "";
                SubTraitWeightTxt.Text = "";
                TraitSelected(sender, e);
            }

            Subtraitup.Update();
        }

        protected void AddActivityBtn_Click(object sender, EventArgs e)
        {
            // Validate the range of weights and avoid activity duplication in a subtrait
            bool check = m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits[SubTraitDropDown.SelectedIndex - 1].ActivitiesNames.Contains(Activity1DD.SelectedValue);
            if ((int.Parse(Activity1WeightageTxt.Text) > 0) && (int.Parse(Activity1WeightageTxt.Text) <= 100) && (!check))
            {

                ActivityClass activity_new = new ActivityClass
                {
                    ActivityName = Activity1DD.SelectedValue
                };

                m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits[SubTraitDropDown.SelectedIndex - 1].AddActivity(activity_new, int.Parse(Activity1WeightageTxt.Text));
                m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits[SubTraitDropDown.SelectedIndex - 1].ActivitiesNames.Add(activity_new.ActivityName);
               
                // Add subtrait and its weight to Hashtable
                m.ActivitiesSelected[Activity1DD.SelectedIndex].AddSubtraitsToActivities(
                m.Traits[TraitDropDown.SelectedIndex - 1].SubTraits[SubTraitDropDown.SelectedIndex - 1].SubTraitID,
                int.Parse(Activity1WeightageTxt.Text)
                );

                Session["clicked"] = true;
                Session["mapping"] = m;
                Activity1WeightageTxt.Text = "";
            }
            else
            {
                string message = "alert('Invalid Information')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                Activity1WeightageTxt.Text = "";
            }
            Subtraitup.Update();
        }



        protected void SaveAllBtn_Click(object sender, EventArgs e)
        {
            RIASEC_List = (List<string>)Session["Activities"];

            ForteDataContext fdb = new ForteDataContext();
            ForteQuest fq = (ForteQuest)Session["NewFQ"];
            fdb.ForteQuests.InsertOnSubmit(fq);

            fdb.SubmitChanges();

            // Storing Mappings in database 
            Hashtable ht = new Hashtable();
            ht.Add("@rsubtraits", String.Join(",", m.Traits[0].SubTraitNames.ToList()));
            ht.Add("@isubtraits", String.Join(",", m.Traits[1].SubTraitNames.ToList()));
            ht.Add("@asubtraits", String.Join(",", m.Traits[2].SubTraitNames.ToList()));
            ht.Add("@ssubtraits", String.Join(",", m.Traits[3].SubTraitNames.ToList()));
            ht.Add("@esubtraits", String.Join(",", m.Traits[4].SubTraitNames.ToList()));
            ht.Add("@csubtraits", String.Join(",", m.Traits[5].SubTraitNames.ToList()));
            ht.Add("@rweights", String.Join(",", m.Traits[0].SubTraitWeights.ToList()));
            ht.Add("@iweights", String.Join(",", m.Traits[1].SubTraitWeights.ToList()));
            ht.Add("@aweights", String.Join(",", m.Traits[2].SubTraitWeights.ToList()));
            ht.Add("@sweights", String.Join(",", m.Traits[3].SubTraitWeights.ToList()));
            ht.Add("@eweights", String.Join(",", m.Traits[4].SubTraitWeights.ToList()));
            ht.Add("@cweights", String.Join(",", m.Traits[5].SubTraitWeights.ToList()));

            DBContext.ExecuteNonScalor("stp_Mapping_Insert", ht);

            // Updating ForteQuestMapping Link Table in database
            ForteQuestMapping FQM = new ForteQuestMapping();
            Mapping a = fdb.Mappings.SingleOrDefault(x => x == NewMapping);

            FQM.Mappings_MappingId = a.MappingId;
            FQM.ForteQuest_ForteQuestId = fq.ForteQuestId;

            fdb.ForteQuestMappings.InsertOnSubmit(FQM);
            fdb.SubmitChanges();

            // Get Activity Ids using their respective name from Activity table
            List<int> activityIds = new List<int>();

            foreach (string s in RIASEC_List)
            {
                Activities1 activity = new Activities1();

                var abc = from c in fdb.Activities1s
                          where c.ActivityName == s
                          select c.ActivityId;

                activityIds.Add(abc.ToList()[0]);
            }

            // Storing SubMappings in database from Hashtable 
            for (int i = 0; i < activityIds.Count; i++)
            {
                ICollection c = m.ActivitiesSelected[i].SubtraitTable.Keys;
                List<string> ActivitiesSelectedList = new List<string>();
                SubMapping s1 = new SubMapping();
                s1.Activity_ActivityId = activityIds[i];

                foreach (string k in c)
                {
                    ActivitiesSelectedList.Add(k);
                }

                if (ActivitiesSelectedList.Contains("R1_Weights"))
                {
                    s1.R1_Weights = m.ActivitiesSelected[i].SubtraitTable["R1_Weights"].ToString();
                }
                else { s1.R1_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("R2_Weights"))
                {
                    s1.R2_Weights = m.ActivitiesSelected[i].SubtraitTable["R2_Weights"].ToString();
                }
                else { s1.R2_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("R3_Weights"))
                {
                    s1.R3_Weights = m.ActivitiesSelected[i].SubtraitTable["R3_Weights"].ToString();
                }
                else { s1.R3_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("I1_Weights"))
                {
                    s1.I1_Weights = m.ActivitiesSelected[i].SubtraitTable["I1_Weights"].ToString();
                }
                else { s1.I1_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("I2_Weights"))
                {
                    s1.I2_Weights = m.ActivitiesSelected[i].SubtraitTable["I2_Weights"].ToString();
                }
                else { s1.I2_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("I3_Weights"))
                {
                    s1.I3_Weights = m.ActivitiesSelected[i].SubtraitTable["I3_Weights"].ToString();
                }
                else { s1.I3_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("A1_Weights"))
                {
                    s1.A1_Weights = m.ActivitiesSelected[i].SubtraitTable["A1_Weights"].ToString();
                }
                else { s1.A1_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("A2_Weights"))
                {
                    s1.A2_Weights = m.ActivitiesSelected[i].SubtraitTable["A2_Weights"].ToString();
                }
                else { s1.A2_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("A3_Weights"))
                {
                    s1.A3_Weights = m.ActivitiesSelected[i].SubtraitTable["A3_Weights"].ToString();
                }
                else { s1.A3_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("S1_Weights"))
                {
                    s1.S1_Weights = m.ActivitiesSelected[i].SubtraitTable["S1_Weights"].ToString();
                }
                else { s1.S1_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("S2_Weights"))
                {
                    s1.S2_Weights = m.ActivitiesSelected[i].SubtraitTable["S2_Weights"].ToString();
                }
                else { s1.S2_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("S3_Weights"))
                {
                    s1.S3_Weights = m.ActivitiesSelected[i].SubtraitTable["S3_Weights"].ToString();
                }
                else { s1.S3_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("E1_Weights"))
                {
                    s1.E1_Weights = m.ActivitiesSelected[i].SubtraitTable["E1_Weights"].ToString();
                }
                else { s1.E1_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("E2_Weights"))
                {
                    s1.E2_Weights = m.ActivitiesSelected[i].SubtraitTable["E2_Weights"].ToString();
                }
                else { s1.E2_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("E3_Weights"))
                {
                    s1.E3_Weights = m.ActivitiesSelected[i].SubtraitTable["E3_Weights"].ToString();
                }
                else { s1.E3_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("C1_Weights"))
                {
                    s1.C1_Weights = m.ActivitiesSelected[i].SubtraitTable["C1_Weights"].ToString();
                }
                else { s1.C1_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("C2_Weights"))
                {
                    s1.C2_Weights = m.ActivitiesSelected[i].SubtraitTable["C2_Weights"].ToString();
                }
                else { s1.C2_Weights = "0"; }

                if (ActivitiesSelectedList.Contains("C3_Weights"))
                {
                    s1.C3_Weights = m.ActivitiesSelected[i].SubtraitTable["C3_Weights"].ToString();
                }
                else { s1.C3_Weights = "0"; }

                fdb.SubMappings.InsertOnSubmit(s1);
                fdb.SubmitChanges();

                // Updating ForteQuestSubmapping Link Table in database
                ForteQuestSubMapping FQSM = new ForteQuestSubMapping();
                SubMapping b = fdb.SubMappings.SingleOrDefault(x => x == s1);

                FQSM.SubMappings_SubMappingId = b.SubMappingId;

                FQSM.ForteQuest_ForteQuestId = fq.ForteQuestId;

                fdb.ForteQuestSubMappings.InsertOnSubmit(FQSM);
                fdb.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Activities & Mapping Saved!');window.location ='Homepage.aspx';", true);
            }

        }

        protected void AddNewActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewActivityPage.aspx");
        }

    }

}