namespace Generics;

public class CourseStore
{
    private readonly List<Course> Courses = [];


    public void Add(Course course)
    {
        Courses.Add(course);
    }

    public Course? GetById(int id)
    {
        foreach (var course in Courses)
        {
            if (course.Id == id)
                return course;
        }

        return null;
    }

    public IReadOnlyList<Course> GetAll() => Courses;

    public void Remove(int id)
    {
        var course = GetById(id);

        if (course is not null)
            Courses.Remove(course);
    }
}
