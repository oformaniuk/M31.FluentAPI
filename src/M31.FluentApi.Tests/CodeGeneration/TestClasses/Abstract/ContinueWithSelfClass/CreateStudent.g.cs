// <auto-generated/>
// This code was generated by the library M31.FluentAPI.
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#nullable enable

using M31.FluentApi.Attributes;
using System.Reflection;

namespace M31.FluentApi.Tests.CodeGeneration.TestClasses.Abstract.ContinueWithSelfClass;

public class CreateStudent :
    CreateStudent.ICreateStudent,
    CreateStudent.IWithFirstName,
    CreateStudent.IWithMiddleNameWithLastName
{
    private readonly Student student;
    private static readonly PropertyInfo firstNamePropertyInfo;
    private static readonly PropertyInfo middleNamePropertyInfo;
    private static readonly PropertyInfo lastNamePropertyInfo;

    static CreateStudent()
    {
        firstNamePropertyInfo = typeof(Student).GetProperty("FirstName", BindingFlags.Instance | BindingFlags.Public)!;
        middleNamePropertyInfo = typeof(Student).GetProperty("MiddleName", BindingFlags.Instance | BindingFlags.Public)!;
        lastNamePropertyInfo = typeof(Student).GetProperty("LastName", BindingFlags.Instance | BindingFlags.Public)!;
    }

    private CreateStudent()
    {
        student = new Student();
    }

    public static ICreateStudent InitialStep()
    {
        return new CreateStudent();
    }

    public static IWithMiddleNameWithLastName WithFirstName(string firstName)
    {
        CreateStudent createStudent = new CreateStudent();
        CreateStudent.firstNamePropertyInfo.SetValue(createStudent.student, firstName);
        return createStudent;
    }

    IWithMiddleNameWithLastName IWithFirstName.WithFirstName(string firstName)
    {
        CreateStudent.firstNamePropertyInfo.SetValue(student, firstName);
        return this;
    }

    IWithMiddleNameWithLastName IWithMiddleNameWithLastName.WithMiddleName(string? middleName)
    {
        CreateStudent.middleNamePropertyInfo.SetValue(student, middleName);
        return this;
    }

    Student IWithMiddleNameWithLastName.WithLastName(string lastName)
    {
        CreateStudent.lastNamePropertyInfo.SetValue(student, lastName);
        return student;
    }

    public interface ICreateStudent : IWithFirstName
    {
    }

    public interface IWithFirstName
    {
        IWithMiddleNameWithLastName WithFirstName(string firstName);
    }

    public interface IWithMiddleNameWithLastName
    {
        IWithMiddleNameWithLastName WithMiddleName(string? middleName);

        Student WithLastName(string lastName);
    }
}