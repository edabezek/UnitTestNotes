using System;
using System.Collections.Generic;
using System.Linq;

namespace TestFirstDevelopment
{
    public class Gruplayici
    {
        private int _grupSayisi;

        public Gruplayici(int grupSayisi)
        {
            this._grupSayisi = grupSayisi;
        }

        public List<List<Olcum>> Grupla(List<Olcum> olcumler)//olcum listelerinin tutulduğu başka bir liste return edecek
        {
            var gruplar = new List<List<Olcum>>();  //eleman sayısı 0
            gruplar.Add(olcumler); //bir tane eleman ekliyoruz

            return gruplar; //bir eleman dönecek
        }
        public List<List<Olcum>> Grupla6(List<Olcum> olcumler)
        {
            var gruplar = new List<List<Olcum>>();

            for (int i = 0; i < olcumler.Count;)
            {
                var group = olcumler.Skip(i).Take(_grupSayisi).ToList();

                gruplar.Add(group);

                i += _grupSayisi;
            }
            return gruplar; 
        }
    }
}