using AMcom.Teste.DAL;
using FluentAssertions;
using Xunit;

namespace AMcom.Teste.Service.Tests.Entidades
{
    public class EntidadesTest
    {
        Ubs ubs = null;

        #region Identity Field

        [Fact]
        public void IdentityFieldCanNotBeNegativeNumber()
        {
            //Arrange
            var id = -1;
            ubs = new Ubs();
            //Act
            ubs.SetId(id);
            //Assert
            ubs.Id.Should().Be(0);
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void IdentityFieldCanNotBeZero()
        {
            //Arrange
            var id = 0;
            ubs = new Ubs();
            //Act
            ubs.SetId(id);
            //Assert
            ubs.Id.Should().Be(0);
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void IdentityFieldMustBeGreatThanZero()
        {
            //Arrange
            var id = 1;
            ubs = new Ubs();
            //Act
            ubs.SetId(id);
            //Assert
            ubs.Id.Should().Be(id);
            ubs.Invalid.Should().BeFalse();
            ubs.Valid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(0);
        }

        #endregion

        #region Coordinates Fields

        [Fact]
        public void LatitudeFieldMustAcceptValidEntries()
        {
            //Arrange
            var latitude = "49.167";
            ubs = new Ubs();
            //Act
            ubs.SetLatitude(latitude);
            //Assert
            ubs.Latitude.Should().Be(latitude);
            ubs.Valid.Should().BeTrue();
            ubs.Invalid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(0);
        }

        [Fact]
        public void LatitudeFieldShouldNotAcceptInvalidEntries()
        {
            //Arrange
            var latitude = "EASD49.167AS";
            ubs = new Ubs();
            //Act
            ubs.SetLatitude(latitude);
            //Assert
            ubs.Latitude.Should().BeNullOrWhiteSpace();
            ubs.Valid.Should().BeFalse();
            ubs.Invalid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void LongetudeFieldMustAcceptValidEntries()
        {
            //Arrange
            var longitude = "-49.167";
            ubs = new Ubs();
            //Act
            ubs.SetLongitude(longitude);
            //Assert
            ubs.Longitude.Should().Be(longitude);
            ubs.Valid.Should().BeTrue();
            ubs.Invalid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(0);
        }

        [Fact]
        public void LongetudeFieldShouldNotAcceptInvalidEntries()
        {
            //Arrange
            var longitude = "EASD49.167AS";
            ubs = new Ubs();
            //Act
            ubs.SetLongitude(longitude);
            //Assert
            ubs.Longitude.Should().BeNullOrWhiteSpace();
            ubs.Valid.Should().BeFalse();
            ubs.Invalid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(1);
        }

        #endregion

        #region Name Field

        [Fact]
        public void FieldNameCantNotBeNull()
        {
            ubs = new Ubs();
            ubs.SetNome(null);
            ubs.Nome.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void FieldNameCantNotBeEmpty()
        {
            ubs = new Ubs();
            ubs.SetNome(string.Empty);
            ubs.Nome.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void FieldNameCantNotBeWhiteSpace()
        {
            ubs = new Ubs();
            ubs.SetNome("     ");
            ubs.Nome.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void FieldNameHasMinimumLenghtRequired()
        {
            ubs = new Ubs();
            ubs.SetNome("A");
            ubs.Nome.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void FieldNameHasMaximumLenghtRequired()
        {
            var nome = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                       "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                       "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            ubs = new Ubs();
            ubs.SetNome(nome);
            ubs.Nome.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void FieldNameIsValidated()
        {
            ubs = new Ubs();
            ubs.SetNome("Alexandre Dórea");
            ubs.Nome.Should().Be("Alexandre Dórea");
            ubs.Invalid.Should().BeFalse();
            ubs.Valid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(0);
        }

        #endregion

        #region Street Field

        [Fact]
        public void StreetFieldCanNotBeNull()
        {
            ubs = new Ubs();
            ubs.SetEndereco(null);
            ubs.Endereco.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void StreetFieldCanNotBeEmpty()
        {
            ubs = new Ubs();
            ubs.SetEndereco(string.Empty);
            ubs.Endereco.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void StreetFieldCanNotBeWhiteSpace()
        {
            ubs = new Ubs();
            ubs.SetEndereco("     ");
            ubs.Endereco.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void StreetFieldHasMininumLenghtOfThreeCharacters()
        {
            ubs = new Ubs();
            ubs.SetEndereco("V.");
            ubs.Endereco.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void StreetFieldHasMaximumLenghtTwoHundredAndFiftyFive()
        {
            var endereco = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                           "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            ubs = new Ubs();
            ubs.SetEndereco(endereco);
            ubs.Endereco.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void StreetFieldIsValidated()
        {
            ubs = new Ubs();
            ubs.SetEndereco("Velha Central");
            ubs.Endereco.Should().Be("Velha Central");
            ubs.Invalid.Should().BeFalse();
            ubs.Valid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(0);
        }

        #endregion

        #region Neighborhood Field

        [Fact]
        public void NeighborhoodFieldCanNotBeNull()
        {
            ubs = new Ubs();
            ubs.SetBairro(null);
            ubs.Bairro.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void NeighborhoodFieldCanNotBeEmpty()
        {
            ubs = new Ubs();
            ubs.SetBairro(string.Empty);
            ubs.Bairro.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void NeighborhoodFieldCanNotBeWhiteSpace()
        {
            ubs = new Ubs();
            ubs.SetBairro("     ");
            ubs.Bairro.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void NeighborhoodFieldHasMininumLenghtOfThreeCharacters()
        {
            ubs = new Ubs();
            ubs.SetBairro("V.");
            ubs.Bairro.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void NeighborhoodFieldHasMaximumLenghtTwentyFive()
        {
            var bairro = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            ubs = new Ubs();
            ubs.SetBairro(bairro);
            ubs.Bairro.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void NeighborhoodFieldIsValidated()
        {
            ubs = new Ubs();
            ubs.SetBairro("Velha Central");
            ubs.Bairro.Should().Be("Velha Central");
            ubs.Invalid.Should().BeFalse();
            ubs.Valid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(0);
        }

        #endregion

        #region City Field

        [Fact]
        public void CityFieldCanNotBeNull()
        {
            ubs = new Ubs();
            ubs.SetCidade(null);
            ubs.Cidade.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void CityFieldCanNotBeEmpty()
        {
            ubs = new Ubs();
            ubs.SetCidade(string.Empty);
            ubs.Cidade.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void CityFieldCanNotBeWhiteSpace()
        {
            ubs = new Ubs();
            ubs.SetCidade("     ");
            ubs.Cidade.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void CityFieldHasMininumLenghtOfThreeCharacters()
        {
            ubs = new Ubs();
            ubs.SetCidade("R.");
            ubs.Cidade.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void CityFieldHasMaximumLenghtTwentyFive()
        {
            ubs = new Ubs();
            ubs.SetCidade("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            ubs.Cidade.Should().BeNullOrWhiteSpace();
            ubs.Invalid.Should().BeTrue();
            ubs.Valid.Should().BeFalse();
            ubs.Notifications.Count.Should().Be(1);
        }

        [Fact]
        public void CityFieldIsValidated()
        {
            ubs = new Ubs();
            ubs.SetCidade("Blumenau");
            ubs.Cidade.Should().Be("Blumenau");
            ubs.Invalid.Should().BeFalse();
            ubs.Valid.Should().BeTrue();
            ubs.Notifications.Count.Should().Be(0);
        }

        #endregion        
    }
}
