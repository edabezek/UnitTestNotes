using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard
{
    //gereksinimler :
    //1.Sepete ürün eklenebilmeli
    //2.Sepetten ürün çıkartılabilmeli
    //3.Sepet temizlenebilmelidir
    public class CardManager
    {
        private readonly List<CardItem> _cardItems;//her bir sepet üyesi listeye atıyoruz.
        public CardManager()
        {
            _cardItems = new List<CardItem>();
        }
        public void Add(CardItem cardItem)//eklenecek item'ı listeye(sepete) ekliyoruz
        {
            _cardItems.Add(cardItem);   
        }
        public void Remove(int productId)
        {
            var product = _cardItems.FirstOrDefault(t => t.Product.ProductId == productId);
            _cardItems.Remove(product); 
        }
        public  List<CardItem> CardItems
        {
            get{ return _cardItems; }
        }
        public void Clear()
        {
            _cardItems.Clear();
        }
        public decimal TotalPrice//toplam ürün fiyatı getirecek
        {
            get { return _cardItems.Sum(t => t.Quantity*t.Product.UnitPrice); }
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
