using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AssertsCollection
{
    [TestClass]
    public class UnitTest1
    {
        private List<string> _kullanicilar;
        [TestInitialize]
        public void DataOlustur()
        {
            _kullanicilar = new List<string>();

            _kullanicilar.Add("Eda");
            _kullanicilar.Add("Engin");
            _kullanicilar.Add("Ali");
        }
        [TestMethod]
        public void Elemanlar_ve_sirasi_ayni_olmalı()
        {
            List<string> yeniKullanicilar = new List<string>();

            yeniKullanicilar.Add("XA");
            yeniKullanicilar.Add("Tian");
            yeniKullanicilar.Add("Zion");

            CollectionAssert.AreEqual(yeniKullanicilar, _kullanicilar);
        }
        [TestMethod]
        public void Elemanlar_ayni_fakat_sirasi_farklı_olabilir()
        {
            List<string> yeniKullanicilar = new List<string>();

            yeniKullanicilar.Add("Eda");
            yeniKullanicilar.Add("Ali");
            yeniKullanicilar.Add("Engin");

            CollectionAssert.AreEquivalent(yeniKullanicilar, _kullanicilar);
        }
        [TestMethod]
        public void Elemanlar_ve_sirasi_ayni_olmali()
        {
            List<string> yeniKullanicilar = new List<string>();

            yeniKullanicilar.Add("Eda");
            yeniKullanicilar.Add("Ali");
            yeniKullanicilar.Add("Engin");

            CollectionAssert.AreNotEqual(yeniKullanicilar, _kullanicilar);
        }
        [TestMethod]
        public void Elemanlar_farkli_olmali()
        {
            List<string> yeniKullanicilar = new List<string>();

            yeniKullanicilar.Add("Eda");
            yeniKullanicilar.Add("Ali");
            yeniKullanicilar.Add("Engin");
            yeniKullanicilar.Add("Mustafa");

            CollectionAssert.AreNotEquivalent(yeniKullanicilar, _kullanicilar);
        }
        [TestMethod]
        public void Kullanicilar_null_deger_almamalidir()
        {
            //_kullanicilar.Add(null);
            CollectionAssert.AllItemsAreNotNull( _kullanicilar);
        }
        [TestMethod]
        public void Kullanicilar_benzersiz_olmalidir()
        {
            //_kullanicilar.Add("Salih");
            CollectionAssert.AllItemsAreUnique(_kullanicilar);
        }
        [TestMethod]
        public void Tum_elemanlar_ayni_tipte_olmalidir()
        {
            ArrayList liste = new ArrayList 
            { 
                "Salih", "Engin", "Ahmet" //5
            };

            CollectionAssert.AllItemsAreInstancesOfType(liste,typeof(string));
        }
        [TestMethod]
        public void IsSubsetOf_test()
        {
            List<string> yeniKullanicilar = new List<string>() { "Salih","Engin"};
            List<string> eskiKullanicilar = new List<string>() { "Salih","Ali"};


            CollectionAssert.IsSubsetOf(yeniKullanicilar, _kullanicilar);
            CollectionAssert.IsNotSubsetOf(eskiKullanicilar, _kullanicilar);
        }
        [TestMethod]
        public void Contains_test()
        {
            CollectionAssert.Contains(_kullanicilar,"Salih");
            CollectionAssert.DoesNotContain(_kullanicilar, "Cevat");
        }
    }
}
