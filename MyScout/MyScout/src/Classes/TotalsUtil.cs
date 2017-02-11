using System;
using System.Collections.Generic;

namespace MyScout
{
    class TotalsUtil
    {

        /// <summary>
        /// Compiles all round scores for a team into the associated compiling datapoint using its script.
        /// </summary>
        /// <param name="teamIndex"></param>
        /// <param name="funcScript"></param>
        /// <param name="compIndex"></param>
        /// <returns></returns>
        public static dynamic execFunction(int teamIndex, int compIndex)
        {
            object actionresult = 0;
            List<Round> teamRounds = getRoundsFromTeamIndex(teamIndex);
            Type dataType = Program.DataSet[2][compIndex].GetDataType();
            string funcScript = Program.DataSet[2][compIndex].GetScript();
            int charcount = funcScript.Length;
            char[] scriptchars = funcScript.ToCharArray();

            for(int i = 0; i < funcScript.Length; i++) //Find a bracketed action ex. [total]{DataPointName}
            {
                if(scriptchars[i] == '[')
                {
                    string action = "";
                    string datapointName = "";
                    int c;
                    for(c = i+1; scriptchars[c] != ']'; c++) //Get the action as a string
                    {
                        action += scriptchars[c];
                    }

                    for(int dp = c+2; scriptchars[dp] != '}'; dp++) //Get the datapoint name as a string
                    {
                        datapointName += scriptchars[dp];
                        i = dp; //Set the current index to the end of the statement.
                    }
                    
                    switch(action) //Figure out what to do based on the bracketed action
                    {
                        case "total": //Totals either boolean or numeric datapoints.
                            {
                                List<Round> rounds = getRoundsFromTeamIndex(teamIndex);
                                float total = 0;
                                for (int r = 0; r < rounds.Count; r++)
                                {
                                    DataPoint roundDataPoint = getRoundDataPointByName(rounds[r], teamIndex, datapointName);
                                    if (roundDataPoint.GetType() == typeof(bool))
                                    {
                                        total += ((bool)roundDataPoint.GetValue() ? 1 : 0);
                                    }
                                    else if (IsNumeric(roundDataPoint.GetValue().ToString()))
                                    {
                                        float f = float.Parse(roundDataPoint.GetValue().ToString()); //This lets it parse correctly. I don't know why, something to do with a parse exception with (float). Don't ask me. :/
                                        total += f;
                                    }
                                }
                                actionresult = total;
                            }
                            break;

                        case "avg": //Averages numeric values
                            {
                                List<Round> rounds = getRoundsFromTeamIndex(teamIndex);
                                float addedValues = 0;
                                for (int r = 0; r < rounds.Count; r++)
                                {
                                    DataPoint roundDataPoint = getRoundDataPointByName(rounds[r], teamIndex, datapointName);
                                    if (IsNumeric(roundDataPoint.GetValue().ToString()))
                                    {
                                        float f = float.Parse(roundDataPoint.GetValue().ToString());
                                        addedValues += f;
                                    }
                                }
                                actionresult = addedValues / rounds.Count;
                            }
                            break;
                        case "checkon": //If its round value is true, this is true, forever.
                            {
                                List<Round> rounds = getRoundsFromTeamIndex(teamIndex);
                                bool check = false;
                                for(int r = 0; r < rounds.Count; r++)
                                {
                                    DataPoint roundDataPoint = getRoundDataPointByName(rounds[r], teamIndex, datapointName);
                                    if ((IsNumeric(roundDataPoint.GetValue().ToString()) && (float)roundDataPoint.GetValue() > 0) || 
                                        !IsNumeric(roundDataPoint.GetValue().ToString()) && (bool)roundDataPoint.GetValue())
                                    {
                                        check = true;
                                        break;
                                    }
                                }

                                actionresult = check;
                            }
                            break;

                        //TODO: Add more cases! Total is probably not the only way we can deal with data points.
                    }
                }
            }
            var output = Convert.ChangeType(actionresult, dataType); //Convert the output to the datatype's 'type'
            Program.CurrentEvent.teams[teamIndex].GetCompiledScoreDataset()[compIndex].SetValue(output);
            return output;
        }

        public static List<Round> getRoundsFromTeamIndex(int index)
        {
            List<Round> rounds = new List<Round>();
            Team team = Program.Events[Program.CurrentEventIndex].teams[index];
            //for each round in the event
            foreach (Round r in Program.Events[Program.CurrentEventIndex].rounds)
            {
                //for each team index in the round
                for (int j = 0; j < 5; j++)
                {
                    //if the team index is the same as the round's team index
                    if (r.Teams[j] == index)
                    {
                        rounds.Add(r);
                    }
                }
            }

            return rounds;
        }

        /// <summary>
        /// Gets a round datapoint for a given team from its name. Returns Datapoint found, or null if there isn't one with that name.
        /// </summary>
        /// <param name="round"></param>
        /// <param name="teamIndex"></param>
        /// <param name="dataPointName"></param>
        /// <returns></returns>
        public static DataPoint getRoundDataPointByName(Round round, int teamIndex, string dataPointName)
        {
            int localIndex = getTeamLocalIndex(round, teamIndex);
            for (int i = 0; i < round.DataSet[localIndex].Count; i++)
            {
                if(round.DataSet[localIndex][i].GetName() == dataPointName)
                {
                    return round.DataSet[localIndex][i];
                }
            }
            return null;
        }

        /// <summary>
        /// Finds the 0-5 local index of a team in a round, or returns -1 if the team isn't in this round.
        /// </summary>
        /// <param name="round"></param>
        /// <param name="teamIndex"></param>
        /// <returns></returns>
        public static int getTeamLocalIndex(Round round, int teamIndex)
        {
            for(int i = 0; i < 5; i++)
            {
                if(round.Teams[i] == teamIndex)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns true if it's a number, false if it's NaN
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNumeric(string text)
        {
            double test;
            return double.TryParse(text, out test);
        }

        /// <summary>
        /// Grabs every single round datapoint for a certain team, and adds up all the score values. Currently supports int and boolean datapoints.
        /// </summary>
        /// <param name="teamindex"></param>
        public static void updateTeamTotalScore(int teamindex)
        {
            List<Round> rounds = getRoundsFromTeamIndex(teamindex);
            for (int i = 0; i < rounds.Count; i++) //for every round this team is in
            {
                foreach(DataPoint d in rounds[i].DataSet[getTeamLocalIndex(rounds[i], teamindex)])
                {
                    if(d.datatype == typeof(bool)) //If it's a boolean, add the point value only if it's true
                    {
                        Program.CurrentEvent.teams[teamindex].AddToScore((bool)d.GetValue() ? d.GetPointValue() : 0);
                    }
                    else if(d.datatype == typeof(int)) //If it's an int, add the int * pointvalue
                    {
                        Program.CurrentEvent.teams[teamindex].AddToScore((int)d.GetValue() * d.GetPointValue());
                    }
                }
            }
        }
    }
}
