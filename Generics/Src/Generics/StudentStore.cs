namespace Generics;

public class StudentStore
{
    private readonly List<Student> _students = [];


    public void Add(Student student)
    {
        _students.Add(student);
    }

    public Student? GetById(int id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id)
                return student;
        }

        return null;
    }

    public IReadOnlyList<Student> GetAll() => _students;

    public void Remove(int id)
    {
        var student = GetById(id);

        if (student is not null)
            _students.Remove(student);
    }
}
