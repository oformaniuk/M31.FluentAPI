// <auto-generated/>
// This code was generated by the library M31.FluentAPI.
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#nullable enable

using System.Collections.Generic;
using M31.FluentApi.Attributes;

namespace M31.FluentApi.Tests.CodeGeneration.TestClasses.Abstract.DefaultFluentMethodNameClass;

public class CreateStudent :
    CreateStudent.ICreateStudent,
    CreateStudent.IWithName,
    CreateStudent.IIsHappy,
    CreateStudent.IWithSemester,
    CreateStudent.IWithFriends
{
    private readonly Student student;

    private CreateStudent()
    {
        student = new Student();
    }

    public static ICreateStudent InitialStep()
    {
        return new CreateStudent();
    }

    public static IIsHappy WithName(string firstName, string lastName)
    {
        CreateStudent createStudent = new CreateStudent();
        createStudent.student.WithName(firstName, lastName);
        return createStudent;
    }

    IIsHappy IWithName.WithName(string firstName, string lastName)
    {
        student.WithName(firstName, lastName);
        return this;
    }

    IWithSemester IIsHappy.IsHappy(bool isHappy)
    {
        student.IsHappy = isHappy;
        return this;
    }

    IWithSemester IIsHappy.NotIsHappy()
    {
        student.IsHappy = false;
        return this;
    }

    IWithFriends IWithSemester.WithSemester(int semester)
    {
        student.Semester = semester;
        return this;
    }

    Student IWithFriends.WithFriends(System.Collections.Generic.IReadOnlyCollection<string> friends)
    {
        student.Friends = friends;
        return student;
    }

    Student IWithFriends.WithFriends(params string[] friends)
    {
        student.Friends = friends;
        return student;
    }

    Student IWithFriends.WithFriend(string friend)
    {
        student.Friends = new string[1]{ friend };
        return student;
    }

    Student IWithFriends.WithZeroFriends()
    {
        student.Friends = new string[0];
        return student;
    }

    public interface ICreateStudent : IWithName
    {
    }

    public interface IWithName
    {
        IIsHappy WithName(string firstName, string lastName);
    }

    public interface IIsHappy
    {
        IWithSemester IsHappy(bool isHappy = true);

        IWithSemester NotIsHappy();
    }

    public interface IWithSemester
    {
        IWithFriends WithSemester(int semester);
    }

    public interface IWithFriends
    {
        Student WithFriends(System.Collections.Generic.IReadOnlyCollection<string> friends);

        Student WithFriends(params string[] friends);

        Student WithFriend(string friend);

        Student WithZeroFriends();
    }
}