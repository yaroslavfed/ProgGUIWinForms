using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class HsvColor
    {
        public int H
        {
            get => H;
            set
            {
                if (value > -1 && value < 360)
                    H = value;
            }
        }
        public float S
        {
            get => S;
            set
            {
                if (value >= 0 && value <= 1)
                    S = value;
            }
        }
        public float V
        {
            get => V;
            set
            {
                if (value >= 0 && value <= 1)
                    V = value;
            }
        }

        public HsvColor(int H, float S, float V)
        {
            this.H = H;
            this.S = S;
            this.V = V;
        }

        public Color ConvertToRGB()
        {
            float C = V * S;
            float X = C * (1 - Math.Abs(H / 60 % 2 - 1));
            float m = V - C;

            float _R = 0;
            float _G = 0;
            float _B = 0;

            switch (H)
            {
                case < 60:
                    _R = C;
                    _G = X;
                    break;

                case < 120:
                    _R = X;
                    _G = C;
                    break;

                case < 180:
                    _G = C;
                    _B = X;
                    break;

                case < 240:
                    _G = X;
                    _B = C;
                    break;

                case < 300:
                    _R = X;
                    _B = C;
                    break;

                case < 360:
                    _R = C;
                    _B = X;
                    break;

                default:
                    break;
            }
        

            return Color.FromArgb((int)(_R + m) * 255, (int)(_G + m) * 255, (int)(_B + m) * 255);
        }


    }
}
