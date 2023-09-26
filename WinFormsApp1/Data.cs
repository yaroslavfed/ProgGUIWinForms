using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public class Data
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Data() { }
        public Data(string line)
        {
            var data = line.Split(',');
            X = double.Parse(data[0]);
            Y = double.Parse(data[1]);
        }


        public string ToCsv()
        {
            return string.Format("{0},{1}", X, Y);
        }
       
    }
}