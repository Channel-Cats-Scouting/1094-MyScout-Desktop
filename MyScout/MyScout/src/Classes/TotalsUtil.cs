using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                                var total = addedValues / rounds.Count;
                            }
                            break;

                        //TODO: Add more cases! Total is probably not the only way we can deal with data points.
                    }
                }
            }
            var actionresult = 0;
            var output = Convert.ChangeType(actionresult, dataType); //Convert the output to the datatype's 'type'
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
                    if (r.teams[j] == index)
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
            for(int i = 0; i < round.dataset[teamIndex].Count; i++)
            {
                if(round.dataset[teamIndex][i].GetName() == dataPointName)
                {
                    return round.dataset[teamIndex][i];
                }
            }
            return null;
        }

        public static bool IsNumeric(string text)
        {
            double test;
            return double.TryParse(text, out test);
        }
    }
}
