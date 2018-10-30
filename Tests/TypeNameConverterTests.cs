﻿using System.Collections.Generic;
using ApprovalTests;
using MyNamespace;
using ObjectApproval;
using Xunit;

public class TypeNameConverterTests
{
    [Fact]
    public void Simple()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(string)));
    }

    [Fact]
    public void Nested()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(TargetWithNested)));
    }

    [Fact]
    public void Nullable()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(int?)));
    }

    [Fact]
    public void Array()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(int[])));
    }

    [Fact]
    public void List()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(List<TargetWithNamespace>)));
    }

    [Fact]
    public void Enumerable()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(IEnumerable<TargetWithNamespace>)));
    }

    [Fact]
    public void RuntimeEnumerable()
    {
        Approvals.Verify(TypeNameConverter.GetName(MethodWithYield().GetType()));
    }

    [Fact]
    public void EnumerableOfArray()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(IEnumerable<TargetWithNamespace[]>)));
    }

    IEnumerable<TargetWithNamespace> MethodWithYield()
    {
        yield return new TargetWithNamespace();
    }

    [Fact]
    public void ListOfArray()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(List<TargetWithNamespace[]>)));
    }

    [Fact]
    public void ArrayOfList()
    {
        Approvals.Verify(TypeNameConverter.GetName(typeof(List<TargetWithNamespace>[])));
    }

    public class TargetWithNested{}
}

namespace MyNamespace
{
    public class TargetWithNamespace{}
}