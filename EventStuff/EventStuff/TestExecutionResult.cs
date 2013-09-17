using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStuff
{
    public enum ResultCode
    {
        Passed, 
        Failed, 
        Skipped
    }

    public class TestExecutionResult
    {
        public Test Test; 
        public Exception Exception;
        public ResultCode Code;

        public static TestExecutionResult CreateFailedResult(Test test, Exception e)
        {
            return new TestExecutionResult{ Test = test, Exception = e, Code = ResultCode.Failed };
        }

        public static TestExecutionResult CreatePassedResult(Test test)
        {
            return new TestExecutionResult { Test = test, Code = ResultCode.Passed };
        }

        public static TestExecutionResult CreateSkippedResult(Test test, Exception e = null)
        {
            return new TestExecutionResult {Test = test, Exception = e, Code = ResultCode.Skipped};
        }
    }
}
