using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingCard.Test
{
    [TestClass]
    public class CardTestClassLevel
    {
        private static CardItem _cardItem;
        private static CardManager _cardManager;   

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _cardManager = new CardManager();
            _cardItem = new CardItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };
            _cardManager.Add(_cardItem);
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            _cardManager.Clear();
        }

        [TestMethod]
        public void Sepette_farkli_üründen_1_adet_eklendiğinde_sepetteki_toplam_urun_adedi_ve_eleman_sayisi_bir_artmalidir()
        {
            //Arrange
            int toplamAdet = (int)_cardManager.TotalQuantity;//Sepetteki toplam adet
            int toplamElemanSayisi = _cardManager.TotalItems;//Sepetteki toplam eleman sayısı

            //Act
            _cardManager.Add(new CardItem
            {
                Product = new Product//farklı bir ürün ekliyoruz,sepette laptop vardı
                {
                    ProductId = 2,
                    ProductName = "Mause",
                    UnitPrice = 10
                },
                Quantity = 1//1 adet ekliyoruz
            });
            //_cardManager.Add(_cardItem);

            //Assert
            Assert.AreEqual(toplamAdet+1, _cardManager.TotalQuantity);//toplam adet 1 artmalı , sepete yeni ürün ekledikten sonraki adeti karşılaştırıyoruz.
            Assert.AreEqual(toplamElemanSayisi+1, _cardManager.TotalItems);//toplam eleman sayısı da 1 artmalı,ürün ekledikten sonraki eleman sayısı karşılaştırıyoruz.
        }
        [TestMethod]
        public void Sepette_farkli_urunden_1_adet_eklendiginde_sepetteki_toplam_urun_adedi_ve_eleman_sayisi_birer_artmalidir()
        {
            //sepette id=1 olan ürün var 
            int toplamAdet = (int)_cardManager.TotalQuantity;
            int toplamElemanSayisi = (int)_cardManager.TotalItems;


            _cardManager.Add(_cardItem);//yine aynı ürünü ekliyoruz(Laptop)

            //Assert
            Assert.AreEqual(toplamAdet+1,_cardManager.TotalQuantity);//toplam adet 1 artacak
            Assert.AreEqual(toplamElemanSayisi, _cardManager.TotalItems);//eleman sayısı aynı kalacak
        }
    }
}
