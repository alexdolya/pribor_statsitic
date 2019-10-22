using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10m_stat
{
    public class Pribor
    {
        public Pribor(string s)
        {
            _path = s;
            _number = s.Remove(0, Environment.CurrentDirectory.Length + 1);          
            _dus = new string[3];
            _pog_km = new string[3];
            _nel_km = new string[3];
            _w = new string[3];
            _dw = new string[3];
            _wzzap = new string[3];
            _wr1 = new string[3];
            _wr2 = new string[3];            
        }

        public Pribor (string [] values)
        {            
            _dus = new string[3];
            _pog_km = new string[3];
            _nel_km = new string[3];
            _w = new string[3];
            _dw = new string[3];
            _wzzap = new string[3];
            _wr1 = new string[3];
            _wr2 = new string[3];
            _number = values[0];            
            _dus[0] = values[1];
            _dus[1] = values[2];
            _dus[2] = values[3];
            _pog_km[0] = values[4];
            _pog_km[1] = values[5];
            _pog_km[2] = values[6];
            _nel_km[0] = values[7];
            _nel_km[1] = values[8];
            _nel_km[2] = values[9];
            _w[0] = values[10];
            _w[1] = values[11];
            _w[2] = values[12];
            _dw[0] = values[13];
            _dw[1] = values[14];
            _dw[2] = values[15];
            _wzzap[0] = values[16];
            _wzzap[1] = values[17];
            _wzzap[2] = values[18];
            _wr1[0] = values[19];
            _wr1[1] = values[20];
            _wr1[2] = values[21];
            _wr2[0] = values[22];
            _wr2[1] = values[23];
            _wr2[2] = values[24];            
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }        
        private string [] _dus;
        public string [] Dus
        {
            get { return _dus; }
            set { _dus = value; }   
        }

        private string[] _pog_km;
        public string[] Pog_km
        {
            get { return _pog_km; }
            set { _pog_km = value; }
        }

        private string[] _nel_km;
        public string[] Nel_km
        {
            get { return _nel_km; }
            set { _nel_km = value; }
        }

        private string[] _w;
        public string[] W
        {
            get { return _w; }
            set { _w = value; }
        }

        private string[] _dw;
        public string[] Dw
        {
            get { return _dw; }
            set { _dw = value; }
        }

        private string[] _wzzap;
        public string[] Wzzap
        {
            get { return _wzzap; }
            set { _wzzap = value; }
        }

        private string[] _wr1;
        public string[] Wr1
        {
            get { return _wr1; }
            set { _wr1 = value; }
        }

        private string[] _wr2;
        public string[] Wr2
        {
            get { return _wr2; }
            set { _wr2 = value; }
        }

    }
}
