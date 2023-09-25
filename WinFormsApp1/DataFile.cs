using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class DataFile
    {
        public string FileName { get; set; }
        public List<Data> Data { get; set; }
      

        public DataFile(List<Data> data, string fileName)
        {
            Data = data;
            FileName = fileName;
        }
    }
}
