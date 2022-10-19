using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestFirstDevelopment.Test
{
    [TestClass]
    public class GruplayiciTest
    {
        private List<Olcum> OlcumListesiUlustur(int adet)
        {
            var olcumler=new List<Olcum>();

            for (int i = 0; i < adet; i++)
            {
                olcumler.Add(new Olcum
                {
                    EnYuksek = 10,
                    EnDusuk = 1

                });
            }
            return olcumler;
        }
        [TestMethod]
        public void bir_elemanli_liste_birerli_gruplanmak_istendiginde_grup_sayisi_1_olmalidir()
        {
            var olcumler = new List<Olcum>()//bir tane eleman listesi
            {
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                }
            };
            var gruplayici = new Gruplayici(1);//1'er gruplamak istiyoruz
            var gruplar = gruplayici.Grupla(olcumler);

            Assert.AreEqual(1, gruplar.Count);  //grup liste sayısı 1, olucak list
        }
        [TestMethod]
        public void alti_elemanli_liste_ikiserli_gruplanmak_istendiginde_grup_sayisi_3_olmalidir() //elimizde 6 tane elemanlı liste var,bunları 2li gruplara ayırmak istiyoruz.
        {
            var olcumler = new List<Olcum>()
            {
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                },
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                },
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                },
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                },
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                },
                new Olcum
                {
                    EnYuksek=10,
                    EnDusuk=1

                }

            };
            var gruplayici = new Gruplayici(2);
            var gruplar = gruplayici.Grupla6(olcumler);

            Assert.AreEqual(3, gruplar.Count); 
        }
        [TestMethod]
        public void elli_elemanli_liste_onarlı_gruplanmak_istendiginde_grup_sayisi_5_olmalidir() 
        {
            var olcumler = OlcumListesiUlustur(50);

            var gruplayici = new Gruplayici(10);

            var gruplar = gruplayici.Grupla6(olcumler);

            Assert.AreEqual(5, gruplar.Count);
        }
    }
}
