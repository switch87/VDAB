using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    // 29 ---= Operator overloading =---

    /*
     * Met operator overloading kan je een eigen betekenis geven aan 
     * de operatoren van C# (+, -, ==, >, >=, ...) wanneer je deze 
     * operatoren wil toepassen voor objecten van een eigen geschreven class.
     */

    // 29.2 --- De Class Breuk ---
    public class Breuk
    {
        int tellerValue;
        int noemerValue;

        public int Teller
        {
            get
            {
                return tellerValue;
            }
            set
            {
                tellerValue = value;
            }
        }

        public int Noemer
        {
            get
            {
                return noemerValue;
            }
            set
            {
                if (value == 0)
                    throw new Exception("noemer mag niet nul zijn.");
                noemerValue = value;
            }
        }
        public Breuk(int teller, int noemer)
        {
            Teller = teller;
            Noemer = noemer;
        }

        public override string ToString()
        {
            return Teller + "/" + Noemer;
        }

        public override bool Equals(object obj)
        {
            if (obj is Breuk)
            {
                Breuk andereBreuk = (Breuk)obj;
                return (decimal)Teller / Noemer ==
                    (decimal)andereBreuk.Teller / andereBreuk.Noemer;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Teller + Noemer;
        }


        // 29.3 --- De Vergelijkingsoperatoren ---
        public static bool operator ==(Breuk eerste, Breuk tweede)
        {
            return eerste.Equals(tweede);
        }

        public static bool operator !=(Breuk eerste, Breuk tweede)
        {
            return !eerste.Equals(tweede);
        }


        // 29.4 --- De wiskundige operatoren met twee waarden ---
        public static Breuk operator *(Breuk breuk, int waarde)
        {
            return new Breuk(breuk.Teller * waarde, breuk.Noemer);
        }


        // 29.5 --- De operatoren met 1 verhogen of verlagen (++,--) ---
        public static Breuk operator ++(Breuk breuk)
        {
            return new Breuk(breuk.Teller + breuk.Noemer, breuk.Noemer);
        }

        public static Breuk operator --(Breuk breuk)
        {
            return new Breuk(breuk.Teller - breuk.Noemer, breuk.Noemer);
        }


        // 29.6 --- De verkorte operatoren (+=,-=,*=,/=,%=)
        
        /*
         * Je kan de verkorte operatoren niet overloaden, maar dit is ook niet nodig.
         * 
         * Als je overloading hebt toegepast van de bijbehorende wiskundige operatoren, 
         * kan je ook de verkorte operatoren voor je class objecten toepassen. 
         * Als je bijvoorbeeld operator overloading van de * operator hebt toegepast, 
         * kan je ook de *= operator gebruiken voor je class objecten.
         */


        // 29.7 --- Conversie operatoren
        public static implicit operator double(Breuk breuk)
        {
            return (double)breuk.tellerValue / (double)breuk.Noemer;
        }
        /*
         * De conversie naar double veroorzaakt geen exception of informatieverlies. 
         * Daarom voorzie je deze conversie operator van het sleutelwoord implicit.
         */

        public static explicit operator int(Breuk breuk)
        {
            return breuk.Teller / breuk.Noemer;
        }
        /*
         * De conversie naar int veroorzaakt mogelijk informatieverlies. 
         * Daarom voorzie je deze conversie operator van het sleutelwoord explicit.
         * 
         * Je converteert een breuk naar een int. Hierbij pas je een explicit conversie toe. 
         * Bij een explicit conversie moet je bij het gebruik van de conversie het type 
         * waarnaar je converteert (int) tussen ronde haakjes vermelden vóór het object dat je converteert.
         */


        // 29.8 --- De operatoren true en false ---
        public static bool operator true(Breuk breuk)
        {
            return breuk.Teller < breuk.Noemer;
        }

        public static bool operator false(Breuk breuk)
        {
            //return breuk.Teller >= breuk.Noemer;
            return !breuk;
        }

        public static bool operator !(Breuk breuk)
        {
            if (breuk)
                return false;
            else
                return true;
        }


    }
}
