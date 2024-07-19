using Task9.UserInput;
using Task9.UserInput.CommandParsing;

namespace UserInputTest
{
    public class ParsingResultTest
    {
        private CommandParser _parser;
        public ParsingResultTest() 
        { 
            _parser = new CommandParser();
        }
        [Fact]
        public void TryParse_WhenInputIs_Null() 
        {
            //Arrange            
            string input = "";

            //Act
           var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
            Assert.Equal("Ќе получилось распознать команду. ¬ведите строку в нужном формате.", result.Message);
        }

        [Fact]
        public void Test_LenghtOfInput_When_FirstWordGet()
        {
            //Arrange
            string input = "get";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
            Assert.Equal(" оманда get состоит из 3 слов, введите команду в нужном формате.", result.Message);
        }

        [Fact]
        public void Test_SecondWord_When_FirstWordGet()
        {
            //Arrange
            string input = "get zalupa Ranger";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
            Assert.Equal("Ќе получилось распознать команду get (введенное второе слово). ¬ведите команду в нужном формате.", result.Message);
        }

        [Fact]
        public void Test_ThirdWord_When_FirstWordGet_And_SecondWordItems()
        {
            //Arrange
            string input = "get items zalupa";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
            Assert.Equal("ѕерсонажа (третье слово) не существует. ”кажите в команде персонажа из начального списка.", result.Message);
        }

        [Fact]
        public void Test_WhenInputGetItems() 
        {
            //Arrange
            string input = "get items Bard";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.GetItems, result.Command);
        }

        [Fact]
        public void Test_WhenInputGetDescription()
        {
            //Arrange
            string input = "get description Druid";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.GetDescription, result.Command);
        }

        [Fact]
        public void Test_LenghtOfInput_When_FirstWordShow()
        {
            //Arrange
            string input = "show";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_SecondWord_When_FirstWordShow()
        {
            //Arrange
            string input = "show zalupa";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_WhenInputShowInfo()
        {
            //Arrange
            _parser.Parse("start Ranger");
            string input = "show info";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.ShowInfo, result.Command);
        }

        [Fact]
        public void Test_LenghtOfInput_When_FirstWordStart()
        {
            //Arrange
            string input = "start";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_SecondWord_When_FirstWordStart()
        {
            //Arrange
            string input = "start zalupa";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Start_Word_Reentry_Test()
        {
            //Arrange
            _parser.Parse("start Ranger");
            string input = "start Bard";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
            Assert.Equal(" оманду start можно использовать один раз за запуск. ¬ведите другую команду.", result.Message);
        }

        [Fact]
        public void Test_WhenInputStart()
        {
            //Arrange
            string input = "start Bard";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.Start, result.Command);
        }

        [Fact]
        public void Test_LenghtOfInput_When_FirstWordAdd()
        {
            //Arrange
            string input = "add";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_SecondWord_When_FirstWordAdd()
        {
            //Arrange
            string input = "add zalupa";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_ThirdAndFourthWord_When_FirstWordAdd_And_SecondWordAbility()
        {
            //Arrange
            string input = "add ability тольк0 букв61 13 Fire";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_FivethWord_When_FirstWordAdd_And_SecondWordAbility()
        {
            //Arrange
            string input = "add ability п€тое слово число Air";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_SixthWord_When_FirstWordAdd_And_SecondWordAbility()
        {
            //Arrange
            string input = "add ability zalupa polnaya 13 стихи€";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.InvalidInput, result.Command);
        }

        [Fact]
        public void Test_WhenInputAddAbility()
        {
            //Arrange
            _parser.Parse("start Cleric");
            string input = "add ability arti artorius 4 Earth";

            //Act
            var result = _parser.Parse(input);

            //Assert
            Assert.Equal(Command.AddAbility, result.Command);
        }
    }
}