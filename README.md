# :seedling: Test Çeşitleri : 

**1. Unit Test :** Metot testidir. 

**2. Integration Test :** Uygulamadaki modüllerin birbirleriyle nasıl davranış sergilediklerinin kontrol edildiği test türüdür.

**3. End to End Test :** Bir uygulamanın baştan sona kadar nasıl davranış sergileyeceğinin test edilmesidir.

**4. UI Test :** Kullanıcı arayüzünün test edilmesidir.


## Unit Test 3 aşamadan oluşur :

**Arrange :** Hazırlıklarımızı yaptığımız kısım,değişken tanımları 

**Act :** Fonksiyonları çağırdığımız kısım

**Assert :** Testimizin geçerli olup olmadığını belirleyen kısım 


*:+1:Amacımız uygulamayı çalıştırmadan fonksiyonun doğruluğunu test etmek*

## Testing Lifecyle(Initialize and cleanup) :

-Test Level

-Class Level

-Assembly Level


**Test Level için ShoppingCard uygulaması :**

	-Her test metodundan önce ve sonra işlemler yapabiliriz,bunlar için TestInitialize ve TestCleanUp kullanabiliriz.
	-Product ,ürünleri 
	-CardItem,sepete ekleyeceğimiz sınıfı temsil eder
	-Sepete ,ekleme ,silme işlemlerini gerçekleştirecek sınıf CardManager
	-Sepet için bilgileri session'da tutacağız, db bağlantısı olmayacak
	-TestInitialize , tekrar eden metodların olmaması için, her test edilecek metottan önce çalışacak bir genel metod oluşturmak demek.Her test 
	metodunun ortak çalışan kodlarını bu metoda yazarız.CardTests için yazdığımız metotları CardTestsTestLevel'de yaptık.
	-Her testten önce TestInitialize çalışacak ve sepete bir tane ürün ekleyecek.
	-TestCleanup ,her test metodundan sonra çalışacak olan metot


**Class Level için ShoppingCardClassLevel uygulaması :**

	-Önce TestInitialize çalışır,sonra sırasıyla test metotları,son olarak class cleanup metodu çalışır.
	-ClassInitialize ve ClassCleanup statik olmak zorunda,herhangi bir değer return edemezler.Aynı zamanda ClassInitialize TestContext tipinde
	bir parametre almalıdır.
	-ClassInitialize ve ClassCleanup her test class'da birer tane olur.

**Assembly Level için AssemblyLevel uygulaması :**

	-Bütün unit test projesi boyunca bir defalık ilk olacak şekilde AssemblyInitialize çalışır,son olacak şekilde de AssemblyCleanup çalışır.
	-AssemblyInitialize ve AssemblyCleanup projede 1 tane olur, hangi class'a yazdığımız önemli değildir.

**Expected Exception**

	-Testlerin geçebilmesi için uygulama içinde olabilecek hataları bilmesi gerekiyor.
	-Hata oluşmalı ama test'ten geçmiyor,bu durumda kullanırız.Metoda beklediğimiz hata tipini veririz.Burada birebir tiplere bakar , başka ex 
	tiplerini de geçerli kılmak için AllowDerivedTypes=true eklenir.

**Asserting** 

	Assert : Compare two values,many methods with several overloads
	CollectionAssert : Compare two values,check items in collection
	StringAssert : Compare strings

**TestContext** 

	-Uygulama içerisinde,çalışma anında bilgi veren nensedir.
	-Testin adını,birimini almak ,
	-Web servisi test ettiğimizde ,web servisle ilgili url bilgileri,durumu bilgisini almak 
	-Web forms uygulamasını test ettiğimizde page nesnesini almak,
	-Data-driven test yönteminde her bir veriyi elde etmek için kullanılır.

## Data-Driven Unit Test

	Microsot'un test framework'ü ile veri temelli birim testleri oluşurabiliyoruz.
  
	-Veri temelli birim testleri , kullanılan kaynaktaki her satır için birim testinin otomatik çalıştırılması esasına dayalıdır.
	-Kaynak olarak veritabanı,excel, vs olabilir
	-Aynı birim testini dinamik değerlerle test etmek için kullanılır.
	-Diğer kullanımı, veritabanına veri import etmek istediğimizde kullanırız.Örneğin excel dosyasını veritabanına import etmemiz gerekiyor diyelim.
	Fakat excel'deki veriler bizim istediğimiz formata uygun mu (email formatı vs) , bunu veritabanına import etmeden kontrol etmek zor bu yüzden
	bizim iş kurallarımıza göre test etmeliyiz.
	-Burada her satırdaki veriyi yakalamak için TestContext nesnesini kullanırız.

**DataDrivenUnitTest Proje Detayları**

	-Kaynak olarak elimizde xml veri seti var,bunları database'e kaydetmeden önce iş kuralına uygunluğunu test edeceğiz.
	-Configürasyon olarak kod yazacağız.
	-Businnes layer'da Kullanıcı için kurallar yazdık.
	-xml dosyasını bin/debug altına gelmesi için properties'den kopyalanabilir olmasını değiştirdik.
	-Kaynak olarak veritabanını kullanacağız,configürasyon için xml dosyası tercih edeceğiz.
	-Burada veriler testin geçip geçmeyeceğine karar veren değerler olacak.
	-Businnes Layer'da, İslemManager'da bir formülümüz var bunun çalışıp çalışmadığını kontrol edeceğiz.
	-SQl'de Demo db ve Sayılar tablosu oluşturduk.(kolonlar : x,y,beklenen)

# Test Attributes

	Owner : Test metot sahibini belirler
	TestCategory : Testleri bir gruba göre gruplamak için
	Priorty : Öncelik belirterek gruplayabiliriz
	TestProperty : Spesifik bir duruma göre gruplamak için
	Ignore : Testi pas geçmek için
	TimeOut : Teste timeout süresi vermek için kullanılır,milisaniye ile verilir
	Description : Açıklama

**Ordered Test** 

	Bazı durumlarda testlerimizi belli bir sıraya göre çalıştırmak isteyebiliriz,bu durumlarda kullanılır.
	Versiyon geçişi için,
	https://stackoverflow.com/questions/52714838/unable-to-find-add-ordered-test-item-to-my-project-in-visual-studio-2017-enterpr


# Test First Development

	Kırmızı : Hata verecek bir test yazılır
	Yeşil : Testi geçecek en basit kod yazılır
	Refactor : Test'i geçebilecek kod yazılır.
  
  
# Conclusion

	Karşılaşabileceğimiz hatalardan biri unit test'in integration test olması.En büyük nedeni yanlış yazılım tasarımı kullanılması.
	Eğer geliştirdiğimiz uygulama Solid'e uygunsa nesneldir,testlerimizi uygulamamız kolay olur.
	Mock, test konseptinde sahte (fake) object üretmektir. Faydası Unit Test’in temel kurallarından olan Test In Isolation
	prensibini karmaşık yapılara uygulayabilmemizdir.Bu sayede testi izole edip birimde çalışma imkanı tanır.
