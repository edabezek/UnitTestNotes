using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingCard.Test
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Sepete_urun_eklenebilmelidir()
        {
            //Arrange
            const int beklenen = 1;//başlangıçta sepette eleman olmayacak o yüzden , sepete bir tane eleman eklediğimiz için sepettin eleman sayısı 1 olmuş olacak.

            var cardManager = new CardManager();
            var cardItem = new CardItem//1 tane ürün ürettik
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };
            
            //Act
            cardManager.Add(cardItem);//sepete 1 ürün ekledik
            var toplamElemanSayisi = cardManager.TotalItems;//ekledikten sonra sepete eleman sayısını getiriyoruz.

            //Assert
            Assert.AreEqual(beklenen, toplamElemanSayisi);//sepete bir eleman ekledikten sonra beklenen değer 1 olmalı,bunu en son durumdaki toplam eleman sayısı ile karşılaştırıyoruz. 
        }
        [TestMethod]
        public void Sepette_olan_urun_cikarilabilmelidir()//ürün çıkarabilmek için önce sepette ürün olmalı.
        {
            //Arrange
            var cardManager = new CardManager();
            var cardItem = new CardItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };

            cardManager.Add(cardItem); //ürünü ekliyoruz.
            var sepetteOlanElemanSayisi = cardManager.TotalItems;//ekledikten sonraki eleman sayısını alıyoruz,şuan 1

            //Act
            cardManager.Remove(1);//id=1 olan ürün silinir
            var sepetteKalanElemanSayisi = cardManager.TotalItems;//sepet eleman sayısı 0

            //Assert
            Assert.AreNotEqual(sepetteKalanElemanSayisi-1, sepetteOlanElemanSayisi); //ikisi de 0 olmalı 
        }
        [TestMethod]
        public void Sepette_temizlenebilmelidir()
        {
            //Arrange
            var cardManager = new CardManager();
            var cardItem = new CardItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };

            cardManager.Add(cardItem);

            //Act
            cardManager.Clear();

            //Assert
            Assert.AreEqual(0,cardManager.TotalQuantity);//sepetteki eleman adedinin 0 olması 
            Assert.AreEqual(0,cardManager.TotalItems);//sepetteki toplam eleman sayısının 0 olması
        }

    }
}
