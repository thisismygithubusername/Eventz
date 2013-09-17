using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventStuff
{
    public delegate int TestFinishedHandler(object inst);

    public delegate void TestStartedHandler();

    public class TestDriver
    {
        public event TestFinishedHandler TestFinished;

        public event TestStartedHandler TestStarted;

        public event EventHandler TestRunComplete;

        public object FixtureInstance { get; set; }

        public TestExecutionResult Result { get; set; }

        public Test TestMethod { get; set; }

        public Task<TestExecutionResult> Invoke(Test test)
        {
            return new Task<TestExecutionResult>(()=> SafeInvoke(test));
        }

        private TestExecutionResult SafeInvoke(Test test)
        {
            try
            {
                test.TestMethod.Invoke(FixtureInstance, null);
                Result = TestExecutionResult.CreatePassedResult(test);
                return Result;
            }
            catch (Exception e)
            {
                Result = TestExecutionResult.CreateFailedResult(test, e);
                return Result;
            }
        }
    }
}

