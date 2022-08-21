namespace GartnerAppTest
{
    public class StartProgramShould
    {
        private StartProgram startProgram;

        [Test]
        public void InitializedAsExpected()
        {
            string[] args = {"Arg1", "Arg2", "Arg3"};

            Assert.DoesNotThrow(() => startProgram = new StartProgram(args));
        }

        [Test]
        public void RaiseExWhenArgsAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => startProgram = new StartProgram(null));
        }
        
        [Test]
        public void RaiseExWhenArgsAreEmpty()
        {
            var ex = Assert.Throws<ArgumentException>(() => startProgram = new StartProgram(new string[0]));

            Assert.IsTrue(ex.Message.Contains("Error: Arguments are empty"));
        }

        [Test]
        public void RaiseExWhenArgsIsDefferentFrom3()
        {
            string[] args = {"Arg1"};
            var ex = Assert.Throws<ArgumentException>(() => startProgram = new StartProgram(args));

            Assert.IsTrue(ex.Message.Contains(string.Format("Error: Arguments size must be 3. Current size: {0}",
                                                    args.Length)));
        }
    }
}