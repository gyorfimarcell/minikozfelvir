using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace miniKozfelvir
{
    public class Felvetelizo: IFelvetelizo
    {
        public const string CSVFEJ = "om_azonosito;nev;email;szuletesi_datum;ertesitesi_cim;matek_eredmeny;magyar_eredmeny";

        string omAzon;
        string nev;
        string email;
        DateTime szuletesiDatum;
        string ertesitesiCim;
        byte? matek;
        byte? magyar;

        public Felvetelizo(string omAzon, string nev, string email, DateTime szuletesiDatum, string ertesitesiCim, byte? matek, byte? magyar)
        {
            this.omAzon = omAzon;
            this.nev = nev;
            this.email = email;
            this.szuletesiDatum = szuletesiDatum;
            this.ertesitesiCim = ertesitesiCim;
            this.matek = matek;
            this.magyar = magyar;
        }

        public Felvetelizo(string csvSor)
        {
            ModositCSVSorral(csvSor);
        }

        public string OM_Azonosito { get => omAzon; set => throw new NotImplementedException(); }
        public string Neve { get => nev; set => throw new NotImplementedException(); }
        public string ErtesitesiCime { get => ertesitesiCim; set => throw new NotImplementedException(); }
        public string Email { get => email; set => throw new NotImplementedException(); }
        public DateTime SzuletesiDatum { get => szuletesiDatum; set => throw new NotImplementedException(); }
        public int Matematika { get => Convert.ToInt32(matek); set => throw new NotImplementedException(); }
        public int Magyar { get => Convert.ToInt32(magyar); set => throw new NotImplementedException(); }

        public override string ToString()
        {
            return $"{omAzon};{nev};{email};{szuletesiDatum};{ertesitesiCim};{matek};{magyar}";
        }

        public string CSVSortAdVissza()
        {
            return ToString();
        }

        public void ModositCSVSorral(string csvString)
        {
            string[] mezok = csvString.Split(';');

            this.omAzon = mezok[0];
            this.nev = mezok[1];
            this.email = mezok[2];
            this.szuletesiDatum = DateTime.Parse(mezok[3]);
            this.ertesitesiCim = mezok[4];

            byte _matek;
            this.matek = Byte.TryParse(mezok[5], out _matek) ? (byte?)_matek : null;

            byte _magyar;
            this.magyar = Byte.TryParse(mezok[6], out _magyar) ? (byte?)_magyar : null;
        }
    }
}