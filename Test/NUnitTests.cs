using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Moq;
using Services;

namespace Test
{
    [TestFixture]
    public class NUnitTests
    {
        private IAplikativniServis _servis;
        private Mock<IDnsServerRepozitorijum> _mockRepo;

        [SetUp]
        public void Inicijalizacija()
        {
            _mockRepo = new Mock<IDnsServerRepozitorijum>();
            _servis = new AplikativniServis(_mockRepo.Object);
        }

        #region Bazicni Slucajevi (3)
        [Test]
        [Category("Bazicni")]
        public void DodajRacunar_KadaSeDodaValidanRacunar_ListaSadrziTajRadcunar()
        {
            //Arrange
            var racunar = new Racunar { SerijskiBrojProizvodjaca = "PC-TEST-1" };

            //Act
            _servis.DodajRacunar(racunar);
            var racunari = _servis.VratiSveRacunare();

            //Assert
            Assert.That(racunari.Count(), Is.EqualTo(1));
            Assert.That(racunari.First().SerijskiBrojProizvodjaca, Is.EqualTo("PC-TEST-1"));
        }

        [Test]
        [Category("Bazicni")]
        public void ObrisiRacunar_KadaSeObrisePostojeci_ListaGaViseNeSadrzi()
        {
            // Arrange
            var racunar = new Racunar { SerijskiBrojProizvodjaca = "PC-DELETE-1" };
            _servis.DodajRacunar(racunar);

            // Act
            bool rezultat = _servis.ObrisiRacunar("PC-DELETE-1");
            var racunari = _servis.VratiSveRacunare();

            // Assert
            Assert.That(rezultat, Is.True);
            Assert.That(racunari.Count(), Is.EqualTo(0));
        }

        [Test]
        [Category("Bazicni")]
        public void PokreniSlanjePaketa_Balansirano_PaketiSuRavnomernoRasporedjeni()
        {
            //Arrange
            var ruter1 = new Ruter { SerijskiBrojProizvodjaca = "RT-1" };
            var ruter2 = new Ruter { SerijskiBrojProizvodjaca = "RT-2" };
            _servis.DodajRuter(ruter1);
            _servis.DodajRuter(ruter2);

            var paketi = new List<MrezniPaket> { new MrezniPaket(), new MrezniPaket(), new MrezniPaket(), new MrezniPaket()};
            var rasporedjivac = new BalansiraniRasporedjivac();

            //Act
            _servis.PokreniSlanjePaketa(paketi, rasporedjivac);

            //Assert
            Assert.That(ruter1.BrojPrimljenihPaketa, Is.EqualTo(2));
            Assert.That(ruter2.BrojPrimljenihPaketa, Is.EqualTo(2));
            _mockRepo.Verify(repo => repo.SacuvajEvidenciju(It.IsAny<MrezniPaket>()), Times.Exactly(4));
        }

        #endregion

        #region Granicni Slucajevi (7)
        [Test]
        [Category("Granicni")]
        public void PokreniSlanjePaketa_BezRutera_BacaIzuzetak()
        {
            // Arrange
            var paketi = new List<MrezniPaket> { new MrezniPaket() };
            var rasporedjivac = new BalansiraniRasporedjivac();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _servis.PokreniSlanjePaketa(paketi, rasporedjivac));
        }

        [Test]
        [Category("Granicni")]
        public void PokreniSlanjePaketa_NulaPaketa_NeDesavaSeNista()
        {
            // Arrange
            _servis.DodajRuter(new Ruter { SerijskiBrojProizvodjaca = "RT-1" });
            var paketi = new List<MrezniPaket>(); // Empty list
            var rasporedjivac = new BalansiraniRasporedjivac();

            // Act
            _servis.PokreniSlanjePaketa(paketi, rasporedjivac);
            var ruteri = _servis.VratiSveRutere();

            // Assert
            Assert.That(ruteri.First().BrojPrimljenihPaketa, Is.EqualTo(0));
            _mockRepo.Verify(repo => repo.SacuvajEvidenciju(It.IsAny<MrezniPaket>()), Times.Never);
        }

