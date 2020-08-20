using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class Dungeon
    {
        [TestMethod]
        public void InvokeLvlAExtensionMethod()
        {


            var methodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });

            Assert.IsTrue(methodInfo != null, "Indicates whether the extension method has not been implemented");

            var result = methodInfo.Invoke(typeof(Program), new object[] { "asduqwezxc" }) as IEnumerable<char>;

            Assert.IsNotNull(result, "Specifies whether the correct values has been returned");

            foreach (var item in result)
            {
                Trace.TraceInformation("-> {0}", item);
            }
        }

        [TestMethod]
        public void InvokeLvlB1ExtensionMethod()
        {
            Trace.TraceInformation("Ignore InvokeLvlB2ExtensionMethod, if this test succeeds!!");

            var methodInfo = typeof (Program).GetMethod("CustomWhere");
            Assert.IsNotNull(methodInfo);
            var generic = methodInfo.MakeGenericMethod(typeof(Animal));
            Assert.IsTrue(methodInfo != null, "Indicates whether the CustomWhere extension method has not been implemented");

            var selectMethodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });
            Assert.IsTrue(selectMethodInfo != null, "Indicates whether the SelectOnlyVowels extension method has not been implemented");

            Func<Animal, bool> expressionB = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

            //Expression<Func<Animal, bool>> expression = x => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] { x.Name }) as IEnumerable<char>).Any();

            IEnumerable<Animal> dogs = new List<Animal>
            {
                new Animal {Age = 8, Name = "Max"},
                new Animal {Age = 3, Name = "Rocky"},
                new Animal {Age = 1, Name = "Cooper"},
                new Animal {Age = 5, Name = "Olivier"},
                new Animal {Age = 11, Name = "Teddy"},
                new Animal {Age = 9, Name = "XML"}
            };

            //Assert.IsTrue(generic.Invoke(typeof(Program), new object[] { dogs, expression }) is IEnumerable<Animal> result && result.Count().Equals(2));
            Assert.IsTrue(generic.Invoke(typeof(Program), new object[] { dogs, expressionB }) is IEnumerable<Animal> result && result.Count().Equals(2));
        }

        [TestMethod]
        public void InvokeLvlB2ExtensionMethod()
        {
            Trace.TraceInformation("If InvokeLvlB1ExtensionMethod fails, this method must succeed, else all possible answers are wrong");

            var methodInfo = typeof(Program).GetMethod("CustomWhere");
            Assert.IsNotNull(methodInfo);
            var generic = methodInfo.MakeGenericMethod(typeof(Human));
            Assert.IsTrue(methodInfo != null, "Indicates whether the CustomWhere extension method has not been implemented");

            var selectMethodInfo = typeof(Program).GetMethod("SelectOnlyVowels", new[] { typeof(IEnumerable<char>) });
            Assert.IsTrue(selectMethodInfo != null, "Indicates whether the SelectOnlyVowels extension method has not been implemented");

            bool ExpressionB(Human x) => x.Age > 6 && (selectMethodInfo.Invoke(typeof(Program), new object[] {x.Name}) as IEnumerable<char>).Any();

            IEnumerable<Human> dogs = new List<Human>
            {
                new Human {Age = 8, Name = "Max"},
                new Human {Age = 3, Name = "Rocky"},
                new Human {Age = 1, Name = "Cooper"},
                new Human {Age = 5, Name = "Olivier"},
                new Human {Age = 11, Name = "Teddy"},
                new Human {Age = 9, Name = "XML"}
            };

            Assert.IsTrue(generic.Invoke(typeof(Program), new object[] { dogs, (Func<Human, bool>) ExpressionB }) is IEnumerable<Human> result && result.Count().Equals(2));
        }
    }
}
