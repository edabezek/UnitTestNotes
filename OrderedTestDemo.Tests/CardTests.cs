using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OrderedTestDemo.Tests
{
    [TestClass]
    public class CardTests
    {
        private static CardManager _cardManager;
        private static int id = 0;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _cardManager = new CardManager();
        }


        [TestMethod]
        public void Sepete_urun_eklendiginde_sepetteki_urun_sayisi_1_artmalidir()
        {
            var adet = _cardManager.TotalQuantity;

            id++;

            _cardManager.Add( new CardItem//1 tane ürün ürettik
            {
                Product = new Product
                {
                    ProductId = id,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            });

            Assert.AreEqual(adet+1, _cardManager.TotalQuantity);
        }
        [TestMethod]
        public void Sepette_olan_urun_cikarildiginda_sepetteki_urun_sayisi_1_azalmalidir()
        {
            var adet = _cardManager.TotalQuantity;

            _cardManager.Remove(id);

            id--;

            Assert.AreEqual(adet - 1, _cardManager.TotalQuantity); 
        }
        [TestMethod]
        public void Sepet_temizlendiginde_sepette_urun_kalmamalidir()
        {
            _cardManager.Clear();   

            Assert.AreEqual(0, _cardManager.TotalItems);
            Assert.AreEqual(0, _cardManager.TotalQuantity);
        }

    }
}
