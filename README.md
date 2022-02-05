# OperationResult

[![build](https://github.com/sterlyukin/OperationResult/actions/workflows/build.yml/badge.svg)](https://github.com/sterlyukin/OperationResult/actions/workflows/build.yml)
[![test](https://github.com/sterlyukin/OperationResult/actions/workflows/test.yml/badge.svg)](https://github.com/sterlyukin/OperationResult/actions/workflows/test.yml)
[![latest version](https://img.shields.io/nuget/v/Sterlyukin.OperationResult)](https://www.nuget.org/packages/Sterlyukin.OperationResult)

This is repository for `OperationResult` opensource library.
`OperationResult` and `OperationResult<TType>` is a type that can be used in validation, performing various actions.

Allows you to return from the method:
- a sign of success of execution;
- data of any type;
- validation message.

## Installation

```
dotnet add package Sterlyukin.OperationResult --version 1.0.1
```

## Usage

```csharp

using OperationResultLibrary;

var service = new Service();
var successServiceResult = service.GetSuccess();
Console.WriteLine(successServiceResult.IsSuccess); //true
Console.WriteLine(successServiceResult.Message); //success message

var failServiceResult = service.GetFail();
Console.WriteLine(failServiceResult.IsSuccess); //fail
Console.WriteLine(failServiceResult.Message); //fail message

var successServiceResultWithData = service.GetSuccessWithData();
Console.WriteLine(successServiceResultWithData.IsSuccess); //true
Console.WriteLine(successServiceResultWithData.Message); //success message with data
Console.WriteLine(successServiceResultWithData.Data); //4

var failServiceResultWithData = service.GetFailWithData();
Console.WriteLine(failServiceResultWithData.IsSuccess); //fail
Console.WriteLine(failServiceResultWithData.Message); //fail message with data
Console.WriteLine(failServiceResultWithData.Data); //3

public class Service
{
    public OperationResult GetSuccess()
    {
        return OperationResult.Success("success message");
    }

    public OperationResult GetFail()
    {
        return OperationResult.Fail("fail message");
    }

    public OperationResult<int> GetSuccessWithData()
    {
        return OperationResult<int>.Success(4, "success message with data");
    }

    public OperationResult<int> GetFailWithData()
    {
        return OperationResult<int>.Fail(3, "fail message with data");
    }
}

```

## Contribution

Repository is opened for your contribution.
Improve it by creating `Issues` and `Pull requests`.

### Creating Pull request

Pay attention that pull requests can be created only from issues.

Algorithm:

1) Create an issue - describe what do you want to impore/fix in the library;
2) Create new branch from `main` by pattern `issues_{issue number}`;
3) Create pull request to `main` branch;
4) Make sure that all checks passed successfully;
5) Assign `sterlyukin` as reviewer of your pull-request;
6) Wait for comments or approve;
7) If your PR has some comments to fix - fix them and push to the branch again;
8) Leave comments that you fixed under all remarks;
9) When PR will be successfully closed - I wil publish it to `nuget`.

## CI/CD

CI/CD automated by Github Actions.
`Build` and `test` are launched  on push to the branch.

`Publish` to nuget launches manually in releases.