        [Test]
        [Category("Granicni")]
        public void ObrisiRacunar_NepostojeciSerijskiBroj_VracaFalse()
        {
            // Arrange
            _servis.DodajRacunar(new Racunar { SerijskiBrojProizvodjaca = "PC-1" });

            // Act
            bool rezultat = _servis.ObrisiRacunar("NEPOSTOJECI-SN");

            // Assert
            Assert.That(rezultat, Is.False);
            Assert.That(_servis.VratiSveRacunare().Count(), Is.EqualTo(1));
        }

        [Test]
        [Category("Granicni")]
        public void DodajRacunar_DuplikatSerijskogBroja_NeDodajePonovo()
        {
            // Arrange
            var racunar1 = new Racunar { SerijskiBrojProizvodjaca = "DUPLIKAT-SN" };
            var racunar2 = new Racunar { SerijskiBrojProizvodjaca = "DUPLIKAT-SN" };

            // Act
            _servis.DodajRacunar(racunar1);
            _servis.DodajRacunar(racunar2);

            // Assert
            Assert.That(_servis.VratiSveRacunare().Count(), Is.EqualTo(1));
        }

        [Test]
        [Category("Granicni")]
        public void DodajRacunar_NullObjekat_NeBacaIzuzetak()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => _servis.DodajRacunar(null));
            Assert.That(_servis.VratiSveRacunare().Count(), Is.EqualTo(0));
        }

        [Test]
        [Category("Granicni")]
        public void PokreniSlanjePaketa_Balansirano_NeparanBrojPaketa()
        {
            // Arrange
            var ruter1 = new Ruter { SerijskiBrojProizvodjaca = "RT-1" };
            var ruter2 = new Ruter { SerijskiBrojProizvodjaca = "RT-2" };
            _servis.DodajRuter(ruter1);
            _servis.DodajRuter(ruter2);

            var paketi = new List<MrezniPaket> { new MrezniPaket(), new MrezniPaket(), new MrezniPaket() }; // 3 packets
            var rasporedjivac = new BalansiraniRasporedjivac();

            // Act
            _servis.PokreniSlanjePaketa(paketi, rasporedjivac);

            // Assert
            Assert.That(ruter1.BrojPrimljenihPaketa, Is.EqualTo(2));
            Assert.That(ruter2.BrojPrimljenihPaketa, Is.EqualTo(1));
        }

        [Test]
        [Category("Granični")]
        public void PokreniSlanjePaketa_SamoJedanRuter_SviPaketiIdunaNjega()
        {
            // Arrange
            var ruter1 = new Ruter { SerijskiBrojProizvodjaca = "RT-1" };
            _servis.DodajRuter(ruter1);

            var paketi = new List<MrezniPaket> { new MrezniPaket(), new MrezniPaket(), new MrezniPaket() };
            var rasporedjivac = new BalansiraniRasporedjivac();

            // Act
            _servis.PokreniSlanjePaketa(paketi, rasporedjivac);

            // Assert
            Assert.That(ruter1.BrojPrimljenihPaketa, Is.EqualTo(3));
        }

        #endregion

        #region Proizvoljni Slucajevi (5)
        [Test]
        [Category("Proizvoljni")]
        public void ProizvoljniTest_NasumicnoSlanje_UkupanBrojPaketaJeTacan()
        {
            // Arrange
            var random = new Random();
            int brojRutera = random.Next(2, 10);
            int brojPaketa = random.Next(50, 200);

            for (int i = 0; i < brojRutera; i++)
            {
                _servis.DodajRuter(new Ruter { SerijskiBrojProizvodjaca = $"RT-RAND-{i}" });
            }

            var paketi = new List<MrezniPaket>();
            for (int i = 0; i < brojPaketa; i++)
            {
                paketi.Add(new MrezniPaket());
            }

            var rasporedjivac = new NasumicniRasporedjivac();

            // Act
            _servis.PokreniSlanjePaketa(paketi, rasporedjivac);
            var ruteri = _servis.VratiSveRutere();
            int ukupanBrojPrimljenihPaketa = ruteri.Sum(r => r.BrojPrimljenihPaketa);

            // Assert
            Assert.That(ukupanBrojPrimljenihPaketa, Is.EqualTo(brojPaketa));
            _mockRepo.Verify(repo => repo.SacuvajEvidenciju(It.IsAny<MrezniPaket>()), Times.Exactly(brojPaketa));
        }

        [Test]
        [Category("Proizvoljni")]
        public void ProizvoljniTest_BalansiranoSlanje_RaspodelaJeStoJednakija()
        {
            // Arrange
            var ruter1 = new Ruter { SerijskiBrojProizvodjaca = "RT-1" };
            var ruter2 = new Ruter { SerijskiBrojProizvodjaca = "RT-2" };
            var ruter3 = new Ruter { SerijskiBrojProizvodjaca = "RT-3" };
            _servis.DodajRuter(ruter1);
            _servis.DodajRuter(ruter2);
            _servis.DodajRuter(ruter3);

            var paketi = new List<MrezniPaket>();
            for (int i = 0; i < 100; i++) paketi.Add(new MrezniPaket()); // 100 packets

            var rasporedjivac = new BalansiraniRasporedjivac();

            // Act
            _servis.PokreniSlanjePaketa(paketi, rasporedjivac);

            // Assert
            Assert.That(ruter1.BrojPrimljenihPaketa, Is.EqualTo(34)); // First one gets the remainder
            Assert.That(ruter2.BrojPrimljenihPaketa, Is.EqualTo(33));
            Assert.That(ruter3.BrojPrimljenihPaketa, Is.EqualTo(33));
        }

        [Test]
        [Category("Proizvoljni")]
        public void ProizvoljniTest_DodavanjeIViseStrukoBrisanje()
        {
            // Arrange
            _servis.DodajRacunar(new Racunar { SerijskiBrojProizvodjaca = "PC-1" });
            _servis.DodajRacunar(new Racunar { SerijskiBrojProizvodjaca = "PC-2" });
            _servis.DodajRacunar(new Racunar { SerijskiBrojProizvodjaca = "PC-3" });
            _servis.DodajRacunar(new Racunar { SerijskiBrojProizvodjaca = "PC-4" });

            // Act
            _servis.ObrisiRacunar("PC-2");
            _servis.ObrisiRacunar("PC-4");
            _servis.ObrisiRacunar("NEPOSTOJECI"); // Attempt to delete non-existent

            // Assert
            var racunari = _servis.VratiSveRacunare();
            Assert.That(racunari.Count(), Is.EqualTo(2));
            Assert.That(racunari.Any(r => r.SerijskiBrojProizvodjaca == "PC-1"), Is.True);
            Assert.That(racunari.Any(r => r.SerijskiBrojProizvodjaca == "PC-3"), Is.True);
        }

        [Test]
        [Category("Proizvoljni")]
        public void ProizvoljniTest_ViseStrukihSlanjaPaketa()
        {
            // Arrange
            var ruter = new Ruter { SerijskiBrojProizvodjaca = "RT-1" };
            _servis.DodajRuter(ruter);
            var rasporedjivac = new BalansiraniRasporedjivac();

            var paketi1 = new List<MrezniPaket> { new MrezniPaket(), new MrezniPaket() };
            var paketi2 = new List<MrezniPaket> { new MrezniPaket(), new MrezniPaket(), new MrezniPaket() };

            // Act
            _servis.PokreniSlanjePaketa(paketi1, rasporedjivac);
            _servis.PokreniSlanjePaketa(paketi2, rasporedjivac);

            // Assert
            Assert.That(ruter.BrojPrimljenihPaketa, Is.EqualTo(5));
            _mockRepo.Verify(repo => repo.SacuvajEvidenciju(It.IsAny<MrezniPaket>()), Times.Exactly(5));
        }

        [Test]
        [Category("Proizvoljni")]
        public void ProizvoljniTest_ResetovanjeStanjaIzmedjuTestova()
        {
            // This test verifies that [SetUp] works correctly.
            // If previous tests have not affected this one, then everything is fine.

            // Arrange & Act
            var racunari = _servis.VratiSveRacunare();
            var ruteri = _servis.VratiSveRutere();

            // Assert
            Assert.That(racunari.Count(), Is.EqualTo(0));
            Assert.That(ruteri.Count(), Is.EqualTo(0));
            _mockRepo.Verify(repo => repo.SacuvajEvidenciju(It.IsAny<MrezniPaket>()), Times.Never);
        }


        #endregion
    }
}
