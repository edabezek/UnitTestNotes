using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Tests
{
    [TestClass]
    public class StringHelperTests
    {
        //girilen ifadenin başındaki ve sonundaki fazla boşluklar silinmelidir
        [TestMethod]
        public void girilen_ifadenin_basindaki_ve_sonundaki_fazla_bosluklar_silinmelidir()
        {
            //Arrange
            var ifade = "   Salih Demiroğ  ";
            var beklenen = "Salih Demiroğ";

            //Act
            var gerceklesen = StringHelper.FazlaBosluklariSil(ifade);

            //Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }
        //girilen ifadenin içindeki fazla bosluklar silinmelidir
        [TestMethod]
        public void girilen_ifadenin_icindeki_fazla_bosluklar_silinmelidir()
        {
            //Arrange
            var ifade = "Salih Demiroğ  Engin   Demiroğ      Ahmet  Sait              Duran";
            var beklenen = "Salih Demiroğ Engin Demiroğ Ahmet Sait Duran";

            //Act
            var gerceklesen = StringHelper.FazlaBosluklariSil(ifade);

            //Assert
            Assert.AreEqual(beklenen, gerceklesen);
        }
    }
}
