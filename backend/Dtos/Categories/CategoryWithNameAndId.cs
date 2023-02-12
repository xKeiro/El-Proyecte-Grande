namespace backend.Dtos.Categories;

public abstract class CategoryWithNameAndId : CategoryWithName
{
    public int Id { get; set; }
}