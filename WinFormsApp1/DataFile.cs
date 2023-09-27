using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class DataFile
    {
        public string FileName { get; set; }
        public List<Data> Data { get; set; }
      

        public DataFile(string fileName, List<Data> data )
        {
            Data = data;
            FileName = fileName;
        }

        public static DataFile CsvFileToDataFile(string fileName)
        {
            
            var dataList = new List<Data>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    dataList.Add(new Data(line));
                }
            }
            return  new DataFile(Path.GetFileName(fileName), dataList);
        }
    }
}
