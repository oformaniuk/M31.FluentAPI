// <auto-generated/>
// This code was generated by the library M31.FluentAPI.
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#nullable enable

using M31.FluentApi.Attributes;
using System.Reflection;

namespace M31.FluentApi.Tests.CodeGeneration.TestClasses.Abstract.SameNameMemberClass;

public class CreateStudent :
    CreateStudent.ICreateStudent,
    CreateStudent.IInSemester,
    CreateStudent.IWithName,
    CreateStudent.IWithName2
{
    private readonly Student student;
    private static readonly PropertyInfo semesterPropertyInfo;
    private static readonly PropertyInfo initialPropertyInfo;
    private static readonly PropertyInfo lastNamePropertyInfo;

    static CreateStudent()
    {
        semesterPropertyInfo = typeof(Student).GetProperty("Semester", BindingFlags.Instance | BindingFlags.Public)!;
        initialPropertyInfo = typeof(Student).GetProperty("Initial", BindingFlags.Instance | BindingFlags.Public)!;
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

    public static IWithName InSemester(int semester)
    {
        CreateStudent createStudent = new CreateStudent();
        CreateStudent.semesterPropertyInfo.SetValue(createStudent.student, semester);
        return createStudent;
    }

    IWithName IInSemester.InSemester(int semester)
    {
        CreateStudent.semesterPropertyInfo.SetValue(student, semester);
        return this;
    }

    IWithName2 IWithName.WithName(char initial)
    {
        CreateStudent.initialPropertyInfo.SetValue(student, initial);
        return this;
    }

    Student IWithName2.WithName(string lastName)
    {
        CreateStudent.lastNamePropertyInfo.SetValue(student, lastName);
        return student;
    }

    public interface ICreateStudent : IInSemester
    {
    }

    public interface IInSemester
    {
        IWithName InSemester(int semester);
    }

    public interface IWithName
    {
        IWithName2 WithName(char initial);
    }

    public interface IWithName2
    {
        Student WithName(string lastName);
    }
}