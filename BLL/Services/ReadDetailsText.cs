using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace APIendBackStore.Services
{
    public class ReadDetailsText
    {
        //object to read the file
        FileStream fs;
        StreamReader reader;
        string str;
        public string codOfBizness;
        string[] FileOfTable;
        string TableTitle;
        bool IsNumbered;
        //object to save the details that we took out from the file
        string companyCod;
        int placeToSplit;

        public ReadDetailsText(string fileUrl)
        {
            fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
            //reader = new StreamReader(fs);
            //str = reader.ReadLine();
        }

        public void PassingOnTheText()
        {

            using (var streamReader = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains("עוסק מורשה"))
                    {
                        Console.WriteLine(line);
                        placeToSplit = line.IndexOf(':');



                        codOfBizness = line.Substring(placeToSplit + 1, 10);

                    }

                }
            }
        }
        public void FindTheTable()
        {


            int indexeToTable = 0;
            using (var streamReader = new StreamReader(fs, Encoding.UTF8))
            {

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //מציאת הכותרת של הטבלה
                    if (line.Contains("תאור") && line.Contains("כמות") && line.Contains("מחיר"))
                    {
                        while (TableTitle != "")
                        {
                            TableTitle = line;
                            //האם הטבלה ממוספרת
                            if (TableTitle.Substring(1, 1) == " ")
                            {
                                FileOfTable[indexeToTable] = "מספר";
                                IsNumbered = true;
                            }

                            else
                                IsNumbered = false;
                        }


                    }

                }
            }
        }
    }
}