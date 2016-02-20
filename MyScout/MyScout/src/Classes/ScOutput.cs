using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScout
{
    static class ScOutput
    {
        public static void CreateTeamSpreadsheet(List<Team> teamList, Event e)
        {
            string folderpath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.MyDoc‌​uments), "MyScout 2016");

            string filepath = Path.Combine(folderpath, ("Scouting Report " + e.name + ".xls"));

            if (Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                File.Delete(filepath);
            }
            else Directory.CreateDirectory(folderpath);

            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Scouting Report");
            worksheet.Cells[0, 0] = new Cell("ID");
            worksheet.Cells.ColumnWidth[0] = 1500;

            worksheet.Cells[0, 1] = new Cell("Name");
            worksheet.Cells.ColumnWidth[1] = 2500;

            worksheet.Cells[0, 2] = new Cell("Score");
            worksheet.Cells.ColumnWidth[2] = 1500;

            worksheet.Cells[0, 3] = new Cell("High Goals");
            worksheet.Cells[0, 4] = new Cell("Low Goals");
            worksheet.Cells[0, 5] = new Cell("DefScore");
            worksheet.Cells.ColumnWidth[3, 5] = 2500;

            worksheet.Cells[0, 6] = new Cell("Defs:");
            worksheet.Cells.ColumnWidth[6] = 1250;

            worksheet.Cells[0, 7] = new Cell("PC");
            worksheet.Cells[0, 8] = new Cell("CF");
            worksheet.Cells[0, 9] = new Cell("M");
            worksheet.Cells[0, 10] = new Cell("RP");
            worksheet.Cells[0, 11] = new Cell("DB");
            worksheet.Cells[0, 12] = new Cell("SP");
            worksheet.Cells.ColumnWidth[7, 12] = 900;

            worksheet.Cells[0, 13] = new Cell("RW");
            worksheet.Cells.ColumnWidth[13] = 1000;

            worksheet.Cells[0, 14] = new Cell("RT");
            worksheet.Cells[0, 15] = new Cell("LB");
            worksheet.Cells.ColumnWidth[14, 15] = 900;

            for (int i = 1; i < (teamList.Count() + 1); i++)
            {
                Team team = teamList[i - 1];
                worksheet.Cells[i, 0] = new Cell(team.id);
                worksheet.Cells[i, 1] = new Cell(team.name);
                worksheet.Cells[i, 2] = new Cell(team.totalScore);
                worksheet.Cells[i, 3] = new Cell(team.teleHighGoals);
                worksheet.Cells[i, 4] = new Cell(team.teleLowGoals);
                worksheet.Cells[i, 5] = new Cell(team.crossingPowerScore);
                for (int j = 0; j < 8; j++)
                {
                    team.defensesCrossable[i] = true;
                    if (team.defensesCrossable[j])
                        worksheet.Cells[i, (j + 6)] = new Cell(" " + ((char)0x221A).ToString());
                }
            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(filepath);
        }
    }
}
