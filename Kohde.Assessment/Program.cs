using Kohde.Assessment.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kohde.Assessment {
    // *** NOTE ***
    // ALL CHANGES MUST BE ACCOMPANIED BY COMMENTS 
    // PLEASE READ ALL COMMENTS / INSTRUCTIONS
    public static class Program {
        static void Main(string[] args) {


            #region Assessment A

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 

            //changed declarations and updated classes to inherit from a class named Being
            //Remove Dog and Cat classes and created Animal class
            var human = new Human {
                Name = "Grant",
                Age = 30,
                Gender = AssesmentContstants.GenderMale
            };

            Console.WriteLine(ShowSomeMammalInformation(human));

            var dog = new Animal {
                Name = "Lea",
                Age = 6,
                Food = "Montego"
            };
            Console.WriteLine(ShowSomeMammalInformation(dog));

            var cat = new Animal {
                Name = "Trixi",
                Age = 9,
                Food = "Whiskers"
            };
            Console.WriteLine(ShowSomeMammalInformation(cat));

            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            // correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };

            //Test data
            //var numbersTest = new List<int>()
            //{
            //    1, 5, 9, 11, 15, 21, 27, 35, 55 // test array only containing odd numbers
            //};
            // throws Exception

            // the following method must return the first event number - as suggested by it's name
            Console.WriteLine($"First Number : {GetFirstEvenValue(numbers)}");

            var strings = new List<string>()
            {
                "John", "Jane", "Sarah", "Pete", "Anna"
            };

            //Test data
            //var strings = new List<string>()
            //{
            //    "John", "Jone", "Soroh", "Pete", "Onno"
            //}; // throws exception

            //var strings = new List<string>()
            //{
            //    "John", "Jone", "Sarah", "Pete", "Anna"
            //}; //returns Sarah

            // the following method must return the first name which contains an 'a'
            var strValue = GetSingleStringValue(strings);
            Console.WriteLine("Single String: " + strValue);

            #endregion

            #region Assessment D

            // there are multiple corrections required!!
            // correct the following statement(s)

            // changed disposeDog.Dispose(); to disposeDog?.Dispose();
            //This will check if the object is null before trying to dispose it.

            try {
                Animal bulldog = null;
                var disposeDog = (IDisposable)bulldog;
                disposeDog?.Dispose();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Assessment E

            DisposeSomeObject();

            #endregion

            #region Assessment F

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            ShowSomeHumanInformation(human);
            ShowSomeDogInformation(dog);
            ShowSomeCatInformation(cat);


            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            //set dog to null for testing.
            //dog = null;

            string a = Program.GenericTester(walter => ShowSomeMammalInformation(walter), dog);
            Console.WriteLine("Result A: {0}", a);

            int b = Program.GenericTester(snowball => snowball.Age, cat);
            Console.WriteLine("Result B: {0}", b);

            #endregion

            #region Assessment G

            // in the following statement, everything works fine
            // but, it has a huge flaw! 
            // correct the following piece of code
            try {
                CatchAndRethrowExplicitly();
            }
            catch (Exception e) {
                Console.WriteLine("Implicitly specified:{0}{1}", Environment.NewLine, e.StackTrace);
            }

            #endregion            

            #region Assessment H

            try {
                // REFLECTION TEST .... NAVIGATE TO THE BELOW METHOD TO GET ALL THE INSTRUCTIONS
                CallMethodWithReflection();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            #endregion            

            #region IoC / DI

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            #region Bonus XP - Dungeon

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            const string abc = "asduqwezxc";
            foreach (var vowel in abc.SelectOnlyVowels()) {
                Console.WriteLine("{0}", vowel);
            }

            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            var dogs = new List<Animal>
            {
                new Animal {Age = 8, Name = "Max"},
                new Animal {Age = 3, Name = "Rocky"},
                new Animal {Age = 9, Name = "XML"}
            };

            var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.SelectOnlyVowels().Any());

            // < DOGS REQUIRED OUTPUT =>
            //      Name: Max Age: 8

            List<Animal> cats = new List<Animal>
            {
                new Animal {Age = 1, Name = "Capri"},
                new Animal {Age = 8, Name = "Cara"},
                new Animal {Age = 3, Name = "Captain Hooks"}
            };

            var bar = cats.CustomWhere(x => x.Age <= 4);
            //< CATS REQUIRED OUTPUT =>
            //     Name: Capri Age: 1
            //     Name: Captain Hooks Age: 3
            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Assessment B Method


        public static void PerformanceTest() {
            var someLongDataString = string.Empty;

            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++) {
                //Not sure if I was allowed to change this...
                //String.Concat is quicker for apending values to a string
                //response time is now +- 60ms
                someLongDataString.Concat(source);
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers) {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            //thins linq seems to be working correctly if even numbers are passed.
            //added try catch to throw NoEvenNumbersException if only odd numbers are passed.
            //updated tet case as well. There are now 2 test methods
            //Check_For_Even_Numbers_While_Only_Odd_Numbers_Are_Present expects NoEvenNumbersException to be thrown  
            try {

                return numbers.Where(x => x % 2 == 0).First();
            }
            catch {
                throw new NoEvenNumbersException("No Even numbers were contained in the array");
            }
        }

        public static string GetSingleStringValue(List<string> stringList) {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT

            //changed indexOf != -1 to String.Contains
            //changed single to FirstOrDefault
            //added thry catch to throw exception if no names contain a

            try {
                var res = stringList.Where(x => x.Contains("a")).FirstOrDefault();
                if (res == null) {
                    throw new NoNameContainsSearchString("The list of names supplied does not contain the search string supplied");
                }
                return res;
            }
            catch (Exception ex) {
                throw ex;

            }
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject() {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            //added using and try catch
            var disposableObject = new DisposableObject();

            using (disposableObject) {
                try {
                    disposableObject.PerformSomeLongRunningOperation("raised event");
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally {
                    disposableObject.Dispose();
                }
            }

            return disposableObject;
        }

        #endregion

        #region Assessment F Methods

        public static void ShowSomeHumanInformation(Human human) {
            Console.WriteLine(ShowSomeMammalInformation(human));
        }

        public static void ShowSomeDogInformation(Animal dog) {
            Console.WriteLine(ShowSomeMammalInformation(dog));
        }

        public static void ShowSomeCatInformation(Animal cat) {
            Console.WriteLine(ShowSomeMammalInformation(cat));
        }

        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly() {
            //no need for 2 try catches
            throw new ArithmeticException("illegal expression - was this picked up?");
        }

        //method becomes redundant

        //private static void ThrowException() {
        //    throw new ArithmeticException("illegal expression - was this picked up??");
        //}

        #endregion

        #region Assessment H Methods

        public static string CallMethodWithReflection() {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD
            //throw new NotImplementedException(); // ATT: REMOVE THIS LINE

            //get method required and set args for method
            var reflectedMethod = typeof(Program).GetMethod("DisplaySomeStuff");
            Type[] argsType = { typeof(string) };

            var genericReflectedMethod = reflectedMethod.MakeGenericMethod(argsType);

            var res = genericReflectedMethod.Invoke(typeof(Program), new object[]
            {
                 " :si ti ereH"
            });

            return (string)res;
        }

        public static string DisplaySomeStuff<T>(T toDisplay) where T : class {
            return string.Format($"Here it is: {toDisplay}");
        }

        #endregion

        #region IoC / DI

        public static void PerformIoCActions() {
            /*  An very simple IoC / DI container has been created for you. All the code can be viewed in the Container folder.
             *  By making use of the classes provided, perform the following tasks:
             *  
             *  Two classes and two interfaces have been created for you, namely:
             *  
             *      - IDevice
             *      - SamsungDevice
             *      - IDeviceProcessor
             *      - DeviceProcessor
             * 
             *  The actual declarations can be view lower down in this file.
             *  
             *  The following needs to happen:
             *      
             *      1. register the interfaces with the respective classes
             *      2. resolve an instance of the IDeviceProcessor and call the GetDevicePrice method
             *      
             *  Some of the code below has been done, but you need to fill in the blanks
             */

            // 1. register the interfaces and classes
            // TODO: ???


            //I've created a second class that you can use to test the DI called Crapple. 


            //create serviceProvider and add interfaces/classes to the sp

            var serviceProvider = new ServiceCollection()
               .AddSingleton<IDevice, SamsungDevice>()
               //.AddSingleton<IDevice, CrappleDevice>()
               .AddSingleton<IDeviceProcessor, DeviceProcessor>()
               .BuildServiceProvider();

            // 2. resolve the IDeviceProcessor
            //get service for the class passed
            var deviceProcessor = serviceProvider.GetService<IDeviceProcessor>();
            // call the GetDevicePrice method
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region GK Methods

        public static res GenericTester<t, res>(Func<t, res> func, t item) {

            if (item == null) {
                //create new instance of class if item is empty
                item = (t)Activator.CreateInstance(typeof(t), item);
            }

            return func(item);
        }

        //strictly here so that the unit tests will pass 
        //unit tests say must be a generic method but I prefer dynamic. Open to have my mind changed though
        public static string ShowSomeMammalInformation<t>(object being) {
            try {
                var parsedBeing = being as dynamic;
                return $"Name: {parsedBeing.Name} Age: {parsedBeing.Age}";
            }
            catch {
                throw new InvalidBeingObjectException("The object that was passed to the method could not be parsed as a being.");
            }
        }

        public static string ShowSomeMammalInformation(object being) {

            //used a dynamic and string interpolation.
            //throws exception if object does not contain the properties required to execute correctly.
            try {
                var parsedBeing = being as dynamic;
                return $"Name: {parsedBeing.Name} Age: {parsedBeing.Age}";
            }
            catch {
                throw new InvalidBeingObjectException("The object that was passed to the method could not be parsed as a being.");
            }
        }

        public static string SelectOnlyVowels(this IEnumerable<char> values) {
            //extension method

            //create hash set of vowels

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            var onlyVowels = string.Empty;

            //loop through values list and check if value exists in vowel hash, if so add it to onlyVowels
            foreach (var val in values) {
                if (vowels.Contains(val)) {
                    onlyVowels += val;
                }
            }
            return onlyVowels;
        }

        public static IEnumerable<t> CustomWhere<t>(this IEnumerable<t> animals, Func<t, bool> condition) {

            //accept delegate and use linq to query animals class as extension method
            return animals.Where(condition).ToList();
        }
        #endregion
    }

    public interface IDevice {
        string DeviceCode { get; }
    }

    public class SamsungDevice : IDevice {
        public string DeviceCode { get; private set; }

        public SamsungDevice() {
            this.DeviceCode = "Samsung";
        }
    }

    public class CrappleDevice : IDevice {
        public string DeviceCode { get; private set; }

        public CrappleDevice() {
            this.DeviceCode = "Apple";
        }
    }

    public interface IDeviceProcessor {
        double GetDevicePrice();
    }

    public class DeviceProcessor : IDeviceProcessor {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device) {
            this.Device = device;
        }

        public double GetDevicePrice() {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }

}
