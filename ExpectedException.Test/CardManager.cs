using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpectedException.Test
{

    //aynı ürünü ikinci kez sepete eklememeli
    public class CardManager
    {
        private readonly List<CardItem> _cardItems;
        public CardManager()
        {
            _cardItems = new List<CardItem>();
        }
        public void Add(CardItem cardItem)
        {

            var addedCardItem = _cardItems.SingleOrDefault(t => t.Product.ProductId == cardItem.Product.ProductId);
            if (addedCardItem == null)
            {
                _cardItems.Add(cardItem);//sepette ürün yoksa ekliyoruz
            }
            else//varsa hata verecek
            {
                throw new ArgumentException("This product has already been added");
            }

        }
        public void Remove(int productId)
        {
            var product = _cardItems.FirstOrDefault(t => t.Product.ProductId == productId);
            _cardItems.Remove(product);
        }
        public List<CardItem> CardItems
        {
            get { return _cardItems; }
        }
        public void Clear()
        {
            _cardItems.Clear();
        }
        public decimal TotalPrice//toplam ürün fiyatı getirecek
        {
            get { return _cardItems.Sum(t => t.Quantity * t.Product.UnitPrice); }
        }
        public decimal TotalQuantity//toplam ürün adedi
        {
            get { return _cardItems.Sum(t => t.Quantity); }
        }
        public int TotalItems //toplam eleman sayısı
        {
            get { return _cardItems.Count(); }
        }
    }
}
