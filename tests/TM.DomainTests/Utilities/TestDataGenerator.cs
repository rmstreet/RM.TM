
namespace TM.DomainTests.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using ModelsGenarator;

    public class TestDataGenerator : IEnumerable<object[]>
    {
        public TestDataGenerator(Datatype dataType)
        {
            _dataType = dataType;
        }

        private Datatype _dataType { get; set; }

        public static IEnumerable<object[]> GetTeamsValid()
        {
            yield return new object[] { new TeamsTestGenerator(2) };
            yield return new object[] { new TeamsTestGenerator(4) };
            yield return new object[] { new TeamsTestGenerator(8) };
            yield return new object[] { new TeamsTestGenerator(16) };        
        }
        
        public IEnumerator<object[]> GetEnumerator()
        {
            switch(_dataType)
            {
                case Datatype.GetTeamsValid:
                    return (IEnumerator<object[]>)GetTeamsValid();
                default:
                    throw new Exception($"DataType({_dataType}) invalid.");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public enum Datatype
        {
            GetTeamsValid = 1
        }
    }
}
