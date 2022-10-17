using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingCard.Test
{
    [TestClass]
    public class CardTestTestLevel
    {
        private CardItem _cardItem;
        private CardManager _cardManager;   

        [TestInitialize]
        public void TestInitialize()//ortak olan nesneleri koyduk
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
        [TestCleanup]
        public void TestCleanUp()//her test bittikten sonra sepeti temizleyecek,(aslında initialize'da sepet newlendiğinde sıfırdan oluşur ,hoca kullanımını göstermek için yazdı)
        {
            _cardManager.Clear();
        }

        [TestMethod]
        public void Sepete_urun_eklenebilmelidir()
        {
            
            const int beklenen = 1;

            var toplamElemanSayisi = _cardManager.TotalItems;


            Assert.AreEqual(beklenen, toplamElemanSayisi);
        }
        [TestMethod]
        public void Sepette_olan_urun_cikarilabilmelidir()
        {
            var sepetteOlanElemanSayisi = _cardManager.TotalItems;

            _cardManager.Remove(1);

            var sepetteKalanElemanSayisi = _cardManager.TotalItems;

            Assert.AreNotEqual(sepetteKalanElemanSayisi - 1, sepetteOlanElemanSayisi); 
        }
        [TestMethod]
        public void Sepette_temizlenebilmelidir()
        {

            _cardManager.Clear();

            Assert.AreEqual(0, _cardManager.TotalQuantity);
            Assert.AreEqual(0, _cardManager.TotalItems);
        }

    }
}
