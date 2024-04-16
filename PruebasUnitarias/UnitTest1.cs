using ToDoList.Services;

namespace PruebasUnitarias
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var firebase = new FirebaseDataService();
            Assert.True(firebase is null);
        }
    }
}