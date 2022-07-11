## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

# Install

Current version of nuget package - https://www.nuget.org/packages/Antanidoss.Specification.Filters/

The framework is provided as a set of NuGet packages.

To install the minimum requirements:

```
Install-Package Antanidoss.Specification.Filters
```

## Usage

This project is intended to facilitate filtering in the repository. Usually, the problem of repositories is that they contain a large number of methods for different filtering. Now, it will be shown how to solve this problem with the help of this project.

To use this project, you need to familiarize yourself with https://github.com/Antanidoss/Antanidoss.Specification

And so, for example, we have such a class:

```csharp
public interface IPersonRepository
{
    IEnumerable<Person> GetFilter(ISpecification<Person> specification);
}

public class PersonRepository : IPersonRepository
{
    private readonly EFDbContext _context;

    public PersonRepository(EFDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetBySpecification(ISpecification<Person> specification)
    {
        return _context.Persons.Where(specification.ToExpression());
    }
}
```

The main disadvantage of this repository is that we will have to create many methods for different filtering.
Let's pass this repository like this:
```csharp
public interface IPersonRepository
{
    IEnumerable<Person> GetByFilter(IQueryableMultipleResultFilter<Person> filter);
    
    Person GetByFilter(IQueryableSingleResultFilter<Person> filter);
}

public class PersonRepository : IPersonRepository
{
    private readonly EFDbContext _context;

    public PersonRepository(EFDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetByFilter(IQueryableMultipleResultFilter<Person> filter)
    {
        return filter.ApplyFilter(_context.Persons).ToList();
    }
    
    public Person GetByFilter(IQueryableSingleResultFilter<Person> filter)
    {
        return filter.ApplyFilter(_context.Persons);
    }
}
```

Now we have two methods:
### IQueryableMultipleResultFilter - filter for the result as a collection.
### IQueryableMultipleResultFilter - filter for the result as a collection.

How to create and use a filter?

```csharp
var personByNameSpec = new PersonByNameSpec("Anton");
var personByAgeSpec = new PersonByAgeSpec(22);

var filter = new Where<Person>(personByNameSpec).FirstOrDefault<Person>(personByAgeSpec);

var person = personRepository.GetByFilter(filter);
```

We can combine filters in many ways. List of filters currently:
- Where
- FirstOrDefault
- FirstOrDefaultAsync
- OrderBy
- Include
