using System.Collections.Generic;
using NUnit.Framework;

namespace OperationResultLibrary.Tests;

internal class OperationResultTests
{
    #region test cases
    public static IEnumerable<TestCaseData> SuccessTestCasesWithClassType
    {
        get
        {
            yield return new TestCaseData(new TypeForTest(1), "test message", true);
            yield return new TestCaseData(new TypeForTest(1), "", true);
            yield return new TestCaseData(new TypeForTest(1), null, true);
            yield return new TestCaseData(null, "test message", true);
            yield return new TestCaseData(null, "", true);
            yield return new TestCaseData(null, null, true);
        }
    }
    
    public static IEnumerable<TestCaseData> SuccessTestCasesWithStringType
    {
        get
        {
            yield return new TestCaseData("accepted", "test message", true);
            yield return new TestCaseData("rejected", "", true);
            yield return new TestCaseData("waiting", null, true);
            yield return new TestCaseData("", "test message", true);
            yield return new TestCaseData(string.Empty, "", true);
            yield return new TestCaseData(null, null, true);
        }
    }
    
    public static IEnumerable<TestCaseData> SuccessTestCasesWithIntType
    {
        get
        {
            yield return new TestCaseData(5, "test message", true);
            yield return new TestCaseData(4, "", true);
            yield return new TestCaseData(3, null, true);
            yield return new TestCaseData(2, "test message", true);
            yield return new TestCaseData(1, "", true);
            yield return new TestCaseData(0, null, true);
        }
    }
    
    public static IEnumerable<TestCaseData> FailTestCasesWithClassType
    {
        get
        {
            yield return new TestCaseData(new TypeForTest(1), "test message", false);
            yield return new TestCaseData(new TypeForTest(1), "", false);
            yield return new TestCaseData(new TypeForTest(1), null, false);
            yield return new TestCaseData(null, "test message", false);
            yield return new TestCaseData(null, "", false);
            yield return new TestCaseData(null, null, false);
        }
    }
    
    public static IEnumerable<TestCaseData> FailTestCasesWithStringType
    {
        get
        {
            yield return new TestCaseData("accepted", "test message", false);
            yield return new TestCaseData("rejected", "", false);
            yield return new TestCaseData("waiting", null, false);
            yield return new TestCaseData("", "test message", false);
            yield return new TestCaseData(string.Empty, "", false);
            yield return new TestCaseData(null, null, false);
        }
    }
    
    public static IEnumerable<TestCaseData> FailTestCasesWithIntType
    {
        get
        {
            yield return new TestCaseData(5, "test message", false);
            yield return new TestCaseData(4, "", false);
            yield return new TestCaseData(3, null, false);
            yield return new TestCaseData(2, "test message", false);
            yield return new TestCaseData(1, "", false);
            yield return new TestCaseData(0, null, false);
        }
    }
    #endregion
    
    [TestCaseSource(nameof(SuccessTestCasesWithClassType))]
    public void ClassTypeResult_IsSuccess(TypeForTest? value, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<TypeForTest>.Success(value, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        if (value is null && actual.Data is null)
        {
            Assert.IsTrue(true);
            return;
        }
        
        Assert.IsTrue(actual.Data?.Equals(value));
    }
    
    [TestCaseSource(nameof(SuccessTestCasesWithStringType))]
    public void StringTypeResult_IsSuccess(string value, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<string>.Success(value, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        if (string.IsNullOrEmpty(value) && actual.Data is null)
        {
            Assert.IsTrue(true);
            return;
        }
        
        Assert.IsTrue(actual.Data?.Equals(value));
    }
    
    [TestCaseSource(nameof(SuccessTestCasesWithIntType))]
    public void IntTypeResult_IsSuccess(int value, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<string>.Success(value, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        Assert.IsTrue(actual.Data.Equals(value));
    }
    
    [TestCaseSource(nameof(FailTestCasesWithClassType))]
    public void ClassType_IsFail(TypeForTest? objectForTest, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<TypeForTest>.Fail(objectForTest, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        if (objectForTest is null && actual.Data is null)
        {
            Assert.IsTrue(true);
            return;
        }
        
        Assert.IsTrue(actual.Data?.Equals(objectForTest));
    }
    
    [TestCaseSource(nameof(FailTestCasesWithStringType))]
    public void StringType_IsFail(string value, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<TypeForTest>.Fail(value, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        if (string.IsNullOrEmpty(value) && actual.Data is null)
        {
            Assert.IsTrue(true);
            return;
        }
        
        Assert.IsTrue(actual.Data?.Equals(value));
    }
    
    [TestCaseSource(nameof(FailTestCasesWithIntType))]
    public void IntType_IsFail(int value, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<TypeForTest>.Fail(value, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        Assert.IsTrue(actual.Data.Equals(value));
    }
}