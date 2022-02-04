using System.Collections.Generic;
using NUnit.Framework;

namespace OperationResult.Tests;

internal class OperationResultTests
{
    #region test cases
    public static IEnumerable<TestCaseData> GenericSuccessOperationResultTestCases
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
    
    public static IEnumerable<TestCaseData> GenericFailOperationResultTestCases
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
    #endregion
    
    [Test]
    [TestCase("test message", true)]
    [TestCase("", true)]
    [TestCase(null, true)]
    public void SimpleOperationResult_IsSuccess(string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult.Success(expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);
    }
    
    [Test]
    [TestCase("test message", false)]
    [TestCase("", false)]
    [TestCase(null, false)]
    public void SimpleOperationResult_IsFail(string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult.Fail(expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);
    }

    
    
    [TestCaseSource(nameof(GenericSuccessOperationResultTestCases))]
    public void GenericOperationResult_IsSuccess(TypeForTest? objectForTest, string expectedMessage, bool expectedIsValid)
    {
        var actual = OperationResult<TypeForTest>.Success(objectForTest, expectedMessage);
        
        Assert.AreEqual(expectedMessage, actual.Message);
        Assert.AreEqual(expectedIsValid, actual.IsSuccess);

        if (objectForTest is null && actual.Data is null)
        {
            Assert.IsTrue(true);
            return;
        }
        
        Assert.IsTrue(actual.Data?.Equals(objectForTest));
    }
    
    [TestCaseSource(nameof(GenericFailOperationResultTestCases))]
    public void GenericOperationResult_IsFail(TypeForTest? objectForTest, string expectedMessage, bool expectedIsValid)
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
}